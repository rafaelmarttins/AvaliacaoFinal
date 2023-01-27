var caminhoEnvelope = '';
$(function(){
  carregarTipoRebanho();
  $("#ddlTipoRebanho").change(function(){
    var codigoTipoRebanho = $(this).children("option:selected").val();
    var limite = $("#ddlTakeSkip").children("option:selected").val();
    var salto = 0;
    if(limite != 0 ){
      caminhoEnvelope = caminho + "/envelope/PorTipoRebanho/" + codigoTipoRebanho + "?limite=" + limite + "&salto=" + salto ;
      carregar(caminhoEnvelope);
    }
    else{
      limite = 100;
      caminhoEnvelope = caminho + "/envelope/PorTipoRebanho/" + codigoTipoRebanho + "?limite=" + limite + "&salto=" + salto ;
      carregar(caminhoEnvelope);
    }
  });

  $("#ddlTakeSkip").change(function(){
    var limite = $(this).children("option:selected").val();
    var codigoTipoRebanho = $("#ddlTipoRebanho").children("option:selected").val();
    var salto = 0;
    if (codigoTipoRebanho != 0){
      caminhoEnvelope = caminho + "/envelope/PorTipoRebanho/" + codigoTipoRebanho + "?limite=" + limite + "&salto=" + salto ;
      carregar(caminhoEnvelope);
    }
    else{
      alert("Informe um Tipo de Rebanho para pesquisa.")
    }
  });
});

function carregar(caminhoEnvelope){
    $.ajax({
      url: caminhoEnvelope,
      type: "get",
      dataType: "json",
      contentType: "application/json",
      data: null,
      async: false,
      success: function(data, status, xhr){
        var codigoStatus = data.status.codigo;
        var mensagemStatus = data.status.mensagem;
                
        if (codigoStatus == 404){
          $("#liPagina").hide();
          $("#liPosterior").hide();          
          alert(mensagemStatus);
          return;
        }
        
        $("#tblDados tbody").empty();        

        for (let index = 0; index < data.dados.length; index++) {
          const rebanho = data.dados[index];

          console.log(rebanho);


          var codigoRebanho = rebanho.codigoRebanho;
          var nomeMunicipio = rebanho.nomeMunicipio;
          var siglaUF = rebanho.siglaUF;
          var codigoTipoRebanho = rebanho.codigoTipoRebanho;
          var hasPrev = data.paginacao.hasPrev;
          var hasNext = data.paginacao.hasNext;
          var pageNumber = data.paginacao.pageNumber;                    

          var linha = '';
          linha += "<tr>";
          linha += "    <td class='table-active text-center'>";
          linha += "      <button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoRebanho +");'> ";
          linha += "        <img src='/img/att.png''width=35 height=35'>";
          linha += "      </button>";
          linha += "    </td>";
          linha += "  <td class='table-active text-center'>" + codigoRebanho + "</td>";
          linha += "  <td class='table-active text-center'>" + nomeMunicipio + "</td>";
          linha += "  <td class='table-active text-center'>" + siglaUF + "</td>";
          linha += "  <td class='table-active text-center'>" + codigoTipoRebanho + "</td>";
          linha += "  <td class='table-active text-center'>";
          linha += "    <button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoRebanho +");'> Alterar</button>";
          linha += "  </td>";
          linha += "  <td class='table-active text-center'>";
          linha += "  <button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoRebanho +");'> Excluir </button>";
          linha += "  </td>";
          linha += "</tr>";
            $("#tblDados tbody").append(linha);
        }        
        carregarLinkPaginacao(pageNumber, hasPrev, hasNext);
      },
      error: function(xhr, status, errorThrown){
          alert("Erro ao obter os dados. " + status);
          return;
      }
    });
}

function exibirAtual(codigoRebanho){
  localStorage.setItem("rebanhoAcao", JSON.stringify(0));
  localStorage.setItem("codigoRebanhoSelecionado",JSON.stringify(codigoRebanho));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
localStorage.setItem("rebanhoAcao", JSON.stringify(1));
window.location.href = "detail.html"
}

function alterarAtual(codigoRebanho){
localStorage.setItem("rebanhoAcao", JSON.stringify(2));
localStorage.setItem("codigoRebanhoSelecionado",JSON.stringify(codigoRebanho));
window.location.href = "detail.html";
}

function excluirAtual(codigoRebanho){
localStorage.setItem("rebanhoAcao", JSON.stringify(3));
localStorage.setItem("codigoRebanhoSelecionado",JSON.stringify(codigoRebanho));
window.location.href = "detail.html";
}

var rebanho = [];
console.log(rebanho);

function carregarTipoRebanho(){
  var caminhoTipoRebanho  = servidor + "/" + "TipoRebanho";
  $.get(caminhoTipoRebanho, function(data){

        for (let index = 0; index < data.length; index++) {
          const tiporebanho = data[index];
          
          console.log(tiporebanho);

          $("#ddlTipoRebanho").append(
            $('<option></option>').val(tiporebanho.codigoTipoRebanho).html(tiporebanho.descricao)
        );
        }     
  });
}

function carregarLinkPaginacao(numeroPagina, anterior, posterior){
  $("#navPaginacao ul").empty();


    var linha = '';
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liAnterior' onclick='carregar(\""+ anterior +"\")' tabindex='-1'>Anterior</a>";
    linha += "</li>";
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liPagina'> "+ numeroPagina +"</a>";
    linha += "</li>";
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liPosterior' onclick='carregar(\""+ posterior +"\")'>Próximo</a>";
    linha += "</li>";
    $("#navPaginacao ul").html(linha);

    if(numeroPagina == 1){
      $("#liAnterior").hide();
    }
  }




  



  
