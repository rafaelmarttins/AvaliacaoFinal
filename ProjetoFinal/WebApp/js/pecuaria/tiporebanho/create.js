console.log(caminho);

function cadastrar(){
    var codigoTipoRebanho = 0;
    var descricao = $("#txtDescricao").val();
    var situacao = null;
    var dataDeInsercao = null;

    var novo = {
        codigoTipoRebanho,
        descricao,
        situacao,
        dataDeInsercao
    };

    $.ajax({
        url : caminho,
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data)
            codigoTipoRebanho = data.codigoTipoRebanho;
            alert("Dados gravados com sucesso! Codigo:" + codigoTipoRebanho);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados!" + status);
            return;
        }
    })
}
