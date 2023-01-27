console.log(caminho);

function alterar(){
    
    var codigoTipoRebanho = $("#txtCodigoTipoRebanho").val();
    var descricao = $("#txtDescricao").val();
    var situacao = $("#chbAtivo").prop('checked');
    var dataDeInsercao = $("#txtDataDeInsercao").val();

    var novo = {
        codigoTipoRebanho,
        descricao,
        situacao,
        dataDeInsercao
    };

    $.ajax({
        url : caminho,
        type: "put",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data)
            codigoTipoRebanho = data.codigoTipoRebanho;
            alert("Dados alterados com sucesso! Codigo:" + codigoTipoRebanho);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao alterar os dados!" + status);
            return;
        }
    })
}
