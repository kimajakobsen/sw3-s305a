﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HoplaHelpdesk.Models;
using System.Security.Principal;
using System.Web.Security;
using System.Web.ApplicationServices;

namespace HoplaHelpdesk.Tools
{
    public static class SQLf
    {
        //Function to check if user already got a specific role
        // ConnectionStrinGloabl will connect to the db via Kiel
        private static string connString = Constants.ConnectionString;

        public static Boolean UserIsAlreadyInThatRole(String user, String role)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connString;
            //Preparing SqlCommands
            SqlCommand userId;
            SqlCommand roleId;
            SqlCommand DBroleId;
            //Setting string to something random, for testing later
            String IsItTrue = "2";
            //Finding the userId and roleId
            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            roleId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = '" + role + "')", cn);
            cn.Open();
            //Converting userId and roleId into strings
            String userA;
            String roleA;
            try
            {
                userA = userId.ExecuteScalar().ToString();
                roleA = roleId.ExecuteScalar().ToString();
            }
            catch
            {
                throw;
            }
            //Preparing SqlCommand to check if user already got a specific role
            DBroleId = new SqlCommand("SELECT RoleId FROM aspnet_UsersInRoles WHERE (RoleId = '" + roleA + "') AND (UserId = '" + userA + "')", cn);
            //Running the above SqlCommand in a try catch, since it aint sure that the user already got the specific role
            try
            {
                IsItTrue = DBroleId.ExecuteScalar().ToString();
                cn.Close();
            }
            catch(Exception)
            {
                
                //If the user already got the specific role, IsItTrue and roleA should be the same.
            }

