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
const openModalLogin = document.querySelector("#open-modal-login");
const closeModalLogin = document.querySelector("#close-modal-login");
const modalLogin = document.querySelector("#modal-login");
const fadeLogin = document.querySelector("#fade-login");

const toggleModalLogin = () => {
    modalLogin.classList.toggle("hide");
    fadeLogin.classList.toggle("hide");
};

[openModalLogin, closeModalLogin, fadeLogin].forEach((el) => {
    el.addEventListener("click", () => toggleModalLogin());
});

// Configuração do Modal de cadastro
const openModalCadastro = document.querySelector("#open-modal-cadastro");
const closeModalCadastro = document.querySelector("#close-modal-cadastro");
const modalCadastro = document.querySelector("#modal-cadastro");
const fadeCadastro = document.querySelector("#fade-cadastro");

const toggleModalCadastro = () => {
    modalCadastro.classList.toggle("hide");
    fadeCadastro.classList.toggle("hide");
};

[openModalCadastro, closeModalCadastro, fadeCadastro].forEach((el) => {
    el.addEventListener("click", () => toggleModalCadastro());
});

// Consumindo API do ViaCep para preencher campos de endereço automático

    // Função para limpar os campos do formulário
const limparFormulario = (endereco) => {
    document.getElementById('logradouro').value = '';
    document.getElementById('numero').value = '';
    document.getElementById('complemento').value = '';
    document.getElementById('bairro').value = '';
    document.getElementById('cidade').value = '';
}

    // Função para preencher os campos caso o cep seja válido
const preencherFormulario = (endereco) => {
    document.getElementById('logradouro').value = endereco.logradouro;
    document.getElementById('complemento').value = endereco.complemento;
    document.getElementById('bairro').value = endereco.bairro;
    document.getElementById('cidade').value = endereco.localidade;
}

    // Expressões regulares para permitir somente numeros de 0 a 9
const eNumero = (numero) => /^[0-9]+$/
const cepValido = (cep) => cep.length == 8 && eNumero(cep);

const pesquisaCep = async () => {
    limparFormulario();
    const cep = document.getElementById('cep').value;
    // Passando um cep para a api do VIACEP, caso for valido vai retornar um json com os dados
    const url = `https://viacep.com.br/ws/${cep}/json/`;

    if (cepValido(cep)) {
        const dados = await fetch(url);
        const endereco = await dados.json();

        if (endereco.hasOwnProperty('erro')) {
            document.getElementById('logradouro').value = 'CEP não encontrado'
        } else {
            preencherFormulario(endereco)
        }
    } else {
        document.getElementById('logradouro').value = 'CEP incorreto'
    }
}

document.getElementById('cep').addEventListener('focusout', pesquisaCep);