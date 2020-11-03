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
                public string error { get; set; }
                public string token { get; set; }
                public string name { get; set; }
                public string emailID { get; set; }
                public string audience { get; set; }
            }

            public class Root
            {
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
        public class Com_postdownloadagreement
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
        public class Com_uploadagreement
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
        public class Com_getdownloadagreement
        {
            public class Datum
            {
                public int doc_no { get; set; }
                public string file_name { get; set; }
                public string url { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public List<Datum> data { get; set; }
            }
        }

        public class Com_GenerateEvent
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

        public class Com_EventList_current
        {
            public class Datum
            {
                public int serial_id { get; set; }
                public int evoting_id { get; set; }
                public string event_type { get; set; }
                public int event_id { get; set; }
                public DateTime cut_of_date { get; set; }
                public string status { get; set; }
                public int isin_type_id { get; set; }
                public string Isin_type { get; set; }
                public string event_name { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public List<Datum> data { get; set; }
            }

        }
        public class Com_Putgenerateevent
        {
            public class LogoDocId
            {
            }

            public class NoticeDocId
            {
            }

            public class ResolutionDocId
            {
            }

            public class Data
            {
                public string Remark { get; set; }
                public string UpdateBy { get; set; }
                public int EVENT_ID { get; set; }
                public string ISIN { get; set; }
                public int isin_id { get; set; }
                public string Isin_type { get; set; }
                public int evoting_id { get; set; }
                public string evoting_type { get; set; }
                public string TOTAL_NOF_SHARE { get; set; }
                public string VOTING_RIGHTS { get; set; }
                public string CUT_OF_DATE { get; set; }
                public int scrutinizer_id { get; set; }
                public string Scrutinizer_name { get; set; }
                public string ModifiedDatetime { get; set; }
                public string VOTING_START_DATETIME { get; set; }
                public string VOTING_END_DATETIME { get; set; }
                public string MEETING_DATETIME { get; set; }
                public string LAST_DATE_NOTICE { get; set; }
                public string VOTING_RESULT_DATE { get; set; }
                public LogoDocId Logo_doc_id { get; set; }
                public string Upload_Logo_Filepath { get; set; }
                public NoticeDocId Notice_doc_id { get; set; }
                public string Upload_Notice_Filepath { get; set; }
                public ResolutionDocId Resolution_doc_id { get; set; }
                public string Upload_Resolution_Filepath { get; set; }
            }

            public class Resolution
            {
                public int EVENT_RESOLUTION_ID { get; set; }
                public string title { get; set; }
                public string DESCRIPTION { get; set; }
                public string ModifiedBY { get; set; }
                public string File_doc_path { get; set; }
                public int FILE_DOC_ID { get; set; }
                public DateTime modified_datetime { get; set; }
            }

            public class Root
            {
                public int statusCode { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
                public List<Resolution> resolution { get; set; }
            }

        }
        public class Com_PostNewGeneratedfile
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
        public class Com_PostROMUpload
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
        public class Com_PostApprovedEvent
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
