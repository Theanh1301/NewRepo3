using Shopee.Data;

namespace Shopee.Responsitories
{
    public interface IAccountResponsitory
    {
        public Task<string> SignInAsync(UserModel user); 
    }
}
