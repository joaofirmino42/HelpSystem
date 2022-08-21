$(function () {

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

});

$("#form-cadastro").submit(function () {
    $('#btnCadastraPergunta').attr("disabled", "disabled");
    $('#btnCadastraPergunta').html('Aguarde...');
    var mod = $(this).serialize();
    $.ajax({
        type: "POST",
        url: "../../../../Home/Cadastrar",
        async: true,
        data: mod,
        success: function (result) {
            //  var data = JSON.parse(result);

            if (result.success) {
                toastr["success"](result.message);

                $('#btnCadastraPergunta').removeAttr('disabled');
                $('#btnCadastraPergunta').html('Salvar');
            }
            else {
                toastr["warning"](data.Message);
            }

        },
        error: function (xhr) {
            toastr["error"](xhr.responseText);
            $('#btnCadastraPergunta').removeProp('disabled');
        }
    });
});
function editar(id) {
    $.ajax({
        type: "POST",
        url: "../../../../Home/AbrirModal",
        async: true,
        data: { codigo: id },
        success: function (d) {
            $("#modalHelpSystem").modal("show");
            $("#divHelpSystem").html(d);
        },
        error: function (xhr) {
            toastr["error"](xhr.responseText);
        }
    });
}
function refreshTabela() {
    $.ajax({
        type: "POST",
        url: "../../../../Home/retornaLista",
        async: true,
        success: function (d) {

        },
        error: function (xhr) {
            toastr["error"](xhr.responseText);
        }
    })
}
function Atualizar() {
    var model = {
        Id: $("#hdId").val(),
        Nome: $("#txtNome").val(),
        Email: $("#txtEmail").val(),
        Pergunta: $("#txtDescricao").val(),
        Resposta: $("#txtResposta").val(),
        Ranking: $("#Ranking").val()
    }
    $.ajax({
        type: "POST",
        url: "../../../../Home/Atualizar",
        async: true,
        data: model,
        success: function (d) {
            toastr["success"](d.message);
            refreshTabela();
        },
        error: function (xhr) {
            toastr["error"](xhr.responseText);
        }
    });
}