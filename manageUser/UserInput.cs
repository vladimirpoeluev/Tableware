using System;
using System.Configuration;
using DataManagementTools;
using System.Data.SqlClient;
namespace Tableware
{
    static class UserInput
    {
        public static User User { get; private set; }

        public static bool UserAuthentication(string login, string password)
        {
            ManageData manageData = new ManageData();
            SqlDataReader reader = manageData.SqlRequestReader($"select * from [User] where Login = '{login}' and Password = '{password}'");
            if(reader.Read())
            {
                User = new User();
                User.UserId = (int)reader["UserID"];
                User.UserSurname = (string)reader["Surname"];
                User.UserName = (string)reader["Name"];
                User.UserPatronymic = (string)reader["Patronymic"];
                User.IDRole = (int)reader["UserRole"];
                return true;
            }
            return false;
        }
        
    }
}
