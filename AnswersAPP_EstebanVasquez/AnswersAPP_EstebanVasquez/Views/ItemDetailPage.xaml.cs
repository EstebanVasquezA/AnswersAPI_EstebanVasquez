using AnswersAPP_EstebanVasquez.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AnswersAPP_EstebanVasquez.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}