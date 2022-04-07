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
    public partial class UserRegisterPage : ContentPage
    {
        UserViewModel viewModel;
        public UserRegisterPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
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

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            bool R = await viewModel.AddUser(TxtUsername.Text.Trim(),
                                             TxtFirstName.Text.Trim(),
                                             TxtLastName.Text.Trim(),
                                             TxtPhoneNumber.Text.Trim(),
                                             TxtPassword.Text.Trim(),
                                             TxtBackUpEmail.Text.Trim(),
                                             TxtJobDescription.Text.Trim());

            if (R)
            {
                await DisplayAlert("Warning", "The user was added correctly in the system!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Something went wrong", "OK");
            }
        }
    }
}