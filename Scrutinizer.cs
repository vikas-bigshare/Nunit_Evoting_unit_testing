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
   public class Scrutinizer
    {
        public string token { get; set; }
        public static FJC_LoginRequest Default_user(string userid)
        {
            return new FJC_LoginRequest()
            { UserID = userid, system_ip = "127.0.0.60", encrypt_Password = "bigshare@123" };

        }

        public static FJC_Registration Registration()
        {
            return new FJC_Registration()
            {
                aud_id = 0,
                reg_type_id = 3,
                name = "Fortunekit",
                reg_no = "ADROIT1720",
                reg_add1 = "C114 Regency Plaza Shanti Nagar Near VJ Honda",
                reg_add2 = "MAROL NAKA, ANDHERI (E)",
                reg_add3 = "Mumbai",
                reg_city = "Kalyan",
                reg_pincode = "401001",
                reg_state_id = 4,
                reg_country_id = 1,  //reg_country_id
                corres_add1 = "Bigshare Services,1st Floor, Bharat Tin Work ,Makawana Road",
                corres_add2 = "Marol",
                corres_add3 = "Andheri East",
                corres_city = "Mumbai",
                corres_pincode = "421003",
                corres_state_id = 4,   
                corres_country_id = 1,  //corres_country_id
                pcs_no = "000001",
                cs_name = "Shivkumar",
                cs_email_id = "admin@fortunekit.com",
                cs_alt_email_id = "shivkumar@bigshareonline.com",
                cs_tel_no = "62638200",
                cs_fax_no = "62699990",
                cs_mobile_no = "1234567890",
                panid = "XXXXXXXX50",
                alt_mob_num ="9022120324",  //"9022120324"
                rta_id = 0
            };

        }

        public static FJC_ChangePassword change_password()
        {
            return new FJC_ChangePassword()
            {
                UserID = "S300000000000048",
                encrypt_OldPassword = "bigshare@123",
                encrypt_NewPassword = "bigshare@12"
            };
        }

        public static FJC_DOC_Upload Docupload()
        {
            return new FJC_DOC_Upload()
            {
                doc_id = 65,
                upload_type = "Tri_partiate_agreement",

            };

        }
        public static FJC_SharedHolder_Restrict scrutrestrict(string event_id)
        {
            return new  FJC_SharedHolder_Restrict()
                {
                event_id = Convert.ToInt32(event_id),
                dpcl= "IN30011810974875",  //userid  investor in rom uploaded file
                remark= "scrutrestrict"
            };
        }

        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            dynamic _obj = JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            token = _obj.data.Token;
            return _obj;
        }

        public async Task<dynamic> Post_Registration(FJC_Registration fJC_Registration)
        {
            var get_url1 = await CommanUrl.Registration().PostJsonAsync(fJC_Registration).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        
        public async Task<dynamic> Post_ChangePasssword(FJC_ChangePassword fJC_ChangePassword)
        {
            var get_url1 = await CommanUrl.ChangePass().WithHeader("Token", token).PostJsonAsync(fJC_ChangePassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_Docdownload(string token)
        {
            var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).GetJsonAsync();
            var message = get_url1.statusCode;
            return get_url1;
        }
        public async Task<dynamic> Post_Docdownload(string DownloadType, string token)   //tri_partiate_agreement
        {

            var get_url1 = await CommanUrl.DocDownload().WithHeader("Token", token).SetQueryParam("DownloadType", DownloadType).PostJsonAsync("").ReceiveString();
            return get_url1;
        }

        public async Task<dynamic> Get_DocUpload()
        {
            var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Post_DocUpload(FJC_DOC_Upload fJC_DOC_Upload, string token)
        {
            var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).PostJsonAsync(fJC_DOC_Upload).ReceiveString();
            return get_url1;
        }

        //////public async Task<dynamic> Put_Prifile(FJC_Registration fJC_Registration)
        //////{
        //////    var get_url1 = await CommanUrl.userprofile().WithHeader("Token", token).PutJsonAsync(fJC_Registration).ReceiveString();
        //////    return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        //////}
        public async Task<dynamic> Get_Prifile(int aud_id)
        {
            var get_url1 = await CommanUrl.userprofile().WithHeader("Token", token).SetQueryParam("aud_id", aud_id).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }

        public async Task<dynamic> Post_ScrutRestrict(FJC_SharedHolder_Restrict fJC_SharedHolder, string token)
        {
            var get_url1 = await CommanUrl.Restrictderestrict().WithHeader("Token", token).PostJsonAsync(fJC_SharedHolder).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_UnblockEvent(string event_id,string token)
        {
            var get_url1 = await CommanUrl.EventBlockUnblock().WithHeader("Token", token).PostJsonAsync(event_id).ReceiveString();
            return get_url1;
        }

        public async Task<dynamic> Post_finalizeevent(string event_id, string token)
        {
            var get_url1 = await CommanUrl.finalizeevent().WithHeader("Token", token).PostJsonAsync(event_id).ReceiveString();
            return get_url1;
        }

        public async Task<dynamic> Get_reportsgeneration(string event_id, string token)
        {
            var get_url1 = await CommanUrl.reportsgeneration().WithHeader("Token", token).SetQueryParam("event_id", event_id).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        
    }
}
