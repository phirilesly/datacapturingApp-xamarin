﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCapturing.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CareList : ContentPage
    {
        public CareList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var recipients = await App.Database.GetRecipientsAsync();
                var recieving = recipients.Where(x => x.Status == "Elderly" && x.Status == "Orphan" && x.Status == "Widow").ToList();  
                myCollectionView.ItemsSource = recieving;
            }
            catch
            {

            }


        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new CouncillorDonationList(), true);
            return true;
        }
    }
}