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
        public class Scrut_postdownloadagreement
        {
            public class Data
            {
                public int doc_no { get; set; }
                public string file_name { get; set; }
                public string url { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }
        }
        public class Scrut_uploadagreement
        {
            public class Data
            {
                public string remark { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }

        }
        public class Scrut_getdownloadagreement
        {
            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public List<object> data { get; set; }
            }
        }
        public class Scrut_PostScrutVotingRestrict
        {
            public class Data
            {
                public string dpcl { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }
        }
        public class Scrut_UnblockEvent
        {
            public class Data
            {
                public string event_blocked { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }

        }
        public class Scrut_finalizeevent
        {
            public class Data
            {
                public string event_finalize { get; set; }
            }
            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }
        }
        public class Scrut_reportsgeneration
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
