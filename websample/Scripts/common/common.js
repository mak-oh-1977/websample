$(document).ready(function () {

    $('li.dropdown').hover(
			function () {
				$(this).find('dl').slideDown(200);
			},
			function () {
				$(this).find('dl').hide();
			}
	);
    $('dl.dropdown-menu').hide();

});
//////////////////////////////////////////////////////////////////////////
//
//
//
function alertDlg(title_txt, msg, ok_cb) {
    var dlg = $('<div/>', { title: title_txt })
		.append($('<p/>').html(msg))
		.append($('<div/>', { id: 'msg' })
	);
    $(dlg).appendTo(document.body);

    var btn = $(this);
    $(dlg).dialog({
        autoOpen: true,
        modal: true,
        width: 400,
        minHeight: 150,
        maxHeight: 500,
        buttons: {
            "OK": function () {
                var dlg = $(this);

                $(dlg).dialog("close");
                $(dlg).remove();

                if (typeof (ok_cb) == 'function') {
                    ok_cb();
                }
            },
        }
    });
}


//////////////////////////////////////////////////////////////////////////
//
//
//
function DbAccess(msg, req, param, ok_cb, ng_cb) {
//    ShowMsg(msg, "サーバー処理中です。。。", true);

    $.post(
		req,
		param,
		function (ret) {
		    var ar = eval(ret);
		    if (ret["res"] == "OK") {
//		        ShowMsg(msg, "完了しました");
		        if (typeof (ok_cb) == 'function')
		            ok_cb(ret);
		    }
		    else {
//		        ShowMsg(msg, "");
		        if (typeof (ng_cb) == 'function') {
		            ng_cb(ret);
		            return;
		        }

		        alertDlg("エラー", ret["msg"] + "<br>" + ret['info']);
		    }
		},
		"json"
	);

}

//////////////////////////////////////////////////////////////////////////
//
//	Fileダウンロード実装
//
//	module:送信先モジュール名
//	values:パラメータ配列
//
function downloadFile(module, values) {
    $('#downloadFile').remove();
    var p = $('<div/>', { id: 'downloadFile' });

    $('<iframe/>', { name: 'downloadFile', })
		.hide()
		.appendTo(p);

    $(p).appendTo(document.body);

    var f;
    f = $('<form/>', { action: module, method: 'post', target: 'downloadFile' })

    if (values !== undefined) {
        for (var i in values) {
            var v = values[i];
            $(f).append($('<input/>', { type: 'hidden', name: v.name, value: v.value }))
        }
    }

    $(f).appendTo(p)
		.submit();
};

