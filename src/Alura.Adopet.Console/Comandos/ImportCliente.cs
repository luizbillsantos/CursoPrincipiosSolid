using Alura.Adopet.Console.Atributos;
using FluentResults;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import-clientes",
        documentacao: "adopet import-clientes <ARQUIVO> comando que realiza a importação do arquivo de clientes.")]
    public class ImportCliente:IComando
    {
        private readonly IApiService<Cliente> client;

        private readonly ILeitorDeArquivos<Cliente> leitor;

        public ImportCliente(IApiService<Cliente> client, ILeitorDeArquivos<Cliente> leitor)
        {
            this.client = client;
            this.leitor = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDeClientes = leitor.RealizaLeitura();
                foreach (var cliente in listaDeClientes)
                {                       
                   await client.CreateAsync(cliente);               
                }
                return Result.Ok().WithSuccess(new SuccessWithClientes(listaDeClientes, "Importação Realizada com Sucesso!"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}
