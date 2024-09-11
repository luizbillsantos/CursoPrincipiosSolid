using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if ((argumentos is null) || (argumentos.Length == 0))
        {
            return null;
        }
        var comando = argumentos[0];
        switch (comando)
        {
            case "import":
                var httpClientPet = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
                if (leitorDeArquivos is null) { return null; }
                return new Import(httpClientPet, leitorDeArquivos);

            case "import-clientes":
                var httpClientCliente = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivosCliente = LeitorDeArquivosFactory.CreateClienteFrom(argumentos[1]);
                if (leitorDeArquivosCliente is null) { return null; }
                return new ImportCliente(httpClientCliente, leitorDeArquivosCliente);

            case "listpets":
                var httpClientPetList = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new List(httpClientPetList);

            case "listclientes":
                var httpClientClienteList = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new ListClientes(httpClientClienteList);

            case "show":
                var leitorDeArquivosShow = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
                if (leitorDeArquivosShow is null) { return null; }
                return new Show(leitorDeArquivosShow);

            case "help":
                var comandoASerExibido = argumentos.Length == 2 ? argumentos[1] : null;
                return new Help(comandoASerExibido);

            default: return null;
        }
    }
}
