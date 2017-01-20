/********************************************************************************
Summary: Core jQuery library to merge bootstrap look and feel on MVC validation display.
Author: CTS Inc
Date: July 29, 2013
Copyright : Copyright (c) <year>Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
ProductName: cts.validate-unobtrusive.js
Version: 1.0.0
Version: 1.0.1
********************************************************************************
7/18/2014 - HM - Removed the addition of icon from the error message element

*/

$().ready(function () {
    $('.validation-summary-valid').prepend("<i class='icon-red icon-error' alt='error'></i>");
    $('.validation-summary-valid').addClass("alert alert-error");
});