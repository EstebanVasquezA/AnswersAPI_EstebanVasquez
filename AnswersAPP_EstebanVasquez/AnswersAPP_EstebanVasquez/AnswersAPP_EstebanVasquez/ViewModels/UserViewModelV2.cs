using AnswersAPP_EstebanVasquez.Models;
using AnswersAPP_EstebanVasquez.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnswersAPP_EstebanVasquez.ViewModels
{
    public class UserViewModelV2 : BaseViewModel
    {
        private string nombreDeUsuario;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string contrasenna;
        private string emailRespaldo;
        private string descripcionTrabajo;
        private int IdRolUsuario;

        public User MiUsuario { get; set; }
        Crypto MiEncriptador { get; set; }
        public Command AgregarUsuarioCommand { get; }
        public string NombreDeUsuario
        {
            get { return nombreDeUsuario; }
            set 
            {
                if (nombreDeUsuario == value)
                {
                    return;
                }
                nombreDeUsuario = value;
                OnPropertyChanged(nameof(NombreDeUsuario));
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre == value)
                {
                    return;
                }
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (apellidos == value)
                {
                    return;
                }
                apellidos = value;
                OnPropertyChanged(nameof(Apellidos));
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (telefono == value)
                {
                    return;
                }
                telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }

        public string Contrasenna
        {
            get { return contrasenna; }
            set
            {
                if (contrasenna == value)
                {
                    return;
                }
                contrasenna = value;
                OnPropertyChanged(nameof(Contrasenna));
            }
        }

        public string EmailRespaldo
        {
            get { return emailRespaldo; }
            set
            {
                if (emailRespaldo == value)
                {
                    return;
                }
                emailRespaldo = value;
                OnPropertyChanged(nameof(EmailRespaldo));
            }
        }

        public string DescripcionTrabajo
        {
            get { return descripcionTrabajo; }
            set
            {
                if (descripcionTrabajo == value)
                {
                    return;
                }
                descripcionTrabajo = value;
                OnPropertyChanged(nameof(DescripcionTrabajo));
            }
        }

        public UserViewModelV2()
        {
            MiUsuario = new User();

            MiEncriptador = new Crypto();

            AgregarUsuarioCommand = new Command(async () => await AgregarUsuario(NombreDeUsuario, Nombre, Apellidos,
                                                                                 Telefono, Contrasenna, EmailRespaldo, 
                                                                                 DescripcionTrabajo, 1, 1, 1));
        }

        public async Task<bool> AgregarUsuario(string pUserName,
                                        string pFirstName,
                                        string pLastName,
                                        string pPhoneNumber,
                                        string pUserPassword,
                                        string pBackUpEmail,
                                        string pJobDescription,
                                        int pUserStatusID = 1,
                                        int pCountryID = 1,
                                        int pUserRoleID = 1)
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiUsuario.UserName = pUserName;
                MiUsuario.FirstName = pFirstName;
                MiUsuario.LastName = pLastName;
                MiUsuario.PhoneNumber = pPhoneNumber;
                string EncriptedPassword = MiEncriptador.EncriptarEnUnSentido(pUserPassword);
                MiUsuario.UserPassword = EncriptedPassword;
                MiUsuario.BackUpEmail = pBackUpEmail;
                MiUsuario.JobDescription = pJobDescription;
                MiUsuario.UserStatusId = pUserStatusID;
                MiUsuario.CountryId = pCountryID;
                MiUsuario.UserRoleId = pUserRoleID;

                MiUsuario.UserRole = null;
                //MiUsuario.UserRole.UserRoleId = pUserRoleID;
                MiUsuario.StrikeCount = 0;

                bool R = await MiUsuario.AddNewUser();

                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
