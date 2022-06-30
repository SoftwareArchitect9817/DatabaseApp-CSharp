using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senaka.lib
{
    public class Data_user
    {
        public Data_user(int id,string first_name, string last_name, string username, string password, string email_1, string email_2, string phone, string permissions_search, string permissions_menu, string glassDelete, string frameDelete)
        {
            Id = id;
            First_Name = first_name;
            Last_Name = last_name;
            Username = username;
            Password = password;
            Email_1 = email_1;
            Email_2 = email_2;
            Phone = phone;
            Permissions_Search = permissions_search;
            Permissions_Menu = permissions_menu;
            GlassDelete = glassDelete;
            FrameDelete = frameDelete;

        }
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email_1 { get; set; }
        public string Email_2 { get; set; }
        public string Phone { get; set; }
        public string Permissions_Search { get; set; }
        public string Permissions_Menu { get; set; }
        public string GlassDelete { get; set; }
        public string FrameDelete { get; set; }


    }
}
