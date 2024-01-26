using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.GetUserId
{
    public interface IGetUserId
    {
        public Guid GetUserIdFromHttpContext();
    }
}
