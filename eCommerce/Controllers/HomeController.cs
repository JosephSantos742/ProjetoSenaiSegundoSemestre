using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Cliente cliente = new Cliente();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Recebendo os valores da View e passando eles para o Model através do metodo de inserir
        [HttpPost]
        public IActionResult Salvar(string nome, int cpf, string email, string senha, int cep, string logradouro,
            int numero, string complemento, string bairro, string cidade)
        {
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.Email = email;
            cliente.Senha = senha;
            cliente.Cep = cep;
            cliente.Logradouro = logradouro;
            cliente.Numero = numero;
            cliente.Complemento = complemento;
            cliente.Bairro = bairro;
            cliente.Cidade = cidade;
            cliente.Inserir();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
