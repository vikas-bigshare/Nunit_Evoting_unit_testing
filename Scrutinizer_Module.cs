using System;
using System.Collections.Generic;
using System.Text;

namespace Evoting_Nunit_test
{
  public  class Scrutinizer_Module
    {
        public class Scrutinizer_Login
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

        public class Scrutinizer_Registration
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
    }
}
