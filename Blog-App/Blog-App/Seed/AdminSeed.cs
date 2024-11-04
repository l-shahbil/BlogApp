using Blog_App.Models;
using Blog_App.Repository.Base;

namespace Blog_App.Seed
{
    public class AdminSeed
    {
        private readonly IRepository<user> _repoUser;

        public AdminSeed(IRepository<user>repoUser) 
        {
            _repoUser = repoUser;
        }

        public async Task seed() 
        {
            
                bool IsExist = (await _repoUser.GetAllAsync()).Any();
                if (IsExist == false)
                {
                    user user = new user();
                    user.Id = Guid.NewGuid().ToString();
                    user.Name = "Laith Asad Bin Shahbil";
                    user.Email = "laith@l.com";
                    user.Password = "password";
                    await _repoUser.AddAsync(user);
                }
        }
    }
}
