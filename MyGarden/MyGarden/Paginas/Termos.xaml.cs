﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Termos : ContentPage
    {
        public Termos()
        {
            InitializeComponent();
        }

        public async void GoBemVindo(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Opcoes());
        }
    }
}