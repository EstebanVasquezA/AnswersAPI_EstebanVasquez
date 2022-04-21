using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnswersAPP_EstebanVasquez.ViewModels;

namespace AnswersAPP_EstebanVasquez.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyQuestionsPage : ContentPage
    {
        AskViewModel askViewModel;
        public MyQuestionsPage()
        {
            InitializeComponent();
            BindingContext = askViewModel = new AskViewModel();

            askViewModel.MyQuestion.UserId = 8;

            LstMyQuestions.ItemsSource = (System.Collections.IEnumerable)askViewModel.GetQList();
        }
    }
}