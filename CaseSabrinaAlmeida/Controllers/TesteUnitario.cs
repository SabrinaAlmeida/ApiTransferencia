using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CaseSabrinaAlmeida.Model;
using Microsoft.AspNetCore.Mvc;

namespace CaseSabrinaAlmeida.Controllers
{
    public class TesteUnitario : Controller
    {
        private readonly HttpClient _httpClient;

        public TesteUnitario(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {

            // Teste das APIs do ClienteController
            await TestarAPIsCliente();

            // Teste das APIs do TransferenciaController
            await TestarAPIsTransferencia();

            return View();
        }

        private async Task TestarAPIsCliente()
        {
            try
            {
                // Teste da API GetClientes
                var response = await _httpClient.GetAsync("http://localhost:5000/v1/Cliente");
                response.EnsureSuccessStatusCode();
                var clientes = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Teste da API GetClientes concluido");
                if (clientes != null)
                    Console.WriteLine(clientes);
                else
                    Console.WriteLine("Nenhum cliente encontrado");


                // Teste da API GetCliente pelo id
                response = await _httpClient.GetAsync("http://localhost:5000/v1/Cliente/1");
                response.EnsureSuccessStatusCode();
                var cliente = await response.Content.ReadAsStringAsync(); 
                Console.WriteLine("Teste da API GetClientes pelo Id concluido");
                if (cliente != null)
                    Console.WriteLine(cliente);
                else
                    Console.WriteLine("Nenhum cliente encontrado");


                // Teste da API CreateCliente
                var novoCliente = new Cliente(2, "Cliente Novo", 2, 5000);
                var optionsCliente = new JsonSerializerOptions { TypeInfoResolver = new ClienteArrayJsonSerializerContext() };
                var novoClienteJson = new StringContent(JsonSerializer.Serialize(novoCliente, optionsCliente), Encoding.UTF8, "application/json");
                response = await _httpClient.PostAsync("http://localhost:5000/v1/Cliente", novoClienteJson);
                response.EnsureSuccessStatusCode();
                cliente = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Teste da API CreateCliente concluido");
                if (cliente != null)
                    Console.WriteLine(cliente);
                else
                    Console.WriteLine("Nenhum cliente encontrado");

                // Teste da API CreateCliente realizando update
                var clienteAtualizado = new Cliente(2, "Cliente Atualizado", 2, 5000);
                var clienteAtualizadoJson = new StringContent(JsonSerializer.Serialize(clienteAtualizado, optionsCliente), Encoding.UTF8, "application/json");
                response = await _httpClient.PostAsync($"http://localhost:5000/v1/Cliente/", clienteAtualizadoJson);
                response.EnsureSuccessStatusCode();
                cliente = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Teste da API CreateCliente (update) concluido");
                if (cliente != null)
                    Console.WriteLine(cliente);
                else
                    Console.WriteLine("Nenhum cliente encontrado");

            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro no teste das APIs de Cliente: " + erro.Message);
            }
        }

        private async Task TestarAPIsTransferencia()
        {
            try
            {
                // Teste da API CreateTransferencia
                var novaTransferencia = new Transferencia { IdOrigem = 1, IdDestino = 2, Valor = 100 };
                var optionsTransferencia = new JsonSerializerOptions { TypeInfoResolver = new TransferenciaJsonSerializerContext() };
                var novaTransferenciaJson = new StringContent(JsonSerializer.Serialize(novaTransferencia, optionsTransferencia), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:5000/v1/Transferencia", novaTransferenciaJson);
                response.EnsureSuccessStatusCode();
                var transferencia = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Teste da API CreateTransferencia concluido");
                if (transferencia != null)
                    Console.WriteLine(transferencia);


                // Teste da API GetTransferencia pelo Id da Conta
                response = await _httpClient.GetAsync("http://localhost:5000/v1/Transferencia/1");
                response.EnsureSuccessStatusCode();
                transferencia = await response.Content.ReadAsStringAsync();
                if (transferencia != null)
                    Console.WriteLine(transferencia);
                else
                    Console.WriteLine("Nenhuma transferencia encontrada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro no teste das APIs de Cliente: " + erro.Message);
            }
        }
    }
}
