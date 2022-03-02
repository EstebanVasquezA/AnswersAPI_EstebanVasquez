using AnswersAPP_EstebanVasquez.ViewModels;
using AnswersAPP_EstebanVasquez.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AnswersAPP_EstebanVasquez
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
