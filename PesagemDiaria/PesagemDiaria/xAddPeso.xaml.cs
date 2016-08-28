using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PesagemDiaria
{
    public partial class xAddPeso : ContentPage
    {
        float peso;
        DateTime data;

        public xAddPeso()
        {
            InitializeComponent();
        }

        public void btConfirmaOnClick(Object sender, EventArgs args)
        {
            peso = float.Parse(vPeso.Text.ToString()); 
            if (peso > 300) {
                peso = float.Parse(vPeso.Text.ToString().Replace(",", ".")); 
            }

            data = dpData.Date;

            if (peso > 0)
            {
                Pesagem marcacao = new Pesagem();
                marcacao.data = data;
                marcacao.peso = peso;

                App.Database.SaveItem(marcacao);

                DisplayAlert("Confirmação", "Pesagem salva com sucesso.", "OK");

                base.OnBackButtonPressed();
            }
            else
            {
                DisplayAlert("Erro", "Informe o nome da lista antes de continuar.", "Ok");
            }
        }

        public void onButtonClickedCancelar(Object sender, EventArgs e) {
            base.OnBackButtonPressed();
        }
    }
}
