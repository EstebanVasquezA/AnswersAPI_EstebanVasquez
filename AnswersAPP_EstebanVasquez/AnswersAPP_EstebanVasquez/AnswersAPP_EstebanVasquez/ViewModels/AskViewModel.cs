﻿using AnswersAPP_EstebanVasquez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AnswersAPP_EstebanVasquez.ViewModels
{
    public class AskViewModel : BaseViewModel
    {
        public Ask MyQuestion { get; set; }

        public AskViewModel()
        {
            MyQuestion = new Ask();
        }

        public async Task<ObservableCollection<Ask>> GetQList()
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    ObservableCollection<Ask> list = new ObservableCollection<Ask>();

                    list = await MyQuestion.GetQuestionListByUser();

                    if (list == null)
                    {
                        return null;
                    }
                    else
                    {
                        return list;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}
