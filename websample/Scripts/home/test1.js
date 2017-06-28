$(document).ready(function () {
    $('[tabindex=1]').focus();
});

$('.in-item').keydown(function (e) {
    if (e.which == 13) {
        var idx = $(this).attr('tabindex');
        idx++;
        $('[tabindex=' + idx + ']').focus();
    }
});

$('button#send').click(function () {

    var items = $('.in-item');
    for (var i = 0; i < items.length; i++)
    {
        var item = $(items).eq(i);
        var type = $(item).attr('type');

        var v = '';
        var name = $(item).attr('name');
        if (type == 'radio')
        {
            var check = $(item).prop('checked');
            if (check == true)
            {
                v = $(item).val();
            }
        }
        else
        {
            v = $(item).val()
        }
        if (v != '')
            alert(name + ':' + v);

    }
    var radio = $('input[type]:checked').val();
    alert(radio);
});