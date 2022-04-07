using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnswersAPP_EstebanVasquez.Models;

namespace AnswersAPP_EstebanVasquez.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }
        public Tools.Crypto MyCrypto { get; set; }
        public UserViewModel()
        {
            MyUser = new User();
            MyCrypto = new Tools.Crypto();
        }

        public async Task<bool> AddUser(string pUserName, 
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
                MyUser.UserName = pUserName;
                MyUser.FirstName = pFirstName;
                MyUser.LastName = pLastName;
                MyUser.PhoneNumber = pPhoneNumber;
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pUserPassword);
                MyUser.UserPassword = EncriptedPassword;
                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.JobDescription = pJobDescription;
                MyUser.UserStatusId = pUserStatusID;
                MyUser.CountryId = pCountryID;
                MyUser.UserRoleId = pUserRoleID;
                MyUser.StrikeCount = 0;

                bool R = await MyUser.AddNewUser();

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

        public async Task<bool> ValidateUserAccess(string pEmail, string pPassword)
        {
            if (IsBusy)
            {
                return false;
            }
            IsBusy = true;

            try
            {
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);

                MyUser.UserName = pEmail;
                MyUser.UserPassword = EncriptedPassword;

                bool R = await MyUser.ValidateUserAccess();

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
