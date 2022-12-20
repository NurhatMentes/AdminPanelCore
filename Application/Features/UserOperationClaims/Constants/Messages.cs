using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Constants
{
    public class Messages
    {
        public static string UserCanNotBeDuplicatedWhenInserted = "Bu Kullanıcı da rol (yetki) mevcut.";
        public static string ClaimShouldExistWhenRequested = "Böyle bir rol (yetki) mevcut değil.";
        public static string UserShouldExistWhenRequested = "Böyle bir kullanıcı mevcut değil.";
    }
}