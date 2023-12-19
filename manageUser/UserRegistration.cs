using DataManagementTools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware
{
    public static class UserRegistration
    {
        public static bool Registration(User user, string login, string password)
        {
            ManageData manageData = new ManageData();

            SqlDataReader reader = manageData.SqlRequestReader($"select Login from [User] where Login = '{login}'");

            if (reader.HasRows)
            {
                return false;
            }
            manageData = new ManageData();
            manageData.SqlRequest($"insert into [User](Surname, Name, Patronymic, Login, Password, UserRole) " +
                                  $"values(N'{user.UserSurname}', N'{user.UserName}', N'{user.UserPatronymic}', N'{login.ToLower()}', N'{password}', {user.IDRole})");
            return true;
        }
    }
}
