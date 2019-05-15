using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsWebAPI.Model
{
    public class ClientInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Gender { get; set; }
        public string CellNumber { get; set; }
        public string Title { get; set; }
        public string IdNumber { get; set; }
        public string Roles { get; set; }
        public string Email { get; set; }
    }
}
