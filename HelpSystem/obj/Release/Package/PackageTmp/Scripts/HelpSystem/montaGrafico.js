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
$(document).ready(function () {
    // montaGrafico();
    //gerando os dados gráfico
    var dadosGrafico = [];
    dadosGrafico.push({ name: "Perguntas", data: 200 });
    dadosGrafico.push({ name: "Respostas", data: 300 });

    //        //configurando o eixo y do gráfico
    $.each(dadosGrafico, function (i, point) {
        point.y = point.data;
    });
    $("#grafico").highcharts({
        chart: { type: "pie" },
        title: { text: "Ranking" },
        series: [{ data: dadosGrafico }]
    });
});

function montaGrafico() {
    ////gerando os dados gráfico
    //var dadosGrafico = [];
    //dadosGrafico.push({ name: "Perguntas", data: 200 });
    //dadosGrafico.push({ name: "Respostas", data: 300 });

    ////        //configurando o eixo y do gráfico
    //$.each(dadosGrafico, function (i, point) {
    //    point.y = point.data;
    //});
    //$("#grafico").highcharts({
    //    chart: { type: "pie" },
    //    title: { text: "Ranking" },
    //    series: [{ data: dadosGrafico }]
    //});
    //$.ajax({
    //    type: "POST",
    //    url: "../../../../Home/MontaGrafico",
    //    async: true,
    //    data: {},
    //    success: function (d) {
    //        //gerando os dados gráfico
    //        var dadosGrafico = [];
    //        dadosGrafico.push({ name: "Perguntas", data: 2 });
    //        dadosGrafico.push({ name: "Respostas", data: 2 });

    //        //configurando o eixo y do gráfico
    //        $.each(dadosGrafico, function () {
    //            point.y = point.data;
    //        });
    //        $("#grafico").highcharts({
    //            chart: { type: "pie" },
    //            title: { text: "Ranking" },
    //            series: [{ data: dadosGrafico }]
    //        });
    //    },
    //    error: function (xhr) {
    //        toastr["error"](xhr.responseText);
    //    }
    //});
}

