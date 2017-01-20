
/********************************************************************************
Summary: jQuery library to support server side pagination (with or withoug ellipis) and sorting.
Author: CTS Inc
Date: July 29, 2013
Copyright : Copyright (c) <year>Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
ProductName: cts.paginate-table.js

Example:
<div id="UserListing">
    <table id='test' class='table-sortable'>
        <thead>
            <tr>
                <th style="width: 10%" data-sortkey="UserKey">Id</th>
                <th style="width: 25%" data-sortkey="FirstName">First Name</th>
                <th style="width: 25%" data-sortkey="LastName">Last Name</th>
                <th style="width: 40%" data-sortkey="Email">Email </th>
            </tr>
        </thead>
        <tbody>
        <tr>...</tr>
        </tbody>
    <table>
</div>

Usage:
Paginate only:
    $('#test').paginate({
        action: '@Model.Criteria.Action',
        controller: '@Model.Criteria.Controller',
        targetId: '@Model.Criteria.TargetId',
        page: @Model.PageIndex,                         ------> this is a int value no srounding ''
        hasPrevious: @Model.HasPreviousPage,            ------> this is a int value no srounding ''
        hasNext:  @Model.HasNextPage,                   ------> this is a int value no srounding ''
        totalPages: @Model.PageCount                    ------> this is a int value no srounding ''
        
    });

Paginate and column sort:
    Note: Each 'th' must have 'id' attribute for sorting.

    var userListTable = $('#test').paginate({
            action: '@Model.Criteria.Action',
            controller: '@Model.Criteria.Controller',
            targetId: '@Model.Criteria.TargetId',
            sort: '@Model.Criteria.Sort',
            order: '@Model.Criteria.Order',
            filter: '@Model.Criteria.Filter',
            page: @Model.PageIndex,                     ------> this is a int value no srounding ''
            hasPrevious: @Model.HasPreviousPage,        ------> this is a int value no srounding ''
            hasNext:  @Model.HasNextPage,               ------> this is a int value no srounding ''
            totalPages: @Model.PageCount                ------> this is a int value no srounding ''
        });

Paginate with ellipse:
    var userListTable = $('#test').paginate({
            action: '@Model.Criteria.Action',
            controller: '@Model.Criteria.Controller',
            targetId: '@Model.Criteria.TargetId',
            page: @Model.PageIndex,                     ------> this is a int value no srounding ''
            hasPrevious: @Model.HasPreviousPage,        ------> this is a int value no srounding ''
            hasNext:  @Model.HasNextPage,               ------> this is a int value no srounding ''
            totalPages: @Model.PageCount,               ------> this is a int value no srounding ''
            numericPageCount: 2,
            showEllipse: true
        });

Refresh table from outside:
    function refreshUserList() {
        closeDialog('dialog');
        userListTable.trigger('update');
    }
*********************************************************************************/

