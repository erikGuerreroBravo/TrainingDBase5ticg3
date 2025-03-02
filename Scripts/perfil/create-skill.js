$(document).ready(function(){

    $('#btnGuardarSkill').click(function () {

        var txtSkill = $('#txtSkill').val();
        console.log(txtSkill);
        $('#modalSkill').modal('hide');
    });
});
