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

namespace Evoting_Nunit_test
{

    public class CompanyUnitTest
    {
        Company _objcom = new Company();

        public string token { get; set; }
        public string userid { get; set; }
        public string RTAUserId { get; set; }
        public int RTAAudId { get; set; }
        public string scrut_UserId { get; set; }
        public int scrut_rowid { get; set; }
        public string Cust_UserId { get; set; }
        public int Cust_rowid { get; set; }
        public int docno { get; set; }
        public string event_id { get; set; }
        public int filedocid { get; set; }
        public int UploadLogodocid { get; set; }
        public int UploadResolutiondocid { get; set; }
        public int Uploadnoticedocid { get; set; }
        public string fileLocMove { get; set; }

        public async Task callRTA()
        {
            RTAUnitTest rTAUnitTestr = new RTAUnitTest(event_id, UploadLogodocid, UploadResolutiondocid, Uploadnoticedocid);
            RTA_Module.RTA_Registration.Root rvalue = await rTAUnitTestr.Test_RTARegistration();
            RTAUserId = rvalue.data.UserID;
            RTAAudId = rvalue.data.aud_id;
        }
        public async Task callScrutinizer()
        {
            ScrutinizerUnitTest scrutinizerUnits = new ScrutinizerUnitTest(event_id);
            Scrutinizer_Module.Scrutinizer_Registration.Root rvalue = await scrutinizerUnits.Test_ScrutRegistration();
            scrut_UserId = rvalue.data.UserID;
            scrut_rowid = rvalue.data.rowid;
        }
        public async Task Test_CompanyRegistration()
        {
            var check = await _objcom.Post_Registration(Company.Registration(RTAAudId));
            Custodian_Module.Custodian_Registration.Root someval = JsonConvert.DeserializeObject<Custodian_Module.Custodian_Registration.Root>(check);
            userid = someval.data.UserID;
        }

        public async Task Test_CompanyLogin()
        {
            var check = await _objcom.Post_Login(Company.Default_user(userid));
            // var check = await _objcom.Post_Login(Company.Default_user("C100000000000305"));
            Company_Module.Company_Login.Root someval = JsonConvert.DeserializeObject<Company_Module.Company_Login.Root>(check);
            Assert.IsNotNull(someval.data.token);
            Assert.AreEqual("User logged in successfully", someval.message);
            token = someval.data.token;
        }




        public async Task Test_postdownloadagreement()
        {
            var check = await _objcom.Post_Docdownload("tri_partiate_agreement", token);
            Company_Module.Com_postdownloadagreement.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_postdownloadagreement.Root>(check);
            docno = someval.data.doc_no;
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
        }
        public async Task Test_uploadagreement()
        {
            var check = await _objcom.Post_DocUpload(Company.Docupload(docno), token);
            Company_Module.Com_uploadagreement.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_uploadagreement.Root>(check);
            Assert.IsNotNull(someval.message);

        }

        public async Task Test_getdownloadagreement()
        {
            var check = await _objcom.Get_Docdownload(token);
            Company_Module.Com_getdownloadagreement.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_getdownloadagreement.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
        }

        public async Task Test_Putprofile()
        {
            var check = await _objcom.Put_Profile(Company.Profile(RTAAudId), token);
            Company_Module.Com_Put_Profile.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_Put_Profile.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
        }

        public async Task Test_Get_Prifile()
        {
            var check = await _objcom.Get_Profile(token);
            Company_Module.Com_Get_Profile.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_Get_Profile.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
        }
        public async Task Test_Postgenerateevent()
        {
            var check = await _objcom.Post_GenerateEvent(Company.generate_event(scrut_rowid), token);
            Company_Module.Com_GenerateEvent.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_GenerateEvent.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
            event_id = Convert.ToString(someval.data.Event_Id);
        }
        public async Task Test_Geteventlistcurrent()
        {
            var check = await _objcom.Get_EventList("current", token);
            Company_Module.Com_EventList_current.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_EventList_current.Root>(check);
            Assert.AreEqual(200, someval.statusCode);
        }

