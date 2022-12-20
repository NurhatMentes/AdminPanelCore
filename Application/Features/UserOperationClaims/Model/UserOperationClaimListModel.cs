using Application.Features.UserOperationClaims.Dtos;

namespace Application.Features.UserOperationClaims.Model
{
    public class UserOperationClaimListModel
    {
        public IList<UserOperationClaimListDto> Items { get; set; }
    }
}
