using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PesagemDiaria
{
    public partial class xViewUltimaMarca : ContentView
    {
        public xViewUltimaMarca()
        {
            Pesagem ultima = new Pesagem();

            InitializeComponent();

            if (!App.Database.existeLancamento())
            {
                lPeso.Text = " 0.00 Kg";
                lData.Text = " Atualizado em: ";
            }
            else {
                ultima = App.Database.retornaUltima();
                lPeso.Text = " " + String.Format("{0:0.###}", ultima.peso) + " Kg ";
                lData.Text = " " + "Atualizado em: " + ultima.data.ToString("dd/MM/yyyy");  
            }

        }
    }
}
