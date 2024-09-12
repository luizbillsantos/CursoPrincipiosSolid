namespace Alura.Adopet.Console.Comandos.Factory
{
    public interface IComandoFactory
    {
        bool ConsegueCriarOTipo(Type tipoComando);
        IComando? CriarComando(string[] args);
    }
}
