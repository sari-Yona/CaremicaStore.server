using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll_Services;
using System.Net.Mail;
using System.Net;
using System.Net;
using System.Net.Mail;

namespace Bll_Services
{
    public class ShoppingBll : IBll_Services.IBllShopping
    {
        IDal_Repository.IDalShopping sh;
        IDal_Repository.IDalShoppingDetail sd;
        IDal_Repository.IDalProduct p;
        IDal_Repository.IDalCustomer c;

        public ShoppingBll(IDal_Repository.IDalShopping sh, IDal_Repository.IDalShoppingDetail sd, IDal_Repository.IDalProduct p, IDal_Repository.IDalCustomer c)
        {
            this.sh = sh;
            this.sd = sd;
            this.p = p;
            this.c = c;
        }
        //חישוב התשלום
        private double PriceToPay(List<SoppingDetailDto> listS, DateTime dateBirth)
        {
            double price = 0;
            foreach (var item in listS)
            {
                price += item.Price * item.Quantity;
            }
            DateTime now = DateTime.Now;
            if (dateBirth.Month == now.Month)
                price = price * 0.8;

            return price;

        }

        //פונקציה הבודקת מה קיים במלאי ומעדכנת  בהתאם
        public async Task<Dictionary<int, ProductDto>> InventoryCheck(List<SoppingDetailDto> lsd)
        {
            var listP = await p.SelectAllServer();
            Dictionary<int, ProductDto> d = new Dictionary<int, ProductDto>();
            foreach (var item in lsd)
            {
                ProductDto pr = listP.Find(p => p.Id == item.ProductId);
                if (pr != null)
                {
                    if (pr.Quantity >= item.Quantity)//אם יש מספיק נעדכן את הקניה במלאי
                    {
                        pr.Quantity -= item.Quantity;
                        await p.Update(pr.Id, pr);
                    }
                    else
                        d.Add(item.Quantity - pr.Quantity, pr);


                }
            }

            if (d.Count > 0)
                return d;
            return null;
        }

        //פונקציה לסיום קניה.
        //באם יש חסר במלאי היא תחזיר מילון מלא במה חסר לחילפין- אובייקט קניה
        public async Task<(ShoppingDto shDto, Dictionary<int, ProductDto> dDto)> FinishShopping(List<SoppingDetailDto> lsd, int CustomerId)
        {
            //אם יש חסר במלאי
            Dictionary<int, ProductDto> d = await InventoryCheck(lsd);
            if (d != null && d.Count > 0)
                return (null, d);

            CustomerDto customer = await c.SelectById(CustomerId);

            ShoppingDto shopping = new ShoppingDto();
            shopping.Sum = PriceToPay(lsd, customer.DateBirth);
            Console.WriteLine(shopping.Sum);
            shopping.Remark = "";
            shopping.CustomerId = customer.Id;
            shopping.Date = DateTime.Now;

            int x = await sh.Add(shopping);
            if (x == 0)
                return (null, null);

            //שמירת פרטי קניה במסד
            foreach (var item in lsd)
            {
                sd.Add(item, x);
            }
            shopping.Id = x;
            string htmlTemplate = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Email Notification</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f4f4f4;\r\n            margin: 0;\r\n            padding: 20px;\r\n        }\r\n        .container {\r\n            background-color: #ffffff;\r\n            border-radius: 8px;\r\n            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);\r\n            padding: 20px;\r\n            text-align: center;\r\n        }\r\n        h1 {\r\n            color: #333;\r\n            font-size: 24px;\r\n            margin-bottom: 20px;\r\n        }\r\n        .amount {\r\n            font-size: 20px;\r\n            color: #4CAF50;\r\n            margin: 20px 0;\r\n        }\r\n        .delivery-info {\r\n            font-size: 16px;\r\n            color: #555;\r\n            margin-top: 10px;\r\n        }\r\n        .icon {\r\n            width: 50px;\r\n            height: 50px;\r\n            margin: 20px 0;\r\n        }\r\n        .footer {\r\n            margin-top: 30px;\r\n            font-size: 12px;\r\n            color: #aaa;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n      " +
                "  <h1>Hello {CustomerName}</h1>\r\n        <img src=\"https://studio4.co.il\" alt=\"Icon\" class=\"icon\">\r\n        <div class=\"amount\">Total Amount Due: ${TotalAmount}</div>\r\n        <div class=\"delivery-info\">Your delivery will arrive within 10 business days at the specified address.</div>\r\n        <div class=\"footer\">Thank you for your business!</div>\r\n    </div>\r\n</body>\r\n</html>\r\n";
            string html = htmlTemplate.Replace("{CustomerName}", customer.CustomerName)
                          .Replace("{TotalAmount}", shopping.Sum.ToString("F2"));

            SendEmail(customer.Email, "The purchase was successful.",html );

            return (shopping, null);

        }






        public void SendEmail(string toEmail, string subject, string body)
        {
            var fromAddress = new MailAddress("y5861142@gmail.com", "Ceramics and Sanitary Ware Store Ltd.");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "tzru scti vozr jgdb"; // סיסמת האפליקציה שלך

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                 IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }


    }
}
