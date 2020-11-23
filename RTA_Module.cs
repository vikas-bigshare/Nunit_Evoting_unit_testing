using System;
using System.Collections.Generic;
using System.Text;

namespace Evoting_Nunit_test
{
  public  class RTA_Module
    {
        public class RTA_Login
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
        public class RTA_Registration
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
        public class RTA_postdownloadagreement
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
        public class RTA_uploadagreement
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
        public class RTA_getdownloadagreement
        {
            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public List<object> data { get; set; }
            }
        }
        public class RTA_Putgenerateevent
        {
            public class Data
            {
                public int event_id { get; set; }
            }

            public class Resolution
            {
                public string Remark { get; set; }
                public string UpdateBy { get; set; }
                public int EVENT_ID { get; set; }
                public string ISIN { get; set; }
                public int isin_id { get; set; }
                public int evoting_id { get; set; }
                public string TOTAL_NOF_SHARE { get; set; }
                public string VOTING_RIGHTS { get; set; }
                public string CUT_OF_DATE { get; set; }
                public int scrutinizer_id { get; set; }
                public DateTime ModifiedDatetime { get; set; }
                public string VOTING_START_DATETIME { get; set; }
                public string VOTING_END_DATETIME { get; set; }
                public string MEETING_DATETIME { get; set; }
                public DateTime LAST_DATE_NOTICE { get; set; }
                public string VOTING_RESULT_DATE { get; set; }
                public int Logo_doc_id { get; set; }
                public string Upload_Logo_Filepath { get; set; }
                public int Notice_doc_id { get; set; }
                public string Upload_Notice_Filepath { get; set; }
                public int Resolution_doc_id { get; set; }
                public string Upload_Resolution_Filepath { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
                public List<Resolution> resolution { get; set; }
            }




        }
        public class RTA_PostNewGeneratedfile
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
        public class RTA_PostROMUpload
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

        public class RTA_Put_Profile
        {
            public class Data
            {
                public string Column1 { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }
        }

        public class RTA_Get_Profile
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
                public int reg_state_id { get; set; }
                public string reg_country_id { get; set; }
                public string corres_add1 { get; set; }
                public string corres_add2 { get; set; }
                public string corres_add3 { get; set; }
                public string corres_city { get; set; }
                public string corres_pincode { get; set; }
                public int corres_state_id { get; set; }
                public string corres_country_id { get; set; }
                public string pcs_no { get; set; }
                public string cs_name { get; set; }
                public string cs_email_id { get; set; }
                public string cs_alt_email_id { get; set; }
                public string cs_tel_no { get; set; }
                public string cs_fax_no { get; set; }
                public string cs_mobile_no { get; set; }
                public string panid { get; set; }
                public string alt_mob_num { get; set; }
                public int rta_id { get; set; }
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
