using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace AppSK.BLL.Services.Identity
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }
}
