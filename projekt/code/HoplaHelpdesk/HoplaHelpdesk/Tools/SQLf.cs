using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace HoplaHelpdesk.Tools
{
    public class SQLf
    {
        public void UserToRole(String user, String role)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            SqlCommand userId;
            SqlCommand roleId;
            SqlCommand cmd;

          userId = new SqlCommand ("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')" ,cn);
          roleId = new SqlCommand ("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = '" + role + "')" ,cn);


        cn.Open();
        String userA = userId.ExecuteScalar().ToString();
        String roleA = roleId.ExecuteScalar().ToString();
        cmd = new SqlCommand("INSERT INTO aspnet_UsersInRoles(UserId, RoleId)VALUES('" + userA + "','" + roleA + "')",cn);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        }

    }
}