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

namespace Evoting_Nunit_test
{
   public class ScrutinizerUnitTest
    {
        public ScrutinizerUnitTest(string event_ids)
        {
            this.event_id = event_ids;
        }
        
        Scrutinizer _objcom = new Scrutinizer();
        public string token { get; set; }
        public string userid { get; set; }
        public string event_id { get; set; }
        public int docno { get; set; }
        public int rowid { get; set; }
        public int filedocid { get; set; }
        public string fileLocMove { get; set; }
    
        public async Task<Scrutinizer_Module.Scrutinizer_Registration.Root> Test_ScrutRegistration()
        {
            var check = await _objcom.Post_Registration(Scrutinizer.Registration());
            return JsonConvert.DeserializeObject<Scrutinizer_Module.Scrutinizer_Registration.Root>(check);
        } 
        public async Task Test_ScrutLogin(string scrut_UserId)
        {
            var check = await _objcom.Post_Login(Scrutinizer.Default_user(scrut_UserId));
            Scrutinizer_Module.Scrutinizer_Login.Root someval = JsonConvert.DeserializeObject<Scrutinizer_Module.Scrutinizer_Login.Root>(check);
            token = someval.data.Token;
        }
        public async Task Test_postdownloadagreement()
        {
            var check = await _objcom.Post_Docdownload("tri_partiate_agreement", token);
            Scrutinizer_Module.Scrut_postdownloadagreement.Root someval = JsonConvert.DeserializeObject<Scrutinizer_Module.Scrut_postdownloadagreement.Root>(check);
            docno = someval.data.doc_no;
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
        }
        public async Task Test_uploadagreement()
        {
            var check = await _objcom.Post_DocUpload(Company.Docupload(docno), token);
            Scrutinizer_Module.Scrut_uploadagreement.Root someval = JsonConvert.DeserializeObject<Scrutinizer_Module.Scrut_uploadagreement.Root>(check);
            Assert.IsNotNull(someval.message);
        }
        public async Task Test_getdownloadagreement()
        {
            var check = await _objcom.Get_Docdownload(token);
            Assert.IsNotNull(check.message);
            Assert.AreEqual(200, check.statusCode);
        }
        public async Task Test_PostScrutVotingRestrict()
        {
            var check = await _objcom.Post_ScrutRestrict(Scrutinizer.scrutrestrict(event_id),token);
            Scrutinizer_Module.Scrut_PostScrutVotingRestrict.Root someval = JsonConvert.DeserializeObject<Scrutinizer_Module.Scrut_PostScrutVotingRestrict.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual("ShareHolder restricted Successfully", someval.message);
        }
        public async Task Post_UnblockEvent()
        {
            var check = await _objcom.Post_UnblockEvent(event_id, token);
            Scrutinizer_Module.Scrut_UnblockEvent.Root someval = JsonConvert.DeserializeObject<Scrutinizer_Module.Scrut_UnblockEvent.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual("Event Blocked Successfully", someval.message);
        }
        public async Task Post_finalizeevent()
        {
            var check = await _objcom.Post_finalizeevent(event_id, token);
            Scrutinizer_Module.Scrut_finalizeevent.Root someval = JsonConvert.DeserializeObject<Scrutinizer_Module.Scrut_finalizeevent.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual("Event Finalize Successfully", someval.message);
        }
        public async Task Get_reportsgeneration()
        {
            var check = await _objcom.Get_reportsgeneration(event_id, token);
            Scrutinizer_Module.Scrut_reportsgeneration.Root someval = JsonConvert.DeserializeObject<Scrutinizer_Module.Scrut_reportsgeneration.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual("Reports will be generated now", someval.message);
        }
    }
}
