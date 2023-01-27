function excluir(){
    var codigoRebanho = $("#txtCodigoRebanho").val();

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoRebanho = data.codigoRebanho;
            alert("Dados excluídos com sucesso. [CodigoRebanho = " + codigoRebanho + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}