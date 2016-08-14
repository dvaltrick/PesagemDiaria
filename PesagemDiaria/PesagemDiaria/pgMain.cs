using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PesagemDiaria
{
    public class pgMain : ContentPage
    {
        public pgMain()
        {
            BackgroundColor = Color.White;
            Title = "Pesagem Diaria";
            
            ToolbarItems.Add(new ToolbarItem("Marcar", "Plasmid-32.png", async () =>
            {
                await Navigation.PushModalAsync(new xAddPeso());
            }));

            xViewUltimaMarca ultimaMarca = new xViewUltimaMarca();

            Grid grid = new Grid
            {
                Padding = new Thickness(0,50,0,0),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                    
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = 170 },
                    new ColumnDefinition { Width = 170 }
                   
                }
            };

            float pesoAtual = 103.4f;
            float pesoAntigo = 104.1f;

            grid.Children.Add(new xvVariacoes(" Dia", pesoAtual, pesoAntigo),0,0);
            grid.Children.Add(new xvVariacoes(" Semana", pesoAtual, pesoAntigo), 1, 0);
            grid.Children.Add(new xvVariacoes(" Mês", pesoAtual, pesoAntigo), 0, 1);
            grid.Children.Add(new xvVariacoes(" Geral", pesoAtual, pesoAntigo), 1, 1);

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    ultimaMarca,
                    grid
                }
            };
        }

        public void atualizaInfo() {

        }
    }
}
