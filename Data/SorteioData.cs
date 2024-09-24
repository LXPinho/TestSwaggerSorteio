using TestSwaggerSorteio.Models;

namespace TestSwaggerSorteio.Data
{
    public class SorteioData
    {
        private static SorteioData sorteioData { get; set; } = new SorteioData();
        private static int Id { get; set; } = 0;
        private static int NumeroDoSorteio { get; set; } = 0;
        public static List<Sorteios> ListaSorteios { get; set; } = new List<Sorteios>();
        private List<ListaNumerosSorteados> ? ListaSorteio { get; set; }
        private int QtdeNumerosSorteados { get; set; } = 0; 
        public static SorteioData getInstance()
        {
            sorteioData.addNumeroDoSorteio();
            return sorteioData;
        }
        public static void AddSorteioData(bool firstTime, int vibesAcumuladas) 
        {
            if (sorteioData == null)
                sorteioData = getInstance();

            ListaNumerosSorteados sorteio = new ListaNumerosSorteados();
            sorteio.Data = DateTime.Now;
            sorteio.Id = ++Id;
            sorteio.listaNumerosSorteados.Add(new NumeroSorteado(sorteio.Id, (new Random()).Next(10000, 999999)));

            if (firstTime || sorteioData.ListaSorteio == null)
            {
                sorteioData.ListaSorteio = new List<ListaNumerosSorteados>();
                sorteioData.QtdeNumerosSorteados = 0;
            }

            ++sorteioData.QtdeNumerosSorteados;

            sorteioData.ListaSorteio.Add(sorteio);

            Sorteios sorteios = new Sorteios();

            sorteios.ListaSorteios = sorteioData.ListaSorteio;
            sorteios.NumeroDoSorteio = NumeroDoSorteio;
            sorteios.QtdeNumerosSorteados = sorteioData.QtdeNumerosSorteados;

            sorteios.Texto = File.ReadAllText("Data\\htmlpage1.html");
            sorteios.VibesAculumadas += vibesAcumuladas;


            if (firstTime)
            {
                ListaSorteios.Add(sorteios);
            }
            else
            {
                ListaSorteios.Last().ListaSorteios = sorteios.ListaSorteios;
                ListaSorteios.Last().NumeroDoSorteio = sorteios.NumeroDoSorteio;
                ListaSorteios.Last().QtdeNumerosSorteados = sorteioData.QtdeNumerosSorteados; ;
            }
        }
        public List<Sorteios> getListSorteios()
        {
            return ListaSorteios;
        }
        private void addNumeroDoSorteio()
        {
            NumeroDoSorteio++;
        }
    }
}
