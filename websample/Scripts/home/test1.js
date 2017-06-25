$(document).ready(function () {
    $('[tabindex=1]').focus();
})

$('.tabstop').keypress(function (e) {
    if (e.which == 13) {
        var idx = $(this).attr('tabindex');
        idx++;
        $('[tabindex=' + idx + ']').focus();
    }
})

