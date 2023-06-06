
//aqui a no JS precisamos identificar quais sao os botoes que terao afunçao de cick, no caso eu identifiquei abaixo como,
//'buttonOsklen' e 'closex', em seguida precisamos guardar as informaçoes das outras divs, o bloco do popap que eu chamei de 'blocoparede' e
// o bloco 'Parede' que esse seria a div invisivel que fica mais escura na tela.
// nesse caso a genten precisava acessar elas de alguma forma e com o JS conseguimos manipular algumas coisas por debaixo dos panos.

const buttonosklen = document.querySelector("#buttonOsklen");
const buttonIntimissimi = document.querySelector("#buttonIntimissimi");
const buttonAramis = document.querySelector("#buttonAramis");
const buttonCotton = document.querySelector("#buttonCotton");
const closex = document.querySelector("#closex");
const parede = document.querySelector("#Parede");
const blocoparede = document.querySelector("#BlocoParede");

// const é uma palavra reservada e o nome apos ela poderia ser qualquer um, já o '=document.queryselector', sao palavras reservadas do proprio JS
// que servem para buscar as identificaçoes dentro do HTML, que nomeei entre as ('').


//apos isso criamos uma funçao 'MOSTRAR=()', as funçoes nada mais são do que um espaço do codigo que criamos para trabalhar emcima de alguma coisa
// seja um calculo, ou um evento de somente clicagem como é o nosso caso.
// geralmente a gente cria as funçoes para o codigo nao ficar muito grande; 

const MOSTRA = () => {
    blocoparede.classList.toggle("hide");
    parede.classList.toggle("hide");

}

//dentro dessa fução eu chamei o que eu precisava esconder como a parede e o bloco do popap para somente aparecer quando forem clicados pelo mouse.
// .classList.toggle sao funcoes reservadas do js 

// aqui fiz de uma forma diferente pois como seria tres coisas que teriam o evento de click agrupei elas em um array '[]', e em seguida,
// coloquei um for para que o mesmo percorrece esse array e me entreguasse o evento de click quando alguem clicar nos elementos.
// Em seguida fazer ele executar a função de mostrar o popap e a parede invisivel.

[buttonCotton, buttonAramis, buttonIntimissimi, buttonosklen, closex, blocoparede].forEach((el) => {

    el.addEventListener("click", () => MOSTRA());

});

