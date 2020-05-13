using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSUViewEngine.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Users();
        void Create(User user);

        bool ExistsEmail(string email);
    }

    public class UserRepository : IUserRepository
    {
        private List<User> Data = new List<User>() { new User { Id=1, Name = "tamar",Lastname="nasrashvili",Email="tam@gmail.com",Password="123qwerty!" ,PasswordConfirmation="123qwerty!"} };

        public IEnumerable<User> Users()
        {
            return Data.AsEnumerable();
        }

        public void Create(User user)
        {
            var us = Data.OrderBy(x => x.Id).LastOrDefault(); 
            user.Id = us != null ? us.Id + 1 : 1; 
            Data.Add(user);
        }

        public bool ExistsEmail(string email)
        {
            if (Data.Select(x => x.Email).Contains(email))
            {
                return true;
            }
            return false;
        }
    }
}
