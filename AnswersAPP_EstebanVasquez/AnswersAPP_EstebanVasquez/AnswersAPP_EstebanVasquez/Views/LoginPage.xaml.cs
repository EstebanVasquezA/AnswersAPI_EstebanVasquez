using AnswersAPP_EstebanVasquez.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswersAPP_EstebanVasquez.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserViewModel Vm;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = Vm = new UserViewModel();
        }

        public void CmdSeePassword(object sender, ToggledEventArgs e)
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

        private async void CmdUserRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegisterPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool R = await Vm.ValidateUserAccess(TxtUsername.Text.Trim(), TxtPassword.Text.Trim());
            
            if (R)
            {
                await DisplayAlert("Info", "User Access Granted", "OK");

                //await Navigation.PushAsync(new OptionsPage());
            }
            else
            {
                await DisplayAlert("Error", "Incorrect username or password!", "OK");
                TxtPassword.Focus();
            }
        }
    }
}