$(function () {
    $('.menu-btn').button();

    var op = {
        closeText: '閉じる',
        prevText: '&#x3c;前',
        nextText: '次&#x3e;',
        currentText: '今日',
        monthNames: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
        monthNamesShort: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
        dateFormat: 'yy/mm',
        yearSuffix: '年',
        onSelect: function (date, instance) {


        }
    };
    $('#yearmonth').ympicker(op);
})

