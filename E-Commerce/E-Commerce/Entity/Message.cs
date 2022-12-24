using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Message
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int SenderID { get; set; }
        public int ProductID { get; set; }
        public int ReceiverID { get; set; }
        public string Mesaj { get; set; } // Message olmuyor class adı ile aynı olduğu için
    }
}