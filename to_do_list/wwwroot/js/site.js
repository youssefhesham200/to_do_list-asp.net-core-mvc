// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function markAsCompleted() {
    var selectedTaskIds = [];
    $('.form-check-input:checked').each(function () {
        selectedTaskIds.push($(this).val());
    });
    $.ajax({
        url: '/Mission/MarkSelectedMissions',
        type: 'POST',
        data: {
            selectedTaskIds: selectedTaskIds,
            submitButton: 'completed'
        },
        success: function (response) {
            window.location.reload();
        }
    });
}

function markAsNotCompleted() {
    var selectedTaskIds = [];
    $('.form-check-input:checked').each(function () {
        selectedTaskIds.push($(this).val());
    });
    $.ajax({
        url: '/Mission/MarkSelectedMissions',
        type: 'POST',
        data: {
            selectedTaskIds: selectedTaskIds,
            submitButton: 'notcompleted'
        }, success: function (response) {
            window.location.reload();
        }
    });
}