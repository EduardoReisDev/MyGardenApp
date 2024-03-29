﻿using MyGarden.Models;
using MyGarden.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPlanta : ContentPage
    {
        List<PlantaLista> Lista { get; set; }

        public ListaPlanta()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ConsultarPlantas();
        }

        public void ConsultarPlantas()
        {
            Database database = new Database();
            Lista = database.ConsultarPL();
            ListaPlantas.ItemsSource = Lista;
            LblCount.Text = Lista.Count.ToString();

            if (Lista.Count > 0)
            {
                EmptyState.IsVisible = false;
                NumberOfPlants.IsVisible = true;
            }
            else
            {
                EmptyState.IsVisible = true;
                NumberOfPlants.IsVisible = false;
            }
        }

        public async void GoCadastro(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ListaPlantaCadastro());
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaPlantas.ItemsSource = Lista.Where(a => a.NomePopularPL.Contains(args.NewTextValue)).ToList();
        }

        async void ExcluirAction(object sender, EventArgs args)
        {
            string action = await DisplayActionSheet("Atenção, você deseja remover essa planta da sua lista?", "Cancel", null, "Sim, quero remover.", "Não");
            if (action == "Sim, quero remover.")
            {
                Image btnExcluir = (Image)sender;
                TapGestureRecognizer tapGest = (TapGestureRecognizer)btnExcluir.GestureRecognizers[0];
                PlantaLista plantalista = tapGest.CommandParameter as PlantaLista;
                Database database = new Database();
                database.ExclusaoPL(plantalista);
                await DisplayAlert("MyGarden", "Parabéns, planta removida com sucesso!", "Ótimo");
                ConsultarPlantas();
            }

            else
            {
                ConsultarPlantas();
            }
        }
    }
}