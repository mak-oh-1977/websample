$(function(){
    //////////////////////////////////////////////////////////////////////////
    //
    //
    //
    $(document).ready(function () {

        updateList();

    });

    //------------------------------------------------------------------------
    //
    //*	ユーザーリスト更新
    //

    //////////////////////////////////////////////////////////////////////////
    //
    //
    //
    function updateList() {
        var param = {
            cmd: 'LIST',
        };

        DbAccess('', '/users/api/', param,
			function (ret) {
			    $('#list tbody').remove();

			    var tbody = $('<tbody>');
			    for (var i = 0; i < ret.users.length; i++) {
			        var row = ret.users[i];

			        var r = $('<tr>', { no: row['id'] });

			        $('<td>', { text: row['name'] })
							.appendTo(r);
			        $('<td>', { text: row['kana'] })
							.appendTo(r);
			        $('<td>', { text: row['tel'] })
							.appendTo(r);
			        $('<td>', { text: row['password'] })
							.appendTo(r);

			        $(tbody).append(r);
			    }
			    $('#list').append(tbody);
			}
		);

    }

    $('#add').click(function () {
        $("#edit_dlg").dialog({
            title: 'ユーザー情報追加',
            autoOpen: true,
            modal: true,
            width: 500,
            height: 300,
            buttons: {
                "OK": function () {

                    var param = {
                        cmd: 'INSERT',
                        user: {
                            id: -1,
                            name: $('#edit_dlg #name').val(),
                            kana: $('#edit_dlg #kana').val(),
                            tel: $('#edit_dlg #tel').val(),
                            password: $('#edit_dlg #password').val(),
                        }
                    };

                    DbAccess('', '/users/api/', param,
                        function (ret) {
                            $('#edit_dlg').dialog("destroy");
                            updateList();
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
                "キャンセル": function () {
                    $(this).dialog("destroy");
                },
            }
        });
    });


    $(document).on("click", '#list tbody tr', function () {
        //        alertDlg("edit", $(this).attr('code'));

        var code = $(this).attr('no');
        var param = {
            cmd: 'SELECT',
            id: code,
//            users: [{ id: code }]
        };

        DbAccess('', '/users/api/', param,
            function (ret) {
                $('#edit_dlg #name').val(ret.user['name']);
                $('#edit_dlg #kana').val(ret.user['kana']);
                $('#edit_dlg #tel').val(ret.user['tel']);
                $('#edit_dlg #password').val(ret.user['password']);
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
                        cmd: 'UPDATE',
                        user: {
                            id: code,
                            name: $('#edit_dlg #name').val(),
                            kana: $('#edit_dlg #kana').val(),
                            tel: $('#edit_dlg #tel').val(),
                            password: $('#edit_dlg #password').val(),
                        }
                    };

                    DbAccess('', '/users/api/', param,
                        function (ret) {
                            $('#edit_dlg').dialog("destroy");
                            updateList();
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

