using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Results;
using FluentResults;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "listclientes",
      documentacao: "adopet listclientes comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class ListClientes: IComando
    {
        private readonly IApiService<Cliente> client;

        public ListClientes(IApiService<Cliente> client)
        {
            this.client = client;
        }

        public Task<Result> ExecutarAsync()
        {
            return this.ListaDadosClientesDaAPIAsync();
        }

        private async Task<Result> ListaDadosClientesDaAPIAsync()
        {
            try
            {
                IEnumerable<Cliente>? clientes = await client.ListAsync();               
                return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem de Clientes realizada com sucesso!"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
            }

        }

    }
}
