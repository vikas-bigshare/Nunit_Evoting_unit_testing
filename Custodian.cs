using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using evoting;
using System.Net.Http;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using evoting.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;
namespace Evoting_Nunit_test
{
  public  class Custodian
    {
        public string token { get; set; }
        public static FJC_LoginRequest Default_user(string Cust_UserId)
        {
            return new FJC_LoginRequest()
            { UserID = Cust_UserId, system_ip = "127.0.0.1", encrypt_Password = "bigshare@123" };

        }
        public static FJC_Registration Registration()
        {
            return new FJC_Registration()
            {
                aud_id = 0,
                reg_type_id = 4,
                name = "TestingCustodion",
                reg_no = "Lenovo123",
                reg_add1 = "Mumbai",
                reg_add2 = "Mumbai",
                reg_add3 = "Mumbai",
                reg_city = "Mumbai",
                reg_pincode = "401001",
                reg_state_id = 1646,
                reg_country_id = 101,
                corres_add1 = "Mumbai1",
                corres_add2 = "Mumbai1",
                corres_add3 = "Mumbai1",
                corres_city = "Mumbai",
                corres_pincode = "401002",
                corres_state_id = 1646,
                corres_country_id = 101,
                pcs_no = "000001",
                cs_name = "Shivkumar",
                cs_email_id = "shivkumar@bigshareonline.com",
                cs_alt_email_id = "shivkumar@bigshareonline.com",
                cs_tel_no = "234234",
                cs_fax_no = "23423",
                cs_mobile_no = "1234567890",
                panid = "XXXXXXXX10",
                alt_mob_num = "9022120324",
                rta_id = 0
            };

        }
        public static FJC_DOC_Upload CustDocupload(int filedocid)
        {
            return new FJC_DOC_Upload()
            {
                doc_id= filedocid,
                upload_type= "power_of_attorney"
            };
        }
        public static FJC_ROMUpload CustvotfileUpload(int filedocid,string eventid)
        {
            return new FJC_ROMUpload()
            {
                doc_id = filedocid,
                event_id = Convert.ToInt32(eventid)
            };
        }
        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_Registration(FJC_Registration fJC_Registration)
        {
            var get_url1 = await CommanUrl.Registration().WithOAuthBearerToken(token).PostJsonAsync(fJC_Registration).ReceiveString();
             return get_url1;
        }
        public async Task<dynamic> Post_FileUpload(string token)
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).PostMultipartAsync(x =>
                          x.AddFile("files", @"C:\Evoting-Github\Files\dummy_POA_06112020_IN30088813445440.pdf")
                          .AddString("upload_type", "POA")).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_CustFileUpload(string token,string file)
        {
            //var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).PostMultipartAsync(x =>
            //              x.AddFile("files", @"C:\Evoting-Github\Files\Sample_file_for_Custodian.txt")
            //              .AddString("upload_type", "ROM")).ReceiveString();
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).PostMultipartAsync(x =>
                         x.AddFile("files", file)
                         .AddString("upload_type", "ROM")).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_POA_Upload(FJC_DOC_Upload fJC_DOC_Upload,string token)
        {
            var get_url1 = await CommanUrl.DocUpload().WithOAuthBearerToken(token).PostJsonAsync(fJC_DOC_Upload).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_Cust_Votfileupload(FJC_ROMUpload fJC_DOC_Upload, string token)
        {
            var get_url1 = await CommanUrl.CustodianVotfileupload().WithOAuthBearerToken(token).PostJsonAsync(fJC_DOC_Upload).ReceiveString();
            return get_url1;
        }

    }
}
