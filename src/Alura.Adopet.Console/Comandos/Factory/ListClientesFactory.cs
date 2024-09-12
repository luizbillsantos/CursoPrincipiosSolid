using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.Factory
{
    public class ListClientesFactory : IComandoFactory
    {

        public bool ConsegueCriarOTipo(Type tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            var httpClientList = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
            return new ListClientes(httpClientList);
        }
    }
}
