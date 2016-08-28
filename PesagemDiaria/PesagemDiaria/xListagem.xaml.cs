using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PesagemDiaria
{
    public partial class xListagem : ContentPage
    {
        ObservableCollection<Pesagem> pesagens = new ObservableCollection<Pesagem>();
        List<Pesagem> lista;

        public xListagem()
        {
            InitializeComponent();

            lvPesagens.ItemsSource = pesagens;

            carregaLista();
        }

        public void carregaLista() {
            lista = App.Database.listagem();

            for (int i = 0; i < lista.Count; i++)
            {
                pesagens.Add(lista[i]);
            }
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            App.Database.DeleteItem((int)mi.CommandParameter);

            //This code is used to fix a bug on ObservableCollection
            //------------------------------------------------------
            while (pesagens.Count > 0) {
                pesagens.RemoveAt(0);
            }
            //------------------------------------------------------

            carregaLista();
        }
    }
}
