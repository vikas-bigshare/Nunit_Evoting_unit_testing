using System;
using System.Collections.Generic;
using System.Text;

namespace Evoting_Nunit_test
{
 public  class Custodian_Module
    {
        public class Custodian_Login
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

        public class Custodian_Registration
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

        public class Cust_FileUpload
        {
            public class Data
            {
                public int doc_id { get; set; }
                public string file_name { get; set; }
                public string url { get; set; }
                public int uploadedby { get; set; }
                public string name { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }
        }

        public class Cust_POAUpload
        {
            public class Data
            {
                public string remark { get; set; }
                public int doc_id { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }
        }


        public class Cust_VotfileUpload
        {
            public class Data
            {
                public string Remark { get; set; }
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
