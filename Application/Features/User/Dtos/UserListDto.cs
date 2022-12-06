using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Dtos
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool State { get; set; }
    }
}
