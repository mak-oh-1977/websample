$(function(){
    $('#test').click(function () {
        alertDlg("hello", "hogehoge");
    });


    $(document).on("click", '#edit', function () {
//        alertDlg("edit", $(this).attr('code'));

        var param = {
            id:$(this).attr('code'),
        };

        DbAccess('', '/api/api/', param,
            function (ret) {
                $('#edit_dlg #name').val(ret['name']);
                $('#edit_dlg #kana').val(ret['kana']);
                $('#edit_dlg #tel').val(ret['tel']);
                $('#edit_dlg #password').val(ret['password']);
                //                $('#edit_dlg').dialog("destroy");
            },
            function (ret) {
/*                if (ret['info']['1'] == "1062") {
                    alertDlg("エラー", "コードが重複しています");
                }
                else {
                    alertDlg("エラー", ret['info']);
                }
*/
            }
        );

        $("#edit_dlg").dialog({
            title: 'ユーザー情報変更',
            autoOpen: true,
            modal: true,
            width: 500,
            height: 300,
            buttons: {
                "OK": function () {

                    var param = {
                        x: 'bus',
                        ctrl: 'edit',
                        key: old_code,
                        code: $('#bus_dlg #code').val(),
                        name: $('#bus_dlg #name').val(),
                        mail: $('#bus_dlg #mail').val(),
                    };

                    DbAccess('#db_msg', param,
                        function (ret) {
                            $('#bus_dlg').dialog("destroy");
                            updateBusList();
                        },
                        function (ret) {
                            if (ret['info']['1'] == "1062") {
                                alertDlg("エラー", "コードが重複しています");
                            }
                            else {
                                alertDlg("エラー", ret['info']);
                            }
                        }
                    );
                },
                "削除": function () {
                    $(this).dialog("destroy");
                    deleteBus(
                            old_code,
                            $('#bus_dlg #name').val());
                },
                "キャンセル": function () {
                    $(this).dialog("destroy");
                },
            }
        });
    });

})

