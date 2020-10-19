using System;
using System.Collections.Generic;
using System.Text;

namespace Evoting_Nunit_test
{
  public class EvoteAgency_Module
    {
        public class EvoteAgency_Login
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

        public class EvoteAgency_AccountList
        {
            public class Datum
            {
                public int aud_id { get; set; }
                public int rowid { get; set; }
                public string name { get; set; }
                public string mobile_no { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public List<Datum> data { get; set; }
            }

        }
        public class EvoteAgency_LockUnlock
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

        public class EvoteAgency_GetAccount
        {
            public class Data
            {
                public int aud_id { get; set; }
                public int reg_type_id { get; set; }
                public string name { get; set; }
                public string reg_no { get; set; }
                public string reg_add1 { get; set; }
                public string reg_add2 { get; set; }
                public string reg_add3 { get; set; }
                public string reg_city { get; set; }
                public string reg_pincode { get; set; }
                public string state { get; set; }
                public int reg_state_id { get; set; }
                public string country { get; set; }
                public int reg_country_id { get; set; }
                public string corres_add1 { get; set; }
                public string corres_add2 { get; set; }
                public string corres_add3 { get; set; }
                public string corres_city { get; set; }
                public string corres_pincode { get; set; }
                public string corr_state { get; set; }
                public string corr_country { get; set; }
                public string pcs_no { get; set; }
                public string cs_name { get; set; }
                public string cs_email_id { get; set; }
                public string cs_alt_email_id { get; set; }
                public string cs_tel_no { get; set; }
                public string cs_fax_no { get; set; }
                public string cs_mobile_no { get; set; }
                public string panid { get; set; }
                public int alt_mob_num { get; set; }
                public int rta_id { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }


        }

        public class EvoteAgency_AccountVerify
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

        public class EvoteAgency_AccountSearch
        {
            public class Datum
            {
                public int aud_id { get; set; }
                public string name { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public List<Datum> data { get; set; }
            }
        }
    }
}
