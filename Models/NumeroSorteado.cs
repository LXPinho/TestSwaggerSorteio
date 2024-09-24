using System.Security.Cryptography.X509Certificates;

namespace TestSwaggerSorteio.Models
{
    public class NumeroSorteado
    {
        public int IdSorteio { get; set; }
        public int Numero { get; set; }
        public NumeroSorteado( int idSorteio, int numero)
        {
            IdSorteio = idSorteio;
            Numero = numero;
        }
    }
}
