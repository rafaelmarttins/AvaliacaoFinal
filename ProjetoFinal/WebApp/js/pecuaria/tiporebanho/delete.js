function excluir(){
    var codigoTipoRebanho = $("#txtCodigoTipoRebanho").val();

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoRebanho = data.codigoTipoRebanho;
            alert("Dados excluídos com sucesso. [CodigoTipoRebanho = " + codigoTipoRebanho + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}