        public async Task Test_Geteventlistpast()
        {
            var check = await _objcom.Get_EventList("past", token);
            Company_Module.Com_EventList_current.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_EventList_current.Root>(check);
            Assert.AreEqual(200, someval.statusCode);
        }
        //public async Task Test_PostFileUpload()
        //{
        //    var check = await _objcom.Post_FileUpload(token);
        //    jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
        //    jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
        //    filedocid = jsonparsingcls1.Data.doc_id;
        //}
        public async Task Test_PostLogoFileUpload()
        {
            var check = await _objcom.Post_LogoUpload(token);
            Company_Module.Com_PostNewGeneratedfile.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_PostNewGeneratedfile.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.IsNotNull(someval.data.doc_id);
            UploadLogodocid = someval.data.doc_id;
        }
        public async Task Test_PostResolutionFileUpload()
        {
            var check = await _objcom.Post_ResolutionUpload(token);
            Company_Module.Com_PostNewGeneratedfile.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_PostNewGeneratedfile.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.IsNotNull(someval.data.doc_id);
            UploadResolutiondocid = someval.data.doc_id;
        }

        public async Task Test_PostNoticeFileUpload()
        {
            var check = await _objcom.Post_NoticeUpload(token);
            Company_Module.Com_PostNewGeneratedfile.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_PostNewGeneratedfile.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.IsNotNull(someval.data.doc_id);
            Uploadnoticedocid = someval.data.doc_id;
        }
        public async Task Test_Putgenerateevent()
        {
            var check = await _objcom.Put_Company_Eventdetails(Company.Com_event_detail(event_id, scrut_rowid, UploadLogodocid, UploadResolutiondocid, Uploadnoticedocid), token);
            Company_Module.Com_Putgenerateevent.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_Putgenerateevent.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
        }

       
        public void romuploadfile_eventid_change()
        {
            //string filepath = "C:\\Evoting-Github\\Files\\CDSLForTest.txt";
            string filepath = "C:\\Evoting-Github\\Files\\Com_Rom_10records.txt";
            string Romfile = "C:\\Evoting-Github\\Rom_uploadedFiles\\";
            using (StreamReader sr = new System.IO.StreamReader(filepath))
            {
                string changefirstline;
                string firstline;
                //string fileLocMove = "";
                string newpath = Path.GetDirectoryName(Romfile);
                fileLocMove = newpath + "\\" + System.DateTime.Now.ToString("yyyyMMdd-hhmmssfff") + "CDSLFor" + event_id + ".txt";
                string text = File.ReadAllText(filepath);
                string[] lines = File.ReadAllLines(filepath);
                firstline = lines[0];
                changefirstline = firstline.Substring(0, firstline.IndexOf("~"));
                text = text.Replace(changefirstline, "00=" + event_id);
                string default_path = fileLocMove;
                if (!File.Exists(default_path))
                {
                    FileStream fs = File.Create(default_path);
                    fs.Flush();
                    fs.Close();
                }
                File.WriteAllText(fileLocMove, text);
            }
        }
        public async Task Test_PostNewgeneratedFileUpload()
        {
            var check = await _objcom.Post_FileUploadnew(token, fileLocMove);
            Company_Module.Com_PostNewGeneratedfile.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_PostNewGeneratedfile.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.IsNotNull(someval.data.doc_id);
            filedocid = someval.data.doc_id;
        }
        public async Task Test_postROMupload()
        {
            var check = await _objcom.Post_Rom_Upload(Company.romupload(event_id, filedocid,"notice"), token);
            Company_Module.Com_PostROMUpload.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_PostROMUpload.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual("ROM Uploaded succesfully", someval.data.Remark);
            string msg = someval.message;
        }
        public async Task Test_postApprovedEvent()
        {
            var check = await _objcom.PostApproved_Event(event_id, token);
            Company_Module.Com_PostApprovedEvent.Root someval = JsonConvert.DeserializeObject<Company_Module.Com_PostApprovedEvent.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual("Event Approved Succesfully", someval.data.Remark);
            string msg = someval.message;
        }
       
