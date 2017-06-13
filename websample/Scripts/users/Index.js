$(function(){
    $('#test').click(function () {
        alertDlg("hello", "hogehoge");
    });


    $(document).on("click", '#edit', function () {
//        alertDlg("edit", $(this).attr('code'));

        var code = $(this).attr('code');
        var param = {
            id: code,
            cmd:'SELECT'
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
                        id: code,
                        cmd:'UPDATE',
                        name:$('#edit_dlg #name').val(),
                        kana: $('#edit_dlg #kana').val(),
                        tel: $('#edit_dlg #tel').val(),
                        password: $('#edit_dlg #password').val(),
                    };

                    DbAccess('', '/api/api/', param,
                        function (ret) {
                            $('#edit_dlg').dialog("destroy");
//                            updateBusList();
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

