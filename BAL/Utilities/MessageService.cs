using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecuredVault.Business.Utilities
{
    public  class MessageService:IMessageService
    {
        public async Task<bool> SendSms(string toPhoneNumber, string msg)
        {
            await Task.FromResult(0);
            using (var web = new System.Net.WebClient())
            {
                try
                {
                    string userName = "hostel123";
                    string userPassword = "1234567";
                    // string msgRecepient = "9656284838";
                    // string msgText = "This is a demo msg please ignore!";

                    string url2 = "http://198.24.149.4/API/pushsms.aspx?loginID=" + userName + "&password=" + userPassword + "&mobile=" + toPhoneNumber + "&text=" + msg + "&senderid=CHPSMS&route_id=2&Unicode=0";
                    string result = web.DownloadString(url2);

                    if (result.Contains("OK"))
                    {
                        return true;

                    }


                    return false;
                }
                catch (Exception ex)
                {



                }
               
            }

            return true;
        }
    }
}