            if (IsItTrue == roleA)
            {
                return true;
            }
            else
            {
                return false;
            }
            

            
        }
        //Adding a user to a specific role
        public static void UserToRole(String user, String role)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connString;
            //Preparing SqlCommands
            SqlCommand userId;
            SqlCommand roleId;
            SqlCommand cmd;
            //Finding the userId and roleId for the specific role and user
          userId = new SqlCommand ("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')" ,cn);
          roleId = new SqlCommand ("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = '" + role + "')" ,cn);


        cn.Open();
            //Converting userId and roleId into a string
        String userA = userId.ExecuteScalar().ToString();
        String roleA = roleId.ExecuteScalar().ToString();
            //Preparing a SqlCommand to create a relation between the user and the role
        cmd = new SqlCommand("INSERT INTO aspnet_UsersInRoles(UserId, RoleId)VALUES('" + userA + "','" + roleA + "')",cn);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        }
        //This function is to check if a specific user is staff
        public static Boolean IsStaff(String user)
        {
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!


            cn.ConnectionString = connString;
            //Preparing SqlCommands
            SqlCommand StaffId;
            SqlCommand UserId;
            SqlCommand DBroleId;
            //Creating a random String for later use when comparing with staffId
            String IsItTrue = "";

            //Gets the UserId and RoleId for user and staff
            UserId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            StaffId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = 'Staff')", cn);

            cn.Open();
            //Making userId and StaffId into strings
            String userA = UserId.ExecuteScalar().ToString();
            String StaffA = StaffId.ExecuteScalar().ToString();
            //Preparing SqlCommand for check if user is staff
            DBroleId = new SqlCommand("SELECT RoleId FROM aspnet_UsersInRoles WHERE (UserId = '" + userA + "') AND (RoleId = '" + StaffA + "')", cn);
            //Running the above SqlCommand in a try catch, since it aint sure that the user got the staff role
            try
            {
                IsItTrue = DBroleId.ExecuteScalar().ToString();
                cn.Close();
            }
            catch
            {
            }

            //If the user got the staff role, IsItTrue and StaffA should be the same

                if (IsItTrue == StaffA)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        //Function to check if the user exists
        public static Boolean DoUserExists(String user){
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!


            cn.ConnectionString = connString;
            //Preparing SqlCommand
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
                //Using try catch to avoid errors if user dont exists
                userA = userId.ExecuteScalar().ToString();
                userB = userId.ExecuteScalar().ToString();
                cn.Close();
            }
            catch (Exception)
            {
                
            }
            
            //The user exists if userA and userB is the same
                if (userA == userB)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
            //Function to remove a role from a user
            public static void UnRole (String user, String role){
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!


            cn.ConnectionString = connString;
            //Preparing SqlCommands
            SqlCommand delete;
            SqlCommand userId;
            SqlCommand roleId;

            //Find the UserId and RoleId based on the provided username and rolename
            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            roleId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = '" + role + "')", cn);

            cn.Open();
            //Converting userId and roleId into Strings.
            String userA = userId.ExecuteScalar().ToString();
            String roleA = roleId.ExecuteScalar().ToString();
           
            //Preparing a SqlCommand to delete the specific user and role relation
            delete = new SqlCommand("DELETE FROM aspnet_UsersInRoles WHERE(RoleId = '" + roleA + "') AND (UserId = '" + userA + "')", cn);
            //Running above SqlCommand in a try catch to make avoid errors if there is no relation between user and role
            try
            {
                delete.ExecuteNonQuery();
                delete.Dispose();
                cn.Close();
            }
            catch
            {
            }
            
        }

        public static List<Role> GetRolesOfUser(string userName)
        {
            List<Role> roles = GetRoles();
            List<Role> result = new List<Role>();
            if (!DoUserExists(userName))
            {
                throw new ArgumentException("No user named " + userName + " exists in aspnet_Users");
            }

            foreach (var role in roles)
            { 
                if(UserIsAlreadyInThatRole(userName,role.Name))
                {
                    result.Add(role);
                }
            }

            //if (result.Count == 0)
            //{
            //    throw new ArgumentException("The user with the name " + userName + " does not have any roles");
            //}

            return result;
        }

        //Function to provide a List of Roles
        public static List<Role> GetRoles()
        {
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!


            cn.ConnectionString = connString;
            SqlCommand getRoles;
            var result = new List<Role>();

            getRoles = new SqlCommand("SELECT RoleName FROM aspnet_Roles", cn);

            try
            {
                cn.Open();
                var temp = getRoles.ExecuteReader();

                while (temp.Read())
                {
                    result.Add(new Role { Name = temp[0].ToString() });
                }
            }
            finally
            {
                cn.Close();
            }

            return result;
        }
        //Function that will be used to create a relation between user and the client role, when registering a new user.
        public static void AddToClient(String user)
        {
            SqlConnection cn = new SqlConnection();
            //Connection ze internet way!


            cn.ConnectionString = connString;
            //Preparing SqlCommands
            SqlCommand userId;
            SqlCommand roleId;
            SqlCommand cmd;

            //Find userId and roleId
            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);
            roleId = new SqlCommand("SELECT RoleId FROM aspnet_Roles WHERE (RoleName = 'client')", cn);


            cn.Open();
            //Converting the userId and roleId into Strings
            String userA = userId.ExecuteScalar().ToString();
            String roleA = roleId.ExecuteScalar().ToString();
            //Creating a relation betweeen user and role client
            cmd = new SqlCommand("INSERT INTO aspnet_UsersInRoles(UserId, RoleId)VALUES('" + userA + "','" + roleA + "')", cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();

        }

        //Function to add a new role
        public static void AddRole(String role, String desription)
        {
             SqlConnection cn = new SqlConnection();
            //Connection ze internet way!


            cn.ConnectionString = connString;
            //Preparing SqlCommand
            SqlCommand cmd;
            SqlCommand AppId;
            if (desription == null)
            {
                desription = "";
            }

            //SqlCommand for getting ApplicationId
            AppId = new SqlCommand("SELECT ApplicationId FROM aspnet_Applications", cn);
            //Executing the SqlCommand
            
            cn.Open();
            //Converting Application into a String
            var Application = AppId.ExecuteScalar();
            
            //Executing add role command
            cmd = new SqlCommand("INSERT INTO aspnet_Roles(ApplicationId, RoleName, LoweredRoleName, Description)VALUES('" + Application + "','" + role + "','" + role.ToLower() + "','" + desription + "')", cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();

        }


        public static void RemoveUserFromAspnet(string userName)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connString;

            //Preparing SqlCommand
            SqlCommand cmd;
            SqlCommand getId;
            string userId;

            
            //Executing the SqlCommand

            cn.Open();
            getId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE UserName='" + userName + "'",cn);
            userId = getId.ExecuteScalar().ToString();
            cmd = new SqlCommand("DELETE FROM aspnet_UsersInRoles WHERE UserId='" + userId + "'", cn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("DELETE FROM aspnet_Membership WHERE UserId='" + userId + "'", cn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("DELETE FROM aspnet_Users WHERE UserId='" + userId + "'", cn);
            if (cmd.ExecuteNonQuery() != 1)
            {
                throw new ArgumentException("A user named '" + userName + "' does not exsist in aspnet_Users");
            }
            cmd.Dispose();
            cn.Close();

        }
        //Function for reseting password for a specific user
        public static String ResetPassword(String user)
        {   
            //Define array for new password
            String[] passarray =
            {
                "a","b","c","d","e","f","g","h","j", "i" ,"k",
                "l","m","n","o","p","q","r","s","t","u",
                "w","x","y","z","A","B","C","D","E","F",
                "G","H","I","J","K","L","M","N","O","P","Q",
                "R","S","T","U","V","W","X","Y","Z",
                "0","1","2","3","4","5","6","7","8","9"
            };

            String setPass = "";
            //Preparing a two randoms, one for password length and one for picking a char from passarray.
            Random RandomNumber = new Random();
            Random RandomPass = new Random();
            int x = RandomNumber.Next(10,25);
            //Putting the passowrd together
            for (int i = 0; i < x; i++)
            {
                int y = RandomPass.Next(passarray.Length);
                setPass += passarray[y].ToString();
            }
            //Finding the user
            MembershipUser u = Membership.GetUser(user);
            //Generating a temporary password for the user
            String np = u.ResetPassword();
            //Changing the password for the user by using the the temporary password as old password
            u.ChangePassword(np, setPass);
            return setPass;

        }
        //Function for finding email for a users
        public static String GetEmail(String user)
        {
            //Connection
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connString;
            
            //Preparing SqlCommand
            SqlCommand userId;
            SqlCommand email;

            //SqlCommand to find UserId
            userId = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" + user + "')", cn);

            //Executing the SqlCommand
            cn.Open();
            String userA = userId.ExecuteScalar().ToString();
            //Using the userId to find the user's email
            email = new SqlCommand("SELECT Email FROM aspnet_Membership WHERE (UserId = '" + userA + "')", cn);
            String emailA = email.ExecuteScalar().ToString();
            
            cn.Close();
            //Returning the email
            return emailA;
            
        }
       
    }

    
}