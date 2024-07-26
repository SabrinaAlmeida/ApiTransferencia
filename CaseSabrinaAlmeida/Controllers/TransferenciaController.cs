using CaseSabrinaAlmeida.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseSabrinaAlmeida.Controllers
{
    // Essa é a rota que a API será mapeada, ou seja, para acessar a API, a URL será: http://localhost:5000/v1/Transferencia
    // A utilização de v1 é uma forma de versionamento da API 
    [Route("v1/Transferencia")]
    [ApiController]
    public class TransferenciaController : Controller
    {
        public TransferenciaController()
        {
        }

        [HttpGet("{idConta}")]
        public ActionResult GetTransferencias(int idConta)
        {
            var transferencias = HistoricoTransferenciasModel.ListaTransferenciasDaConta(idConta);
            if (transferencias.Length > 0)
            {
                return Ok(transferencias);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult CreateTransferencia(Transferencia novaTransferencia)
        {
            if (novaTransferencia.IdOrigem == novaTransferencia.IdDestino)
                return BadRequest("A conta de origem e destino não podem ser iguais.");

            var clienteOrigem = ClienteModel.GetCliente(novaTransferencia.IdOrigem);
            var clienteDestino = ClienteModel.GetCliente(novaTransferencia.IdDestino);

            if (clienteOrigem is null || clienteDestino is null)
                return NotFound();

            if (clienteOrigem.SaldoConta < novaTransferencia.Valor)
            {
                string mensagemFalha = "Saldo insuficiente. O saldo da conta é menor do que o valor solicitado para a transferência.";
                var historico = new HistoricoTransferencias(novaTransferencia.IdOrigem, novaTransferencia.IdDestino, novaTransferencia.Valor, false, mensagemFalha, DateTime.Now);
                HistoricoTransferenciasModel.CreateTransferencias(historico);

                return BadRequest(mensagemFalha);
            }

            if (novaTransferencia.Valor > 1000)
            {
                string mensagemFalha = "O limite por tranferência é de R$1.000,00.";
                var historico = new HistoricoTransferencias(novaTransferencia.IdOrigem, novaTransferencia.IdDestino, novaTransferencia.Valor, false, mensagemFalha, DateTime.Now);
                HistoricoTransferenciasModel.CreateTransferencias(historico);
                return BadRequest(mensagemFalha);
            }

            clienteOrigem = clienteOrigem with { SaldoConta = clienteOrigem.SaldoConta - novaTransferencia.Valor };
            clienteDestino = clienteDestino with { SaldoConta = clienteDestino.SaldoConta + novaTransferencia.Valor };

            ClienteModel.UpdateCliente(clienteOrigem);
            ClienteModel.UpdateCliente(clienteDestino);

            var resultado = Created($"/Transferencia/{novaTransferencia}", novaTransferencia);

            var historicoTransferencia = new HistoricoTransferencias(novaTransferencia.IdOrigem, novaTransferencia.IdDestino, novaTransferencia.Valor, true, String.Empty, DateTime.Now);
            HistoricoTransferenciasModel.CreateTransferencias(historicoTransferencia);

            return resultado;
        }
    }
}
