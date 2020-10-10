using System;
using System.Collections.Generic;
using System.Text;

namespace Evoting_Nunit_test
{
 public   class Company_Module
    {
        public class Company_Login
        {
            public class Data
            {
                public string Token { get; set; }
                public string Name { get; set; }
                public string EmailID { get; set; }
                public string Audience { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }
        }

        public class Company_Registration
        {
            public class Data
            {
                public string UserID { get; set; }
                public int aud_id { get; set; }
                public int rowid { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }

        }

        public class Company_GenerateEvent
        {
            public class Data
            {
                public int Event_Id { get; set; }
                public string ISIN { get; set; }
                public string NAME { get; set; }
                public string ScrutinizerName { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }
        }
    }
}
