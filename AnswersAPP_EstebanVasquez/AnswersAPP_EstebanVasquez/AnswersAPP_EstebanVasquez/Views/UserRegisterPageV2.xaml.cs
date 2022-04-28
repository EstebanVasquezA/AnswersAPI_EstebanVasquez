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
    public partial class UserRegisterPageV2 : ContentPage
    {
        public UserRegisterPageV2()
        {
            InitializeComponent();

            BindingContext = new UserViewModelV2();
        }

        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            if (SwSeePassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }
    }
}