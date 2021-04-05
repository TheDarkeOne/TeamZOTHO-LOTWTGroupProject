using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public class ValidateClass
    {
        public Regex RegexItem = new Regex("^[a-zA-Z0-9'., ]*$");
        public Regex RegexUsername = new Regex("^[a-zA-Z0-9_@.$]*$");
        public Regex RegexPassword = new Regex("^[a-zA-Z0-9@$!?]");
        public const int TITLE_SIZE = 50;
        public const int DESCRIPTION_SIZE = 200;

        public bool ValidateStoreItem(StoreItem storeItem)
        {
            if (ValidateString(storeItem.ItemName) && ValidateString(storeItem.Description)) {
                if (ValidateStringSize(storeItem.ItemName, TITLE_SIZE) && ValidateStringSize(storeItem.Description, DESCRIPTION_SIZE)) {
                    if (storeItem.Price > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidateCategory(Category category)
        {
            if (ValidateString(category.Title) && ValidateStringSize(category.Title, TITLE_SIZE)) 
            {
                return true;
            }
            return false;
        }

        public bool ValidateString(string field)
        {
            if (RegexItem.IsMatch(field) && field is not null)
            {
                return true;
            }
            return false;
        }

        public string ToSanitizedString(string field)
        {
            try
            {
                return Regex.Replace(field, @"^[<>/@%^{}()]", "",
                    RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        public bool ValidateStringSize(string field, int size)
        {
            if (field.Length > size || field is null || field.Length < 1)
            {
                return false;
            }
            return true;
        }

        public bool ValidateTransactionQuantity(int quantity)
        {
            if ((quantity < 1) || (quantity > 500))
            {
                return false;
            }
            return true;
        }

        public bool ValidateUsername(string username)
        {
            if (RegexUsername.IsMatch(username) && username is not null && 
                username.Length < 15 && username.Length > 5)
            {
                return true;
            }
            return false;
        }

        public bool ValidatePassword(string password)
        {
            if(RegexPassword.IsMatch(password) && password is not null && password.Length < 30 && password.Length > 5)
            {
                return true;
            }
            return false;
        }
    }
}
