using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DL.Model
{
    internal class Header
    {
        public Timestamp timestamp {get;set;} 
        public AccountInfo AccountInfo { get;set;}

        public Header()
        {
            timestamp = new Timestamp();
            timestamp.RequestTimeStamp = DateTime.Now;
            timestamp.TimeZone = "Israel Standart Time.";
         }
    }


    public class Timestamp
    {
        public DateTime RequestTimeStamp { get;set;}
        public string TimeZone { get;set;}
        public Timestamp()
        {
            this.TimeZone = "Israel Standart Time";
        }
    }

    public class AccountInfo
    {
        public string ? BankNumber { get;set;}
        public string ? AccountNumber { get; set; }
    }
}
