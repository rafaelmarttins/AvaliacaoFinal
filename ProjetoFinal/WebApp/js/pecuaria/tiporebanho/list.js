$(function(){
  carregar();
});

function carregar(){
  $.get(caminho, function(data, status){
      if (data == 0){
        alert("Erro ao obter os dados.")
        return;
      }
      else{
        for (let index = 0; index < data.length; index++) {
          const tiporebanho = data[index];
          
          console.log(tiporebanho);

          var codigoTipoRebanho = tiporebanho.codigoTipoRebanho;
          var descricao = tiporebanho.descricao;
          

          var linha = '';
          linha += "<tr>";
          linha += "<td class='table-active text-center'><button id='btnExibirAtual' class='border-light border-0' onclick='exibirAtual("+ codigoTipoRebanho +");'> <img src='/img/att.png''width=35 height=35'></button></td>";
          linha += "<td class='table-active text-center'>" + codigoTipoRebanho + "</td>";
          linha += "<td class='table-active text-center'>" + descricao + "</td>";
          linha += "<td class='table-active text-center'><button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoTipoRebanho +");'> Alterar</button></td>";
          linha += "<td class='table-active text-center'><button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoTipoRebanho +");'> Excluir </button></td>";
          linha += "</tr>";
          
          $("#tblDados tbody").append(linha);
        }
      }

  });
}

function exibirAtual(codigo){
  localStorage.setItem("tipoRebanhoAcao", JSON.stringify(0));
  localStorage.setItem("codigoTipoRebanhoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
localStorage.setItem("tipoRebanhoAcao", JSON.stringify(1));
window.location.href = "detail.html"
}

function alterarAtual(codigo){
localStorage.setItem("tipoRebanhoAcao", JSON.stringify(2));
localStorage.setItem("codigoTipoRebanhoSelecionado",JSON.stringify(codigo));
window.location.href = "detail.html";
}

function excluirAtual(codigo){
localStorage.setItem("tipoRebanhoAcao", JSON.stringify(3));
localStorage.setItem("codigoTipoRebanhoSelecionado",JSON.stringify(codigo));
window.location.href = "detail.html";
}