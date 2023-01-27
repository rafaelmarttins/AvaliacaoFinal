console.log(caminho);

function cadastrar(){
    var codigoRebanho = 0;
    var codigoTipoRebanho = $("#txtCodigoTipoRebanho").val();
    var anoReferencia = $("#txtAnoReferencia").val();
    var codigoIBGE7 = $("#txtCodigoIBGE7").val();
    var nomeMunicipio = $("#txtNomeMunicipio").val();
    var siglaUF = $("#txtSiglaUF").val();
    var situacao = null;
    var dataDeInsercao = null;
    
    var novo = {
        codigoRebanho,
        codigoTipoRebanho,
        anoReferencia,
        codigoIBGE7,
        nomeMunicipio,
        siglaUF,
        situacao,
        dataDeInsercao,
    };

    $.ajax({
        url : caminho,
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data)
            codigoRebanho = data.codigoRebanho;
            alert("Dados gravados com sucesso! Codigo:" + codigoRebanho);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados!" + status);
            return;
        }
    })
}


