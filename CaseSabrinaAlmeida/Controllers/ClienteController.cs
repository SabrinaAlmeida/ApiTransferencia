using CaseSabrinaAlmeida.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace CaseSabrinaAlmeida.Controllers
{
    // Essa é a rota que a API será mapeada, ou seja, para acessar a API, a URL será: http://localhost:5000/v1/Cliente
    // A utilização de v1 é uma forma de versionamento da API 
    [Route("v1/Cliente")]
    [ApiController]
    public class ClienteController : Controller
    {
        public ClienteController()
        {

        }

        [HttpGet]
        public ActionResult GetClientes()
        {
            var resultado = ClienteModel.GetClientes();
            var retorno = Ok(resultado);

            return retorno;
        }

        [HttpGet("{id}")]
        public ActionResult GetCliente(int id)
        {
            var cliente = ClienteModel.GetCliente(id);
            if (cliente != null)
            {
                return Ok(cliente); 
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult CreateCliente([FromBody] Cliente cliente)
        {
            var clienteExistente = ClienteModel.GetCliente(cliente.Id);
            var clienteNumeroContaExistente = ClienteModel.GetClientePeloNumeroConta(cliente.NumeroConta);
            if (clienteExistente != null)
            {
                if (clienteNumeroContaExistente != null && clienteNumeroContaExistente.Id != cliente.Id)
                    return BadRequest("Já existe um cliente com o número de conta informado.");
                else
                {
                    var atualizado = ClienteModel.UpdateCliente(cliente);
                    return Ok(cliente);
                }
            }
            else
            {
                if (clienteNumeroContaExistente != null)
                    return BadRequest("Já existe um cliente com o número de conta informado.");
                else
                {
                    ClienteModel.CreateCliente(cliente);
                    return Created($"/Cliente/{cliente.Id}", cliente);
                }
            }
        }
    }


}
