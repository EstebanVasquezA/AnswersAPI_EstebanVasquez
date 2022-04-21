using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AnswersAPP_EstebanVasquez.Models
{
    public class Ask
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentType = "Content-Type";
        public Ask()
        {
            Answers = new HashSet<Answer>();
        }

        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Ask1 { get; set; }
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string ImageUrl { get; set; }
        public string AskDetail { get; set; }

        public virtual AskStatus AskStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

        public async Task<ObservableCollection<Ask>> GetQuestionListByUser()
        {
            try
            {
                string RouteSufix = string.Format("Users/GetQuestionsListByUserID?pUserID={0}",
                                                   this.UserId);
                string FinalApiRoute = CnnToAPI.ProductionRoute + RouteSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                var response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Ask>>(response.Content);

                if (statusCode == HttpStatusCode.OK)
                {
                    return QList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }
    }
}
