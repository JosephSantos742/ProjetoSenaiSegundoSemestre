// Funções para trocar os textos com as informações da loja
const textoSobre = document.getElementById('textoSobre').innerHTML;
const textoValores = document.getElementById('textoValores').innerHTML;
const textoEpi = document.getElementById('textoEPI').innerHTML;

function trocarTextoSobre() {
    document.getElementById('textoSobre').innerHTML = textoSobre;
}
function trocarTextoValores() {
    document.getElementById('textoSobre').innerHTML = textoValores;
}
function trocarTextoEPI() {
    document.getElementById('textoSobre').innerHTML = textoEpi;
}


// Configuração do Modal de login 
const openModalButton = document.querySelector("#open-modal");
const closeModalButton = document.querySelector("#close-modal");
const modal = document.querySelector("#modal");
const fade = document.querySelector("#fade");

const toggleModal = () => {
    modal.classList.toggle("hide");
    fade.classList.toggle("hide");
};

[openModalButton, closeModalButton, fade].forEach((el) => {
    el.addEventListener("click", () => toggleModal());
});