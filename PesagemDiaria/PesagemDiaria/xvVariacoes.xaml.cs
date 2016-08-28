using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PesagemDiaria
{
    public partial class xvVariacoes : ContentView
    {
        public xvVariacoes(String tipo, float pesoNovo, float peso)
        {
            float variacao = 0; 

            InitializeComponent();  
             
            lTitulo.Text = tipo;
            lPeso.Text = " " + String.Format("{0:0.###}", peso) + " Kg "; ;

            variacao = (pesoNovo / peso - 1) * 100;

            if (variacao > 0)
            {
                lVar.TextColor = Color.FromHex("#BF360C");
            }
            else {
                lVar.TextColor = Color.FromHex("#64DD17");
            }

            lVar.Text = " " + String.Format("{0:0.00}",variacao) + "%";


        }
    }
}
