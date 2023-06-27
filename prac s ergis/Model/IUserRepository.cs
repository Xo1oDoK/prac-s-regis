using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace prac_s_ergis.Model
{
   public  interface IUserRepository
    {
        bool AuntheticateUser(NetworkCredential credential);
        void add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int Id);

        UserModel GetById(int Id);
        UserModel GetByUsername (string username);
        IEnumerable<UserModel> GetAll();



    }
}
