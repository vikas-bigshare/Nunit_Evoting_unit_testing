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
using Evoting_Nunit_test;
using static Evoting_Nunit_test.CompanyUnitTest;

namespace Evoting_Nunit_test
{
 public   class CustodianUnitTest
    {
        public CustodianUnitTest(string event_ids)
        {
            this.event_id = event_ids;
        }

        Custodian _objcom = new Custodian();
        public string token { get; set; }
        public string userid { get; set; }
        public int docno { get; set; }
        public string event_id { get; set; }
        public int filedocid { get; set; }
        public int filedocid_Vot { get; set; }
        public string fileLocMove { get; set; }
      
        public async Task<Custodian_Module.Custodian_Registration.Root> Test_CustodianRegistration()
        {
            var check = await _objcom.Post_Registration(Custodian.Registration());
            return JsonConvert.DeserializeObject<Custodian_Module.Custodian_Registration.Root>(check); 
        }
        public async Task Test_CustodianLogin(string Cust_UserId)
        {
            var check = await _objcom.Post_Login(Custodian.Default_user(Cust_UserId));
            Custodian_Module.Custodian_Login.Root someval = JsonConvert.DeserializeObject<Custodian_Module.Custodian_Login.Root>(check);
            token = someval.data.Token;
        }
        public async Task Test_CustodianFileUpload()
        {
            var check = await _objcom.Post_FileUpload( token);
             Custodian_Module.Cust_FileUpload.Root someval = JsonConvert.DeserializeObject<Custodian_Module.Cust_FileUpload.Root>(check);
             filedocid = someval.data.doc_id;
        }
        public async Task Test_CustodianPOAUpload()
        {
            var check = await _objcom.Post_POA_Upload(Custodian.CustDocupload(filedocid),token);
            Custodian_Module.Cust_POAUpload.Root someval = JsonConvert.DeserializeObject<Custodian_Module.Cust_POAUpload.Root>(check);
            string msg = someval.message;
        }

        public void Cust_uploadfile_eventid_change()
        {
            //string filepath = "C:\\Evoting-Github\\Files\\CDSLForTest.txt";
            string filepath = "C:\\Evoting-Github\\Files\\Cust38record_60183_Corrected.txt";
            string Cust_file = "C:\\Evoting-Github\\Cust_uploadedFiles\\";
            using (StreamReader sr = new System.IO.StreamReader(filepath))
            {
                string changefirstline;
                string firstline;
                //string fileLocMove = "";
                string newpath = Path.GetDirectoryName(Cust_file);
                fileLocMove = newpath + "\\" + System.DateTime.Now.ToString("yyyyMMdd-hhmmssfff") + "Cust_Upload" + event_id + ".txt";
                string text = File.ReadAllText(filepath);
                string[] lines = File.ReadAllLines(filepath);
                firstline = lines[0];
                string[] firstlineArr = firstline.Split('~');
                changefirstline = firstlineArr[2];
                //changefirstline = firstline.Substring(1, firstline.IndexOf("~12345~"));
                text = text.Replace(changefirstline, event_id);
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


        public async Task Test_CustodianFileUpload2()
        {
            var check = await _objcom.Post_CustFileUpload(token, fileLocMove);
            Custodian_Module.Cust_FileUpload.Root someval = JsonConvert.DeserializeObject<Custodian_Module.Cust_FileUpload.Root>(check);
            string msg = someval.message;
            filedocid_Vot = someval.data.doc_id;
        }
        public async Task Test_CustodianVotfileupload()
        {
            var check = await _objcom.Post_Cust_Votfileupload(Custodian.CustvotfileUpload(filedocid_Vot, event_id), token);
            Custodian_Module.Cust_VotfileUpload.Root someval = JsonConvert.DeserializeObject<Custodian_Module.Cust_VotfileUpload.Root>(check);
            string msg = someval.message;
        }

    }
}
