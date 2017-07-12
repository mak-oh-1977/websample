$(function () {
    $('.menu-btn').button();
})

$('#login').click(function () {

    param = {
        id: $('input[name=user]').val(),
        password:$('input[name=password]').val()
    }

    DbAccess('#msg', '/Login/Login/', param,
          function (ret) {
              SendForm('/Menu/Index/', null);

          }
      );

})