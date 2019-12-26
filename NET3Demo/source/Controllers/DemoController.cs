using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NET3Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    #nullable enable
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            //
            //C#8 - Teste para habilitar null no string, sem warning
            string? arg = null;
            var mensagem = "teste " + arg;

            //
            //C#8 - Skip
            var lista = new List<Cliente>();
            lista.Add(new Cliente() { Nome = "João" });
            lista.Add(new Cliente() { Nome = "Pedro" });
            var resultado = SliceArray(lista.ToArray());

            //
            //C#8 - Swicth Expression
            string? nome = "Pedro";
            string? sobrenome = "Silva";
            var resSwitch = (nome, sobrenome) switch
            {
                (string n, string s) => $"{n} {s}",
                (string n, null) => n,
                (null, string s) => $"Sr. {s}",
                (null, null) => "Desconhecido"
            };
            var resSwitch2 = nome switch
            {
                ("Pedro") => "S",
                ("João") => "N",
                _ => "Desconhecido"
            };

            //C#8 Funções locais
            int y;
            LocalFunction();
            var LF = y;
            void LocalFunction() => y = 0;


            return View();
        }
        static IEnumerable<Cliente> SliceArray(Cliente[] clientes)
        {
            var novaLista = new List<Cliente>();
            foreach (var item in clientes[1..2])
            {
                novaLista.Add(item);
            }
            return novaLista;
        }
    }

#nullable enable
    public class Cliente
    {
        public string? Nome { get; set; }
    }
}
