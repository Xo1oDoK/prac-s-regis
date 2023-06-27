using prac_s_ergis.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace prac_s_ergis.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository

    {
        public void add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuntheticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var Connection = GetConnection())
            using (var command = new SqlCommand())
            {
                Connection.Open();
                command.Connection = Connection;
                command.CommandText = "select *from  Users where UserName=@username and Password=@password";
                command.Parameters.Add("@username",SqlDbType.NVarChar).Value=credential.UserName;
                command.Parameters.Add("@password",SqlDbType.NVarChar).Value=credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }


                return validUser;


        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user=null;
            using (var Connection = GetConnection())
            using (var command = new SqlCommand())
            {
                Connection.Open();
                command.Connection = Connection;
                command.CommandText = "select *from Users where username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                
              using(var reader=command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            UserName = reader[1].ToString(),

                        };
                     }
                }
            }


            return user;
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
 