using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class ClienteDoCsv : LeitorDeArquivoCsv<Cliente>
    {
        public ClienteDoCsv(string caminhoDoArquivoASerLido) 
            : base(caminhoDoArquivoASerLido)
        {
        }

        public override Cliente CriarDaLinhaCsv(string linha)
        {
            string[] propriedades = linha.Split(';');
            bool guidValido = Guid.TryParse(propriedades[0], out Guid petId);
            if (!guidValido) throw new ArgumentException("Identificador do cliente inválido!");

            return new Cliente(petId, propriedades[1], propriedades[2]);
        }
    }
}
