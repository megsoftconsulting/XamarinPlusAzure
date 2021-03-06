﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasesDeDatos.Models;
using BasesDeDatos.Views;
using Xamarin.Forms;

namespace BasesDeDatos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var items = await App.Database.GetTodoItems();
            lstListOfItems.ItemsSource = items;
       }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CreateTodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = e.SelectedItem as TodoItem;
                await Navigation.PushAsync(new CreateTodoItemPage
                {
                    BindingContext = lstListOfItems.SelectedItem as TodoItem
                });
            }
        }
    }
}
