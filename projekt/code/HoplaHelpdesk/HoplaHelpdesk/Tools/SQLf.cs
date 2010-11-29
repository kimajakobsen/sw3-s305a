using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace HoplaHelpdesk.Tools
{
    public class SQLf
    {

        public Boolean UserIsAlreadyInThatRole(String user, String role)
        {
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!
            //cn.ConnectionString = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            //Connection ze local!
            cn.ConnectionString = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            SqlCommand userId;
            SqlCommand roleId;
            SqlCommand DBroleId;
            
            String IsItTrue = "2";

            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            roleId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = '" + role + "')", cn);
            cn.Open();
            String userA = userId.ExecuteScalar().ToString();
            String roleA = roleId.ExecuteScalar().ToString();
            DBroleId = new SqlCommand("SELECT RoleId FROM aspnet_UsersInRoles WHERE (RoleId = '" + roleA + "') AND (UserId = '" + userA + "')", cn);
            try
            {
                IsItTrue = DBroleId.ExecuteScalar().ToString();
                cn.Close();
            }
            catch(Exception)
            {
                
            }

            if (IsItTrue == roleA)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return roleA;

            
        }

        public void UserToRole(String user, String role)
        {
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!
            //cn.ConnectionString = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            //Connection ze local!
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
        //This method is not done
        public Boolean IsStaff(String user)
        {
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!
            //cn.ConnectionString = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            //Connection ze local!
            cn.ConnectionString = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            SqlCommand Staff;
            SqlCommand User;
            SqlCommand DBroleId;

            User = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            Staff = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = 'Staff')", cn);

            cn.Open();
            String userA = User.ExecuteScalar().ToString();
            String StaffA = Staff.ExecuteScalar().ToString();
            DBroleId = new SqlCommand("SELECT RoleId FROM aspnet_UsersInRoles WHERE (RoleId = '" + StaffA + "') AND (UserId = '" + userA + "')", cn);
            String IsItTrue = DBroleId.ExecuteNonQuery().ToString();
                cn.Close();

                if (IsItTrue == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }

        public Boolean DoUserExists(String user){
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!
            //cn.ConnectionString = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            //Connection ze local!
            cn.ConnectionString = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            SqlCommand userId;
            SqlCommand userN;
            String userA = "0";
            String userB = "1";
            

            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            userN = new SqlCommand("SELECT UserName FROM aspnet_Users WHERE (UserId = '" + userId + "')", cn);
            
            cn.Open();
            try
            {
                userA = userId.ExecuteScalar().ToString();
                userB = userId.ExecuteScalar().ToString();
                cn.Close();
            }
            catch (Exception)
            {
                
            }
            

                if (userA == userB)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public void UnRole (String user, String role){
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!
            //cn.ConnectionString = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            //Connection ze local!
            cn.ConnectionString = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            SqlCommand delete;
            SqlCommand userId;
            SqlCommand roleId;

            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            roleId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = '" + role + "')", cn);

            cn.Open();
            String userA = userId.ExecuteScalar().ToString();
            String roleA = roleId.ExecuteScalar().ToString();

            delete = new SqlCommand("DELETE FROM aspnet_UsersInRoles WHERE(RoleId = '" + roleA + "') AND (UserId = '" + userA + "')", cn);

            delete.ExecuteNonQuery();
            delete.Dispose();
            cn.Close();
        }

    }

}