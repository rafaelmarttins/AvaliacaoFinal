console.log(caminho);

function alterar(){
    
    var codigoRebanho = $("#txtCodigoRebanho").val();
    var nomeMunicipio = $("#txtNomeMunicipio").val();
    var siglaUF = $("#txtSiglaUF").val();
    var codigoTipoRebanho = $("#txtCodigoTipoRebanho").val();
    var codigoIBGE7 = $("#txtCodigoIBGE7").val();
    var anoReferencia = $("#txtAnoReferencia").val();
    var situacao = $("#chbAtivo").prop('checked');
    var dataDeInsercao = $("#txtDataDeInsercao").val();

    var novo = {
        codigoRebanho,
        nomeMunicipio,
        siglaUF,
        codigoTipoRebanho,
        codigoIBGE7,
        anoReferencia,
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
            codigoRebanho = data.codigoRebanho;
            alert("Dados alterados com sucesso! Codigo:" + codigoRebanho);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao alterar os dados!" + status);
            return;
        }
    })
}
