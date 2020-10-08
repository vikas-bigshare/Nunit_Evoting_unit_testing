using System;
using System.Collections.Generic;
using System.Text;

namespace Evoting_Nunit_test
{
   public class Investor_Modules
    {
       public  class Investor_Login
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


        public class Investorvote
        {
            public class Data
            {
                public string REMARK { get; set; }
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
