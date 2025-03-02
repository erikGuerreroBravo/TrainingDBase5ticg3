$(document).ready(function () {

    //LoadInit();
    var skills = new Array();

    $('#btnGuardarSkill').click(function (event) {
        event.preventDefault();    
        var txtSkill = $('#txtSkill').val();
        skills.push(txtSkill);
        ShowData(skills);
        Limpiar();
    });
        
});

function Limpiar() {
    $('#modalSkill').modal('hide');
    $('#txtSkill').val('');
}
function removeChip(element) {
    element.parentElement.remove();
};
function LoadInit() {
    $("#cardSkill, #carBio").hide();
    $("#cardRow").css("display", "none");
};
// Muestra solo el card seleccionado y oculta el otro
function ShowCard(cardId) {
   
    if (cardId === '#cardSkill')
    {
      $("#cardSkill").show(); 
        
    }
    if (cardId === '#carBio')
    {
        console.log("sadff");
        $("#carBio").append();
    }   
}

function LoadSkillOnly() {
    $("#cardRow").css("display", "flex");
    $("#carBio").css("display", "none");
}

function ShowData(skills) {

    $("#spanId").empty("");
    $.each(skills, function (index, skill) {
        $("#skillBody").append(`
            <span class="badge bg-success text-white me-2 mt-1 roboto-Light-300" id="spanId">
                ${skill} <!-- Interpolación de la variable 'skill' -->
                <button type="button" class="btn-close btn-close-white ms-2" aria-label="Close" onclick="removeChip(this)"></button>
            </span>
        `);
    });
}
