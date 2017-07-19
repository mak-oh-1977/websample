$(function(){
    $('.menu-btn').button();

    $('.ym').ympicker({
        closeText: '閉じる',
        prevText: '<前',
        nextText: '次>',
        currentText: '今日',
        monthNames: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
        monthNamesShort: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
        dateFormat: 'yy/mm',
        yearSuffix: '年'
    });

})

$('#test1').click(function () {
    $('#dlg_test').dialog({
        title: 'ユーザー情報変更',
        autoOpen: true,
        modal: true,
        width: 500,
        height: 300,
        buttons: {
            "OK": function () {
                $('#dlg_test2').dialog({
                    title: 'ユーザー情報変更2',
                    autoOpen: true,
                    modal: true,
                    width: 500,
                    height: 300,
                    buttons: {
                        "OK": function () {
                            $(this).dialog("destroy");
                            $('#dlg_test').dialog("destroy");
                        }
                    }
                });

            },
            "キャンセル": function () {
                $(this).dialog("destroy");
            },
        }
    });
});
