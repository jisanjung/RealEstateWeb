using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary
{
    public class User
    {
        bool _is_verified;
        string _email, _fullName, _password, _type, _address, _securityAnswerOne, _securityAnswerTwo, _securityAnswerThree;

        //constructors
        public User() { }

        public User(bool is_verified, string email, string fullName,
                    string password, string type, string address, string securityAnswerOne,
                    string securityAnswerTwo, string securityAnswerThree)
        {
            _is_verified = is_verified;
            _email = email;
            _fullName = fullName;
            _password = password;
            _type = type;
            _address = address;
            _securityAnswerOne = securityAnswerOne;
            _securityAnswerTwo = securityAnswerTwo;
            _securityAnswerThree = securityAnswerThree;
        }



        //properties
        public bool IsVerified
        {
            get { return _is_verified; }
            set { _is_verified = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string SecurityAnswerOne
        {
            get { return _securityAnswerOne; }
            set { _securityAnswerOne = value; }
        }
        public string SecurityAnswerTwo
        {
            get { return _securityAnswerTwo; }
            set { _securityAnswerTwo = value; }
        }
        public string SecurityAnswerThree
        {
            get { return _securityAnswerThree; }
            set { _securityAnswerThree = value; }
        }


        //class functions
    }
}
