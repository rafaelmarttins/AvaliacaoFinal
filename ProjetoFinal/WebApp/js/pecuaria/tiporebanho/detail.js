var codigo = 0;

$(function(){
    avaliarAcao("tipoRebanhoAcao")
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
        $("#txtCodigoTipoRebanho").attr('readonly', true);
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
        $("#txtCodigoTipoRebanho").attr('readonly', true);
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
    $("#txtCodigoTipoRebanho").attr('readonly', true);
    $("#txtDescricao").attr('readonly', true)
    $("#txtSituacao").attr('readonly',true);
    $("#txtDataDeInsercao").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoTipoRebanhoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoTipoRebanhoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoTipoRebanho").val(data.codigoTipoRebanho);
            $("#txtDescricao").val(data.descricao);
            $("#txtSituacao").val(data.situacao);
            $("#txtDataDeInsercao").val(data.dataDeInsercao.substring(0,10));
            $("#chbAtivo").prop('checked', data.situacao);
        }
    });
}

function stringToBoolean(value){
    return (String(value) === '1' || String(value).toLowerCase() === 'True');
}