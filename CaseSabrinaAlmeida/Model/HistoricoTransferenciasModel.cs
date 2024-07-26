using System.Text.Json.Serialization;

namespace CaseSabrinaAlmeida.Model
{

    public record HistoricoTransferencias(int IdOrigem, int IdDestino, double Valor, bool Concluida, string MotivoFalha, DateTime Data);

    public class Transferencia
    {
        public int IdOrigem { get; set; }
        public int IdDestino { get; set; }
        public double Valor { get; set; }
    }
    public static class HistoricoTransferenciasModel
    {
        private static HistoricoTransferencias[] memoryTranferencias = new HistoricoTransferencias[] { };

        public static HistoricoTransferencias[] GetTransferencias()
        {
            return memoryTranferencias;
        }


        public static HistoricoTransferencias CreateTransferencias(HistoricoTransferencias transferencias)
        {
            memoryTranferencias = memoryTranferencias.Append(transferencias).ToArray();
            return transferencias;
        }


        public static HistoricoTransferencias[] ListaTransferenciasDaConta(int idConta)
        {
            return memoryTranferencias.Where(a => a.IdOrigem == idConta || a.IdDestino == idConta).OrderByDescending(a => a.Data).ToArray();
        }
    }

    [JsonSerializable(typeof(Transferencia[]))] // Especificação da rota de serialização - necessário para serializar objetos que serão tranferidos nas APIs
    public partial class TransferenciaJsonSerializerContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(HistoricoTransferencias[]))] // Especificação da rota de serialização - necessário para serializar objetos que serão tranferidos nas APIs
    public partial class HistoricoTransferenciasJsonSerializerContext : JsonSerializerContext
    {

    }
}
