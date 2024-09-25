using System.Collections.Generic;
using TestSwaggerSorteio.Models;

namespace TestSwaggerSorteio.Data
{
    public class SorteioData
    {
        private static SorteioData sorteioData { get; set; } = new SorteioData();
        private static int Id { get; set; } = 0;
        private static int NumeroDoSorteio { get; set; } = 0;
        public static List<Sorteios> ListaSorteios { get; set; } = new List<Sorteios>();
        private List<ListaNumerosSorteados> ? ListaNumeros { get; set; }
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
            sorteio.ListaNumeros.Add(new NumeroSorteado(sorteio.Id, (new Random()).Next(10000, 999999)));

            if (firstTime || sorteioData.ListaNumeros == null)
            {
                sorteioData.ListaNumeros = new List<ListaNumerosSorteados>();
                sorteioData.QtdeNumerosSorteados = 0;
            }

            ++sorteioData.QtdeNumerosSorteados;

            sorteioData.ListaNumeros.Add(sorteio);

            Sorteios sorteios = new Sorteios();

            sorteios.ListaSorteios = sorteioData.ListaNumeros;
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
        public List<Sorteios> ClearAll(int numeroSorteio = 0)
        {
            if (numeroSorteio == 0)
                ListaSorteios.Clear();
                else
                    ListaSorteios.RemoveAt(ListaSorteios.FindIndex(s => s.NumeroDoSorteio == numeroSorteio));
            return ListaSorteios;
        }
    }
}
