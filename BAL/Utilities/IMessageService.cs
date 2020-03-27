
using System.Threading.Tasks;

namespace SecuredVault.Business.Utilities
{
    public interface IMessageService
    {
        Task<bool> SendSms(string toPhoneNumber, string msg);
    }
}
