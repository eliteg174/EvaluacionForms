using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluacionForms
{
    public class UserModel
    {
        public String username { get; set; }
        public String password { get; set; }
        public _kmd _Kmd { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public String mail { get; set; }

        public UserModel(String User = "username", String Password = "password", String Name = "name", String Phone = "phone", String Mail = "mail")
        {
            this.username = User;
            this.password = Password;
            this.name = Name;
            this.phone = Phone;
            this.mail = Mail;
        }
    }

    public class _kmd
    {
        public String authtoken { get; set; }
    }
}
