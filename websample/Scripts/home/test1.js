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

//フォームの初期化
function InitItems(items)
{
    $(items).
        filter('input[type="text"],textarea,select').each(function () {
            $(this).val('');
        });
    $(items).
        filter('input[type="radio"][default]').each(function () {
            $(this).prop('checked', true);
        });
}

//フォーム→オブジェクト
function GetParam(items)
{
    var param = {};

    $(items)
        .filter('input[type="text"],input[type="radio"]:checked,textarea,select')
        .each(function () {
            var name = $(this).attr('name');
            param[name] = $(this).val();
        });
    console.debug(param);

    return param
}

//オブジェクト→フォーム
function SetItem(items, param)
{
    $.each(param, function (key, val) {
        console.debug(key + "=" + val);
        $(items).filter('[name=' + key + ']').val([val]);
    })
}

$('button#send').click(function () {
    var items = $('#test1 .in-item');
    var param = GetParam(items);

    InitItems(items);

    DbAccess('', '/home/sendback/', param,
        function (ret) {
            console.debug(ret);

            SetItem(items, ret);
        },
        function (ret) {
        }
    );
});

$('a#send2').click(function () {
    var items = $('#test2 .in-item');
    var param = GetParam(items);

    InitItems(items);

    var url = $(this).attr('href');
    DbAccess('', url, param,
        function (ret) {
            console.debug(ret);

            SetItem(items, ret);
        },
        function (ret) {
        }
    );
});