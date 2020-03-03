// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var defaultText = "Search...";
var searchBox = document.getElementById("search");
//default text after load 
searchBox.value = defaultText;
//on focus behaviour 
searchBox.onfocus = function () { if (this.value == defaultText) { this.value = ''; } }
//on blur behaviour 
searchBox.onblur = function () { if (this.value == "") {this.value = defaultText; } }
