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
            await company.callInvestor();
            await company.callScrutinizersecond();
            await company.callCustRegistration();
            await company.callCustodion();
        }

        //[Test, Order(1)]
        //public async Task AddOfFlow()
        //{
        //    CompanyUnitTest company = new CompanyUnitTest();
        //    await company.callCustRegistration();
        //    await company.callCustodion();
        //}
    }
}

