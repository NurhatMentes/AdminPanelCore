using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Constants
{
    public class Messages
    {
        public static string MailCanNotBeDuplicatedWhenInserted = "Bu E-Posta mevcut.";
        public static string ShouldExistWhenRequested = "İstenen kullanıcı mevcut değil değil.";
        public static string WrongInformation = "E-posta veya şifre yanlış lütfen tekrar kontrol edin.";
    }
}