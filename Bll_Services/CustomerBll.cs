using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;
using Dal_Repository.models;
using System.Text.RegularExpressions;

namespace Bll_Services
{
    public class CustomerBll:IBll_Services.IBllCustomer
    {   
        IDal_Repository.IDalCustomer c;
        public CustomerBll(IDal_Repository.IDalCustomer c)
        {
            this.c = c;
        }

        public async Task<CustomerDto> LogIn(string Email)
        {
            List<CustomerDto> customers = await c.SelectAll();

            // סינון הלקוחות לפי המייל
            CustomerDto customer = customers.FirstOrDefault(c => c.Email.Equals(Email, StringComparison.OrdinalIgnoreCase));
            return customer;
        }

        public async Task<CustomerDto> SignIn(CustomerDto customer)
        {
            if (!IsValidEmail(customer.Email) || !IsValidBirthDate(customer.DateBirth) || !IsValidPhoneNumber(customer.Phone) || !IsValidUsername(customer.CustomerName))
                return customer;
            List<CustomerDto> customers= await c.SelectAll();
            // בדיקות תקינות
            if (customers.Any(cu => cu.Email.Equals(customer.Email)))
            {
                return null; // אם יש כבר את המייל במערכת
            }

            int id = await c.Add(customer);
            if (id > 0)
            {
                customer.Id = id;
                return customer;
            }
            return null;
        }

        
        public bool IsValidEmail(string email)
        {
            // בדיקת תקינות אימייל
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public bool IsValidUsername(string username)
        {
            // שם משתמש מכיל רק אותיות עברית, אנגלית ורווחים
            var usernamePattern = @"^[\u0590-\u05FFa-zA-Z\s]+$";
            return Regex.IsMatch(username, usernamePattern);
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // טלפון תקין (9 או 10 ספרות)
            var phonePattern = @"^\d{9,10}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public bool IsValidBirthDate(DateTime birthDate)
        {
            // תאריך לידה תקין (קטן מהיום)
            return birthDate < DateTime.Now;
        }
    }

}

