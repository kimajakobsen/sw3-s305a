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
            SqlCommand StaffId;
            SqlCommand UserId;
            SqlCommand DBroleId;
            String IsItTrue = "";

            //Gets the UserId and RoleId for staff
            UserId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            StaffId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = 'Staff')", cn);

            cn.Open();
            //Making userId and StaffId to strings
            String userA = UserId.ExecuteScalar().ToString();
            String StaffA = StaffId.ExecuteScalar().ToString();
            DBroleId = new SqlCommand("SELECT RoleId FROM aspnet_UsersInRoles WHERE (UserId = '" + userA + "') AND (RoleId = '" + StaffA + "')", cn);

            try
            {
                IsItTrue = DBroleId.ExecuteScalar().ToString();
                cn.Close();
            }
            catch
            {
            }

                if (IsItTrue == StaffA)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public Boolean DoUserExists(String user){
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!
            //cn.ConnectionString = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            //Connection ze local!
            cn.ConnectionString = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            SqlCommand userId;
            //Creating two strings with diffrend values, so it is possible to compare later
            String userA = "0";
            String userB = "1";
            
            //SQLcommand for userId for input UserName
            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            
            cn.Open();
            try
            {
                //I try to assign userA and userB with new values
                //If user exists userA and userB will have the same value
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

            //Find the UserId and RoleId
            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            roleId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = '" + role + "')", cn);

            cn.Open();
            String userA = userId.ExecuteScalar().ToString();
            String roleA = roleId.ExecuteScalar().ToString();
            try
            {
                delete = new SqlCommand("DELETE FROM aspnet_UsersInRoles WHERE(RoleId = '" + roleA + "') AND (UserId = '" + userA + "')", cn);
                delete.ExecuteNonQuery();
                delete.Dispose();
                cn.Close();
            }
            catch
            {
            }
            
        }

        public void AddToClient(String user)
        {
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!
            //cn.ConnectionString = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            //Connection ze local!
            cn.ConnectionString = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
            SqlCommand userId;
            SqlCommand roleId;
            SqlCommand cmd;

            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            roleId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = 'client')", cn);


            cn.Open();
            String userA = userId.ExecuteScalar().ToString();
            String roleA = roleId.ExecuteScalar().ToString();
            cmd = new SqlCommand("INSERT INTO aspnet_UsersInRoles(UserId, RoleId)VALUES('" + userA + "','" + roleA + "')", cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();

        }

    }

}