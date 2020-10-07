using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using evoting.Domain.Models;
using System.Collections.Generic;
using System;
using evoting;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using System.Threading;
using System.Data;
namespace Evoting_Nunit_test
{
    [TestFixture]
    public class EvotingNunitTest
    {

        public string token { get; set; }
        public string userid { get; set; }
        public string RTAUserId { get; set; }
        public int RTAAudId { get; set; }
        public string scrut_UserId { get; set; }
        public int scrut_rowid { get; set; }
        public int docno { get; set; }
        public string event_id { get; set; }
        public int filedocid { get; set; }
        public string fileLocMove { get; set; }
        public class data
        {
            public int doc_no { get; set; }
            public string event_id { get; set; }
            public string remark { get; set; }
            public int doc_id { get; set; }
            public int rowid { get; set; }
            public int aud_id { get; set; }
            public string UserID { get; set; }
        }
        public class jsonparsingcls
        {
            public string statusCode { get; set; }
            public string message { get; set; }
            public data Data { get; set; }

        }
        
        [Test, Order(1)]
        public async Task CheckFlow()
        {
            CompanyUnitTest company = new CompanyUnitTest();
            await company.callRTA();
            await company.callScrutinizer();
            await company.Test_CompanyRegistration();
            await company.Test_CompanyLogin();
            await company.Test_postdownloadagreement();
            await company.Test_uploadagreement();
            await company.Test_getdownloadagreement();
            await company.Test_Postgenerateevent();
            await company.Test_Geteventlistcurrent();
            await company.Test_Putgenerateevent();
            company.romuploadfile_eventid_change();
            await company.Test_PostNewgeneratedFileUpload();
            await company.Test_postROMupload();
            await company.Test_postApprovedEvent();
            await company.callRTAsecond();
            await company.callScrutinizersecond();
            await company.callInvestor();
            await company.callCustodion();
        }

    }
}

