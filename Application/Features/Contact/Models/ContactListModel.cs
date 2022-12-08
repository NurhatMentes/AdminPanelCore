using Application.Features.Slider.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Contact.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Contact.Models
{
    public class ContactListModel: BasePageableModel
    {
        public IList<ContactListDto> Items { get; set; }
    }
}
