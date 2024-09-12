using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Abstracoes;
public interface IApiService<T>
{
    Task CreateAsync(T pet);
    Task<IEnumerable<T>?> ListAsync();
}
