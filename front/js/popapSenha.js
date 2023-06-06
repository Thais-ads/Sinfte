const openmodal = document.querySelector("#open");
const input = document.querySelector('input_form')

const fade = document.querySelector("#fade");
const modal = document.querySelector("#modal");


const MOSTRAR = () => {
    modal.classList.toggle("hide");
    fade.classList.toggle("hide");
}


[openmodal, fade].forEach((el) => {



    el.addEventListener("click", () => MOSTRAR());



});

