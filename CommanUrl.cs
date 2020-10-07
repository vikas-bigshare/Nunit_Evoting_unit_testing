﻿using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using evoting;
using System.Net.Http;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using evoting.Domain.Models;

namespace Evoting_Nunit_test
{

    public static class CommanUrl
    {
      // const string DefaultUrl = "http://evoting.bigshareonline.com";
        //const string DefaultUrl = "https://evoting.bigshareonline.com:6001";
        //const string DefaultUrl = "http://bigshareonline.com:6001";
        const string DefaultUrl = "http://localhost:6000";

        //////////////////////////////////////////////////////company/////////////////////////////////////////////
        public static string Login()
        {
            var UrlLogin = DefaultUrl.AppendPathSegment("api").AppendPathSegment("Login");
            return UrlLogin;
        }
        public static string GenerateEvent()
        {
            var _genevent = DefaultUrl.AppendPathSegment("api").AppendPathSegment("Event");
            return _genevent;
        }
        public static string ComEvntDetail()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("CompanyEVENTDetails");
            return _ComEvntDe;
        }
        public static string ComFileUpload()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("FileUpload");
            return _ComEvntDe;
        }
        public static string ComRomUpload()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("ROM");
            return _ComEvntDe;
        }

        public static string ApprovedEvent()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("ApproveEvent");
            return _ComEvntDe;
        }

        public static string CompanyList()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("list");
            return _ComEvntDe;
        }

        public static string PrivateList()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("private-list");
            return _ComEvntDe;
        }

        public static string EventList()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("event-list");
            return _ComEvntDe;
        }

        public static string ChangePass()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("ChangePassword");
            return _ComEvntDe;
        }
        public static string ForgotPass()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("ForgotPassword");
            return _ComEvntDe;
        }
        public static string Registration()
        {                                                                         
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("Registration");
            return _ComEvntDe;
        }

        public static string DocUpload()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("DocumentUpload");
            return _ComEvntDe;
        }

        public static string DocDownload()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("DocumentDownload");
            return _ComEvntDe;
        }
        public static string userprofile()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("user-profile");
            return _ComEvntDe;
        }

        ////////////////////////////////////////////////////////////////////RTA/////////////////////////////

        public static string updateEvent()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("EVENTDetails"); 
            return _ComEvntDe;
        }
        public static string Restrictderestrict()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("shareholder").AppendPathSegment("restrict"); 
            return _ComEvntDe;
        }
        public static string derestrict()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("shareholder").AppendPathSegment("derestrict");
            return _ComEvntDe;
        }
        
        public static string EventBlockUnblock()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("event").AppendPathSegment("unblock");
            return _ComEvntDe;
        }
        public static string finalizeevent()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("finalizeevent");
            return _ComEvntDe;
        }
        public static string reportsgeneration()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("reports");
            return _ComEvntDe;
        }
        public static string InvestoreVoting()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("event").AppendPathSegment("vote");
            return _ComEvntDe;
        }


    }
}
