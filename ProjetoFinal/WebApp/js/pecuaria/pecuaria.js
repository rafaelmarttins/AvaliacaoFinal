var acao = 0;
var listaUrl = [];

function avaliarAcao(strAcao){
    var tmp = localStorage.getItem(strAcao);
    if (tmp != undefined){
        acao = JSON.parse(tmp);
        localStorage.removeItem(strAcao);
    }
    else{
        alert("Ação não foi informada, utilizando valor padrão [detalhar]");
    }
}

function paginacao(parametro, count, limite){
    listaUrl = [];
    var calculo = (count % limite);
    var nPagina = (count / limite);
 
    if (calculo != 0){
        nPagina = Math.ceil(nPagina);
    }
    var urltakeskip;                      
    for (let index = 0; index < nPagina; index++) {
        var limiteskip = index * limite;
        urltakeskip = parametro + "?limite=" + limite + "&salto=" + limiteskip;
        console.log(urltakeskip);
        listaUrl[index] = urltakeskip;
    }
}