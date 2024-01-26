using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Business.GetUserId
{
    public class GetUserId : IGetUserId
    {
        private IHttpContextAccessor _httpContextAccessor;

        public GetUserId()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public Guid GetUserIdFromHttpContext()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("Kullanıcı kimliği alınamadı.");
            }

            if (Guid.TryParse(userId, out Guid result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı kimliği geçerli bir GUID değil.");
            }
        }
    }
}