        //public async Task Test_Geteventlistapproved()
        //{
        //    var check = await _objcom.Get_EventList("approved", token);
        //    Assert.AreEqual(200, check.statusCode);
        //    jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
        //    jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
        //    string msg = jsonparsingcls1.message;
        //}
        public async Task callRTAsecond()
        {
            RTAUnitTest rTAUnitTest = new RTAUnitTest(event_id,UploadLogodocid,UploadResolutiondocid,Uploadnoticedocid);
            await rTAUnitTest.Test_RTALogin(RTAUserId);
            await rTAUnitTest.Test_Putprofile();
            await rTAUnitTest.Test_Get_Prifile();
            await rTAUnitTest.Test_postdownloadagreement();
            await rTAUnitTest.Test_uploadagreement();
            await rTAUnitTest.Test_getdownloadagreement();
            await rTAUnitTest.Test_Geteventlistcurrent();
            await rTAUnitTest.Test_Putgenerateevent();
            rTAUnitTest.romuploadfile_eventid_change();
            await rTAUnitTest.Test_PostNewgeneratedFileUpload();
            await rTAUnitTest.Test_postROMupload();
            //await rTAUnitTest.Test_PostFileUpload(); 
            //await rTAUnitTest.Test_postApprovedEvent();
            //await rTAUnitTest.Test_Geteventlistapproved();
        }
        public async Task callScrutinizersecond()
        {
           
           ScrutinizerUnitTest scrutinizerUnit = new ScrutinizerUnitTest(event_id);
            await scrutinizerUnit.Test_ScrutLogin(scrut_UserId);
           // await scrutinizerUnit.Test_ScrutLogin("S300000000000174");
            
            await scrutinizerUnit.Test_postdownloadagreement();
            await scrutinizerUnit.Test_uploadagreement();
            await scrutinizerUnit.Test_getdownloadagreement();
            await scrutinizerUnit.Test_PostScrutVotingRestrict();
            await scrutinizerUnit.Post_UnblockEvent();
            await scrutinizerUnit.Post_finalizeevent();
            await scrutinizerUnit.Get_reportsgeneration();
        }
     
        public async Task callInvestor()
        {
            InvestorUnitTest investorUnit = new InvestorUnitTest(event_id);
           // InvestorUnitTest investorUnit = new InvestorUnitTest("50175");
            await investorUnit.Test_InvestorLogin();
            await investorUnit.Post_InvestorVoting();
            await investorUnit.Post_InvestorSpeaker();
        }

        public async Task callCustRegistration()
        {
            CustodianUnitTest ObjCusto = new CustodianUnitTest(event_id);
            Custodian_Module.Custodian_Registration.Root rvalue = await ObjCusto.Test_CustodianRegistration();
            Cust_UserId = rvalue.data.UserID;
            Cust_rowid = rvalue.data.aud_id;
        }

        public async Task callCustodion()
        {
            CustodianUnitTest ObjCusto = new CustodianUnitTest(event_id);
           //CustodianUnitTest ObjCusto = new CustodianUnitTest("50175");
             await ObjCusto.Test_CustodianLogin(Cust_UserId);
           //await ObjCusto.Test_CustodianLogin("T400000000000025");
            await ObjCusto.Test_CustodianFileUpload();
            await ObjCusto.Test_CustodianPOAUpload();
             ObjCusto.Cust_uploadfile_eventid_change();
            await ObjCusto.Test_CustodianFileUpload2();
            await ObjCusto.Test_CustodianVotfileupload();

        }
        public async Task callEvoteAgency()
        {
            EvoteAgencyUnitTest ObjEvotAgency = new EvoteAgencyUnitTest(event_id);
            await ObjEvotAgency.Test_EvotAgencyLogin();
            await ObjEvotAgency.Test_AccountList();
            //await ObjEvotAgency.Test_AccountLock();
            await ObjEvotAgency.Test_AccountUnlock();
            await ObjEvotAgency.Test_GetAccount();
            await ObjEvotAgency.Test_PostAccountVerify();
            await ObjEvotAgency.Test_PostAccountSearch();

            
        }
    }
}