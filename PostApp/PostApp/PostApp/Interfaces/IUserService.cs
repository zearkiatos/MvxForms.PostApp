using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();

        User GetUserById(int UserId);
    }
}
