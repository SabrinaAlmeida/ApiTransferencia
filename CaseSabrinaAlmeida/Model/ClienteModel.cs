using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CaseSabrinaAlmeida.Model
{
    public record Cliente(int Id, string Nome, Int64 NumeroConta, double SaldoConta);


    public static class ClienteModel
    {
        public static Cliente[] memoryClientes = new Cliente[]
        {
                new Cliente(1,"Sabrina Bastos de Almeida",0001, 10000)
        };

        public static Cliente[] GetClientes()
        {
            return memoryClientes;
        }

        public static Cliente? GetCliente(int id)
        {
            return memoryClientes.FirstOrDefault(a => a.Id == id);
        }

        public static Cliente? GetClientePeloNumeroConta(Int64 numeroConta)
        {
            return memoryClientes.FirstOrDefault(a => a.NumeroConta == numeroConta);
        }

        public static bool UpdateCliente(Cliente cliente)
        {
            memoryClientes = memoryClientes.Select(a => a.Id == cliente.Id ? cliente : a).ToArray();
            return true;
        }

        public static Cliente CreateCliente(Cliente cliente)
        {
            memoryClientes = memoryClientes.Append(cliente).ToArray();
            return cliente;
        }
    }

    [JsonSerializable(typeof(Cliente[]))] // Especificação da rota de serialização - necessário para serializar objetos que serão tranferidos nas APIs
    public partial class ClienteArrayJsonSerializerContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(Cliente))] // Especificação da rota de serialização - necessário para serializar objetos que serão tranferidos nas APIs
    public partial class ClienteJsonSerializerContext : JsonSerializerContext
    {

    }
}
