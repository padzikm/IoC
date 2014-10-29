using System;
using Domain;

namespace Database
{
    public class UserRepository : IUserRepository
    {
        public IUser Find(string name)
        {
            var r = new Random(DateTime.Now.Millisecond);

            return new User() {Name = name, Age = r.Next(1, 100)};
        }
    }
}
