namespace TestSwaggerSorteio.Models
{
    public class ListaNumerosSorteados
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public List<NumeroSorteado> ListaNumeros { get; set; } = new List<NumeroSorteado>();
        public ListaNumerosSorteados()
        {
        }
    }
}
