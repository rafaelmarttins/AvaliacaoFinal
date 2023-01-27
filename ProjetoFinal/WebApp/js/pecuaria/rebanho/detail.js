var codigo = 0;

$(function(){
    avaliarAcao('rebanhoAcao');
    if(acao == 0){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#divSituacao").hide();
        $("#chbAtivo").attr('disabled', true);
    }

    if(acao == 1){
        $("#txtCodigoRebanho").attr('readonly',true);
        $("#txtSituacao").attr('readonly',true);
        $("#txtDataDeInsercao").attr('readonly', true); 
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#divSituacao").hide();
        $("#divInsercao").hide();
        $("#chbAtivo").attr('checked', true);
        $("#chbAtivo").attr('disabled', true);
    }

    if(acao == 2){
        carregarDetalhe();
        $("#txtCodigoRebanho").attr('readonly',true);
        $("#txtDataDeInsercao").attr('readonly', true); 
        $("#btnNovo").hide();
        $("#btnExcluir").hide();
        $("#divSituacao").hide();
        $("#divInsercao").hide();
    }

    if(acao == 3){
       carregarDetalhe();
       somenteLeitura();
       $("#btnNovo").hide();
       $("#btnAlterar").hide();
       $("#divSituacao").hide();
       $("#chbAtivo").attr('disabled', true);
    }
});

function somenteLeitura(){
    $("#txtCodigoRebanho").attr('readonly',true);
    $("#txtCodigoTipoRebanho").attr('readonly',true);
    $("#txtAnoReferencia").attr('readonly',true);
    $("#txtCodigoIBGE7").attr('readonly',true);
    $("#txtNomeMunicipio").attr('readonly',true);
    $("#txtSiglaUF").attr('readonly',true);
    $("#txtSituacao").attr('readonly',true);
    $("#txtDataDeInsercao").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoRebanhoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoRebanhoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoRebanho").val(data.codigoRebanho);
            $("#txtCodigoTipoRebanho").val(data.codigoTipoRebanho)
            $("#txtAnoReferencia").val(data.anoReferencia);
            $("#txtCodigoIBGE7").val(data.codigoIBGE7);
            $("#txtNomeMunicipio").val(data.nomeMunicipio);
            $("#txtSiglaUF").val(data.siglaUF);
            $("#txtSituacao").val(data.situacao);
            $("#txtDataDeInsercao").val(data.dataDeInsercao.substring(0,10));
            $("#chbAtivo").prop('checked', data.situacao);
        }
    });
}

function stringToBoolean(value){
    return (String(value) === '1' || String(value).toLowerCase() === 'true');
}