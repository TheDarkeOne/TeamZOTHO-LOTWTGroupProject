using System;
using System.Collections.Generic;
using System.Text;

namespace TeamZ.Shared
{
    public class StoreUser
    {
        private ReadOnce readOnce = new ReadOnce();

        public int Id { get; set; }
        public bool Admin { get; set; } = false;
        public string Username { get; set; }
        public string Password
        {
            get { return readOnce.Value; }
            set { readOnce.Value = value; }
        }
        public string Salt { get; set; }
        public string SessionKey { get; set; }
        public DateTime LastLoginTime { get; set; }

        public StoreUser(bool admin, string username)
        {
            this.Admin = admin;
            this.Username = username;
        }
    }

    public class ReadOnce
    {
        //private bool set;
        private string value;

        public String Value
        {
            get { return value; }
            set
            {
                //if (set) throw new AlreadySetException(value);
                //set = true;
                this.value = value;
            }
        }
    }

    public class NamedValueException : InvalidOperationException
    {
        private readonly string valueName;

        public NamedValueException(string valueName, string messageFormat)
            : base(string.Format(messageFormat, valueName))
        {
            this.valueName = valueName;
        }

        public string ValueName
        {
            get { return valueName; }
        }
    }

    public class AlreadySetException : NamedValueException
    {
        private const string MESSAGE = "The value \"{0}\" has already been set.";

        public AlreadySetException(string valueName)
            : base(valueName, MESSAGE)
        {
        }
    }
}
