/// <reference path="/scripts/jquery-1.10.1-vsdoc.js" />

/********************************************************************************
Summary: Core jQuery library to support web application development.
Author: CTS Inc
Date: July 29, 2013
Copyright : Copyright (c) 2013 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
ProductName: cts.core.js
Version: 1.0.0
*********************************************************************************/

function displayError(data) {
    var summary = $('#PageError');
    var ul = $('#PageError > ul');
    ul.remove('li');

    summary.addClass('alert alert-error validation-summary-errors').removeClass("validation-summary-valid");

    ul.html(data.responseText);
}

function cleanError() {
    var summary = $('#PageError');
    var ul = $('#PageError > ul');
    ul.remove('li');

    summary.removeClass('alert alert-error validation-summary-errors').addClass("validation-summary-valid");

    ul.add("<li style='display:none;' />");
}

/* Dialog */
function showDialog(id) {
   $('#' + id).modal('show');
}

function closeDialog(id) {
   $('#' + id).modal('hide');
}

function myAlert () {
    alert('You have clicked the search button!');
}

function getSearchResults() {
        var id = 0;
        var name = $('#projName').val();
        var num = $('#projNum').val();
        
        function CreateObject() {
            var dto = {};
            dto.ResourceId = id;
            dto.ProjectName = name;
            dto.ProjectNumber = num;
            return dto;
        }

        var object = CreateObject();

        $.ajax({
            url: "/ViewToday/Search",
            type: "POST",
            data: JSON.stringify(object),
            dataType: "html",
            contentType: "application/json",
            success: function (data) {
                $('#searchResults').html(data);
                $('#searchResults').fadeIn('slow');
            }
        }
    );
}

function addProjectTeam() {

    function CreateObject() {
        var dto = {};
        dto.ProjectTeamId = $('#ProjectTeamId').val();
        dto.ProjectId = $('#ProjectId').val();
        dto.RoleId = $('#RoleId').val();
        dto.ProjectTeamRoleId = $('#ProjectTeamRoleId').val();
        dto.ResourceId = $('#ResourceId').val();
        return dto;
    }

    var object = CreateObject();

    $.ajax({
        url: "/ProjectMaintenance/AddProjectTeam",
        type: "POST",
        data: JSON.stringify(object),
        dataType: "html",
        contentType: "application/json",
        success: function (data) {
            $('#projectTeamTable').replaceWith(data);

        }
    })
}

function removeProjectTeam(ProjectTeamId) {
    if (confirm('Are you sure you want to delete this user? Click OK to confirm deletion...')) {
        var projTeamId = parseInt(ProjectTeamId);
        var projId = $('#ProjectId').val();

        function CreateObject() {
            var dto = {};
            dto.ProjectId = projId;
            dto.ProjectTeamId = projTeamId;
            return dto;
        }

        var object = CreateObject();

        $.ajax({
            url: "/ProjectMaintenance/RemoveProjectTeam",
            type: "POST",
            data: JSON.stringify(object),
            dataType: "html",
            contentType: "application/json",
            success: function (data) {
                $('#projectTeamTable').replaceWith(data);
            }
        })
    } else {
        alert('Deletion was canceled');
    }
}

function setHidden(ProjectTeamId, ProjectTeamRoleId, RoleId, ResourceId) {
    var projTeamId = parseInt(ProjectTeamId);
    var projTeamRoleId = parseInt(ProjectTeamRoleId);
    var roleId = parseInt(RoleId);
    var resourceId = parseInt(ResourceId)

    $('#ProjectTeamId').val(projTeamId);
    $('#ProjectTeamRoleId').val(projTeamRoleId);
    document.getElementById('ResourceId').value = resourceId;
    document.getElementById('RoleId').value = roleId;
    //$('#RoleId').val(roleId);
    //$('#ResourceId').val(resourceId);

    $('#insert').val('Update');
}

function resetButton() {
    $('#insert').val('Insert');
    $('#ProjectTeamId').val(0);
    $('#ProjectTeamRoleId').val(0);
}




($('#saveButton').on('click',function () {
    $('#detailsform').submit();
}))

        