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
        xViewUltimaMarca ultimaMarca;
        Grid grid;

        public pgMain()
        {
            BackgroundColor = Color.White;
            Title = "Pesagem Diaria";

            ToolbarItems.Add(new ToolbarItem("Marcar", "Plasmid-32.png", async () =>
            {
                await Navigation.PushModalAsync(new xAddPeso());
            }));

            ToolbarItems.Add(new ToolbarItem("Listar","View Details-32.png", async () =>
            {
                await Navigation.PushModalAsync(new xListagem());
            }));

            ToolbarItems.Add(new ToolbarItem("Resultados", "Combo Chart-64.png", async () =>
            {
                await Navigation.PushModalAsync(new xAddPeso());
            }));

            grid = new Grid
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

            atualizaInfo();

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
            ultimaMarca = new xViewUltimaMarca();

            Pesagem pesoAtual = App.Database.retornaUltima();
            Pesagem pesoAntigo = App.Database.retornaLancamento(2);

            grid.Children.Add(new xvVariacoes(" Dia", pesoAtual.peso, pesoAntigo.peso), 0, 0);

            pesoAntigo = App.Database.retornaLancamento(7);
            grid.Children.Add(new xvVariacoes(" Semana", pesoAtual.peso, pesoAntigo.peso), 1, 0);

            pesoAntigo = App.Database.retornaLancamento(30);
            grid.Children.Add(new xvVariacoes(" Mês", pesoAtual.peso, pesoAntigo.peso), 0, 1);

            pesoAntigo = App.Database.retornaPrimeira();
            grid.Children.Add(new xvVariacoes(" Geral", pesoAtual.peso, pesoAntigo.peso), 1, 1);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            atualizaInfo();
        }

    }
}