(function ($) {
    $.extend({
        paginate: new
        function () {
            this.defaults = {
                sort: null,
                order: 'Ascending',
                filter: null,
                page: 1,
                url: null,
                targetId: null,
                totalPages: 0,
                showEllipse: false,
                hasPrevious: false,
                hasNext: true,
                numericPageCount: 5,
                debug: false

            };

            function _applyFilterColumnData(id, textbox, filterJson, filterIcon) {
                var filters = filterJson.Filters;
                
                $(filters).each(function () {
                    if (this.PropertyName === id) {
                        textbox.val(this.PropertyValue);
                        filterIcon.addClass('filterSel');
                        return;
                    }
                });
            }

            function _buildFilter(filterCols) {
               
                var filters = {};
                filters.Filters = [];

                filterCols.each(function () {
                    if ($(this).attr('data-filterkey') != null) {
                        var textbox = $(this).children(":first").children(":first");

                        if (textbox != null && $.trim(textbox.val()).length > 0) {
                            var filter = new Object();
                            filter.PropertyName = $(this).attr('data-filterkey');
                            filter.PropertyValue = textbox.val();
                            filter.PropertyDataType = $(this).attr('data-type');

                            filters.Filters.push(filter);
                        }
                    }
                    
                });

                return JSON.stringify(filters);
            }

            function _applyFilter(table) {
                var curConfig = table.config;
                var needPopulateData = ((curConfig.filter != null) && (curConfig.filter.length > 0));

                //get filter json ready for _applyFilterColumnData to populate the values in the textboxes
                var filterJson = null;
                if (needPopulateData) {
                    curConfig.filter = $('<div/>').html(curConfig.filter).text();
                    filterJson = JSON.parse(curConfig.filter);
                }

                var filterCols = $(table).children("thead").children("tr").children("th");
                filterCols.each(function () {

                    var filterkey = $(this).attr('data-filterkey');
                    if (filterkey != null) {

                        var filterIcon = $('<i class="fa fa-filter"></i>');
                        var textbox = $('<input type="text" class="bodyfont" hidden style="z-index: 999"/>');

                        filterIcon.append(textbox);
                        $(this).append(' ').append(filterIcon);

                        if (needPopulateData) {
                            _applyFilterColumnData(filterkey, textbox, filterJson, filterIcon);
                        }

                        //assign click to filter icon
                        filterIcon.on('click', function (e) {
                            e.stopPropagation();

                            textbox.click(function (e) {
                                e.stopPropagation();
                            });

                            $(textbox).toggle();
                            if (textbox.is(':visible')) {
                                $(textbox).width($(this).parent().width());
                               
                                $(textbox).focus();
                            }
                        });

                        //assign lost focus to textbox
                        $(textbox).on("blur", function () {
                            $(textbox).hide();

                            curConfig.page = 0;
                            var currentFilter = _buildFilter(filterCols);

                            if (curConfig.filter !== currentFilter) {
                                curConfig.filter = currentFilter;

                                $.ajax({
                                    url: curConfig.url,
                                    type: 'post',
                                    data: JSON.stringify({
                                        action: curConfig.action,
                                        controller: curConfig.controller,
                                        TargetId: curConfig.targetId,
                                        page: curConfig.page,
                                        sort: curConfig.sort,
                                        order: curConfig.order,
                                        filter: curConfig.filter,
                                        headerclick: false
                                    }),
                                    contentType: 'application/json',
                                    success: function (data) {
                                        $('#' + curConfig.targetId).html(data);
                                    }
                                });
                            }
                        });
                    }
                });
            }

            /*
                Adds header click event to post for server side sorting.
            */
            function _applySortable(table) {

                $(table).find('[data-sortkey=' + table.config.sort + ']').addClass(table.config.order);

                if (table.config.debug) {
                    alert(JSON.stringify(table.config));
                }

                $('thead th[data-sortkey]', table).click(function () {
                    var curConfig = table.config;
                    var curOrder = $(this).attr('class');
                    if (curOrder == 'undefined' || curOrder == "Ascending") {
                        curConfig.order = "Descending";
                    }
                    else {
                        curConfig.order = "Ascending";
                    }

                    $.ajax({
                        url: curConfig.url,
                        type: 'post',
                        data: JSON.stringify({
                            action: curConfig.action,
                            controller: curConfig.controller,
                            TargetId: curConfig.targetId,
                            page: curConfig.page,
                            sort: $(this).attr('data-sortkey'),
                            order: curConfig.order,
                            filter: curConfig.filter,
                            headerclick: true
                        }),
                        contentType: 'application/json',
                        success: function (data) {
                            $('#' + curConfig.targetId).html(data);
                        }
                    });
                });
            }

            /*
                Adds pagination with full page numbers.
            */
            function _applyPaginationDefault(table) {
                var curConfig = table.config;

                var pageItemList = $('ul', $(table).siblings('div.pagination-footer'));;
                pageItemList.children().remove();

                //Add previous pagination set button
                if (curConfig.hasPrevious) {
                    var liLeft = $('<li><a href="javascript:void(0);">«</a></li>');
                    $(liLeft).click(function () {
                        _footerPost(curConfig, curConfig.page - 1, curConfig.sort);
                    });
                    pageItemList.append(liLeft)
                }
                else {
                    pageItemList.append('<li class="disabled"><a href="javascript:void(0);">«</a></li>')
                }

                //Add all the page numbers
                for (var i = 1; i <= curConfig.totalPages; i++) {
                    if (i == curConfig.page) {
                        pageItemList.append('<li class="disabled"><a href="javascript:void(0);">' + i + '</a></li>');
                    }
                    else {
                        var liNumbers = $('<li id="' + i + '"><a href="javascript:void(0);">' + i + '</a></li>');
                        $(liNumbers).click(function () {
                            _footerPost(curConfig, $(this).attr('id'), curConfig.sort);
                        });
                        pageItemList.append(liNumbers)
                    }
                }

                //Add next pagination set button
                if (curConfig.hasNext) {
                    var liRight = $('<li><a href="javascript:void(0);">»</a></li>');
                    $(liRight).click(function () {
                        _footerPost(curConfig, curConfig.page + 1, curConfig.sort);
                    });
                    pageItemList.append(liRight);
                }
                else {
                    pageItemList.append('<li class="disabled"><a href="javascript:void(0);">»</a></li>')
                }
            }

            /*
                Adds ellipsis when the page count increases above numericPageCount value.
            */
            function _applyPaginationGroup(tableholder, table, startPageIndex) {
                var curConfig = table.config;
                //get footer - ul inside div 
                var pageItemList = $('ul', $(table).siblings('div.pagination-footer'));
                pageItemList.children().remove();

                //display « as active or disabled 
                if (curConfig.page > curConfig.numericPageCount) {
                    var pageIndex = startPageIndex - curConfig.numericPageCount;

                    var liFirstNum = $('<li><a href="javascript:void(0);">«</a></li>');
                    $(liFirstNum).click(function () {
                        _footerPost(curConfig, pageIndex, curConfig.sort);
                        tableholder.attr('startPageIndex', pageIndex);
                    });
                    pageItemList.append(liFirstNum)
                    pageItemList.append('<li class="disabled"><a href="javascript:void(0);">...</a></li>');
                }
                else {
                    pageItemList.append('<li class="disabled"><a href="javascript:void(0);">«</a></li>');
                }

                var endPageIndex = startPageIndex + curConfig.numericPageCount;
                if (endPageIndex > curConfig.totalPages) {
                    //if endPageIndex is greater than totalpages reset the endPageIndex = totalPages
                    endPageIndex = curConfig.totalPages;
                }

                //add only the page numbers
                for (var i = startPageIndex; i < endPageIndex; i++) {
                    if (i == curConfig.page) {
                        pageItemList.append('<li class="disabled"><a href="javascript:void(0);">' + i + '</a></li>');
                    }
                    else {
                        var liNumbers = $('<li id="' + i + '"><a href="javascript:void(0);">' + i + '</a></li>');
                        $(liNumbers).click(function () {
                            _footerPost(curConfig, $(this).attr('id'), curConfig.sort);
                        });
                        pageItemList.append(liNumbers)
                    }
                }

                if (endPageIndex == curConfig.totalPages) {
                    //last pagination set so last on is the total page number. No need to add '...' 
                    var liLastNum;
                    if (curConfig.page == endPageIndex) {
                        //last page selected so display as disabled
                        liLastNum = $('<li class="disabled" id="' + endPageIndex + '"><a href="javascript:void(0);">' + endPageIndex + '</a></li>');
                    }
                    else {
                        liLastNum = $('<li id="' + endPageIndex + '"><a href="javascript:void(0);">' + endPageIndex + '</a></li>');
                    }
                    //add click event to post
                    $(liLastNum).click(function () {
                        _footerPost(curConfig, endPageIndex, curConfig.sort);
                    });

                    pageItemList.append(liLastNum);
                    pageItemList.append('<li class="disabled"><a href="javascript:void(0);">»</a></li>');

                }
                else {
                    //has more pagination set so display '...' as last page number
                    pageItemList.append('<li class="disabled"><a href="javascript:void(0);">...</a></li>');
                    var liRight = $('<li><a href="javascript:void(0);">»</a></li>');
                    $(liRight).click(function () {
                        _footerPost(curConfig, endPageIndex, curConfig.sort);
                        tableholder.attr('startPageIndex', endPageIndex);
                    });

                    pageItemList.append(liRight);
                }

                return startPageIndex;
            }

            /*
                Helper method for footer click event to support post.
            */
            function _footerPost(curConfig, pageToSet, sortToSet) {
                $.ajax({
                    url: curConfig.url,
                    type: 'post',
                    data: JSON.stringify({
                        action: curConfig.action,
                        controller: curConfig.controller,
                        targetId: curConfig.targetId,
                        page: pageToSet,
                        sort: sortToSet,
                        order: curConfig.order,
                        filter: curConfig.filter
                    }),
                    contentType: 'application/json',
                    success: function (data) {
                        $('#' + curConfig.targetId).html(data);
                    }
                });
            }

            this.construct = function (settings) {
                return this.each(function () {

                    // declare
                    var $this, $document, $headers, cache, config, shiftDown = 0,
                        sortOrder;
                    // new blank config object
                    this.config = {};
                    // merge and extend.
                    config = $.extend(this.config, $.paginate.defaults, settings);
                    // store common expression for speed
                    $this = $(this);
                    // save the settings where they read
                    $.data(this, "paginate", config);

                    if ($(this).hasClass('table-filterable')) {
                        _applyFilter(this);
                    }
                    
                    if ($(this).hasClass('table-sortable')) {
                        _applySortable(this);
                    }

                    if (this.config.showEllipse) {
                        var newStartPageIndex;
                        $elem = $this.parents('#' + config.targetId);
                        var attr = $elem.attr('startPageIndex');
                        if (typeof attr !== 'undefined' && attr !== false) {
                            _applyPaginationGroup($elem, this, parseInt(attr));
                        }
                        else {
                            _applyPaginationGroup($elem, this, 1);
                        }

                    }
                    else {
                        _applyPaginationDefault(this);
                    }

                    $this.bind("update", function () {
                        var curConfig = this.config;

                        if (curConfig.debug) {
                            alert(JSON.stringify(curConfig));
                        }

                        $.ajax({
                            url: curConfig.url,
                            type: 'post',
                            data: JSON.stringify({
                                action: curConfig.action,
                                controller: curConfig.controller,
                                targetId: curConfig.targetId,
                                page: curConfig.page,
                                sort: curConfig.sort,
                                order: curConfig.order,
                                filter: curConfig.filter
                            }),
                            contentType: 'application/json',
                            success: function (data) {
                                $('#' + curConfig.targetId).html(data);
                            }
                        });
                    });
                });


            };
        }
    });

    // extend plugin scope
    $.fn.extend({
        paginate: $.paginate.construct
    });

})(jQuery);