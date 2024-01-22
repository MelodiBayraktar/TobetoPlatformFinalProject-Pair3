using Core.DataAccess.Repositories;
using Core.Entities.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes;

public class EfUserDal : EfRepositoryBase<User, Guid, TobetoPlatformContext>, IUserDal
{
    public EfUserDal(TobetoPlatformContext context) : base(context)
    {
      
    }

    // public async Task<List<OperationClaim>> GetClaims(User user)
    // {
    //     var result = from operationClaim in Context.OperationClaims
    //         join userOperationClaim in Context.UserOperationClaims
    //             on operationClaim.Id equals userOperationClaim.OperationClaimId
    //         where userOperationClaim.UserId == user.Id
    //         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
    //     return await result.ToListAsync();//bu kısım farklı?
    // }
    // public List<IOperationClaim> GetClaims(IUser user)
    // {
    //     using (_context)
    //     {
    //         var result = from operationClaim in _context.OperationClaims
    //                      join userOperationClaim in _context.UserOperationClaims
    //                          on operationClaim.Id equals userOperationClaim.OperationClaimId
    //                      //where userOperationClaim.UserId == user.Id burayı mecburen boxing yaptım.
    //                      where userOperationClaim.UserId == ((User)user).Id
    //                      select (IOperationClaim)(new OperationClaim
    //                      {
    //                          Id = operationClaim.Id,
    //                          Name = operationClaim.Name
    //                      });
    //
    //         return result.ToList();
    //     }
    // }
    
    public List<IOperationClaim> GetClaims(IUser user)
    {
     
        
            var result = from operationClaim in Context.OperationClaims
                join userOperationClaim in Context.UserOperationClaims
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
          
                where userOperationClaim.UserId == ((User)user).Id
                select (IOperationClaim)(new OperationClaim
                {
                    Id = operationClaim.Id,
                    Name = operationClaim.Name
                });

            return  result.ToList();
        
    }
}

