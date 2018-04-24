using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReviewSpring18.Models
{
    public class Message
    {
        public Message() { }// constructor initialize value of class & constructor should be name as class name 

        public Message(string msg)
        {
            MessageText = msg;
        }
        public string MessageText { set; get; }
    }
}