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
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;
using NUnit.Framework;


namespace Evoting_Nunit_test
{
    
    public class Company
    {
        public string token { get; set; }
        public static FJC_LoginRequest Default_user(string userid)
        {
            return new FJC_LoginRequest()
            { UserID = userid, system_ip = "127.0.0.128", encrypt_Password = "bigshare@123" };

        }
        public static FJC_GenerateEVENT generate_event(int scrut_rowid)
        {
            return new FJC_GenerateEVENT()
            {
                event_id = 0,
                isin = "INE98765888",
                type_isin = 3,
                type_evoting = 1,
                total_nof_share = 10000,
                voting_rights = 1,
                cut_of_date = "2020-11-05",
                scrutinizer = scrut_rowid
            };

        }
        public static FJC_CompanyUpdate_Event Com_event_detail(string event_id, int scrut_rowid,int uploadlogo,int resolution,int notice)  //=39370
        {
            List<FJC_Resolutions_Data> resolutions_Datas = new List<FJC_Resolutions_Data>();
            resolutions_Datas.Add(new FJC_Resolutions_Data() { doc_id = resolution, resolution_id = 1, title = "title1", description = "description1" });
            resolutions_Datas.Add(new FJC_Resolutions_Data() { doc_id = resolution, resolution_id = 2, title = "title2", description = "description2" });
            resolutions_Datas.Add(new FJC_Resolutions_Data() { doc_id = resolution, resolution_id = 3, title = "title3", description = "description3" });
            resolutions_Datas.Add(new FJC_Resolutions_Data() { doc_id = resolution, resolution_id = 4, title = "title4", description = "description4" });
            return new FJC_CompanyUpdate_Event()
            {
                event_id =Convert.ToInt32(event_id),
                isin = "INE98765432",
                type_isin = 3,
                type_evoting = 1,
                total_nof_share = 100000,
                voting_rights = 1,
                cut_of_date = "2020-08-31",
                scrutinizer = scrut_rowid,
                //voting_start_datetime = "Oct 29 2020 10:15AM",
                //voting_end_datetime = "Oct 29 2020 12:00PM",
                //meeting_datetime = "Oct 25 2020 21:00PM",
                voting_start_datetime = "2020-11-17 09:00:00",
                voting_end_datetime = "2020-11-17 18:00:00",
                meeting_datetime = "2020-11-17 18:00:00",
                last_date_notice = "2020-09-01",
                voting_result_date = "2020-09-10",
                upload_logo = uploadlogo,
                upload_resolution_file = resolution,
                upload_notice = notice,
                enter_nof_resolution = 4,
                resolutions = resolutions_Datas.ToArray()
            };

        }
        public static FJC_ROMUpload romupload(string event_id, int filedocid,string uploadNotice)
        {
            return new FJC_ROMUpload()
            {
                event_id = Convert.ToInt32(event_id),
                doc_id = filedocid,
                upload_type = uploadNotice
            };
        }
        public static FJC_ChangePassword change_password()
        {
            return new FJC_ChangePassword()
            {
                UserID = "C100000000000007",
                encrypt_OldPassword = "bigshare@123",
                encrypt_NewPassword = "bigshare@12"
            };
        }
        public static FJC_ForgotPassword forgot_password()
        {
            return new FJC_ForgotPassword()
            {
                UserID = "C100000000000003",
                EmailID = "shivkumar@bigshareonline.com",
                PAN_ID = "XXXXXXXXXX"
            };
        }
        public static FJC_Registration Registration(int rtaAudid)
        {
            return new FJC_Registration()
            {
                aud_id = 0,
                reg_type_id = 1,
                name = "Testingvikascompany",
                reg_no = "Lenovo123",
                reg_add1 = "Mumbai",
                reg_add2 = "vasai",
                reg_add3 = "virar",
                reg_city = "palghar",
                reg_pincode = "401303",
                reg_state_id = 1646,
                reg_country_id = 101,
                corres_add1 = "Mumbai",
                corres_add2 = "vasai",
                corres_add3 = "virar",
                corres_city = "palghar",
                corres_pincode = "401303",
                corres_state_id = 1646,
                corres_country_id = 101,
                pcs_no = "000001",
                cs_name = "Shivkumar",
                cs_email_id = "shivkumar@bigshareonline.com",
                cs_alt_email_id = "shivkumar@bigshareonline.com",
                cs_tel_no = "234234",
                cs_fax_no = "23423",
                cs_mobile_no = "1234567890",
                panid = "XXXXX0000X",
                alt_mob_num = "9022120324",
                rta_id = rtaAudid
            };

        }
        public static FJC_Registration Profile(int rtaAudid)
        {
            return new FJC_Registration()
            {
                aud_id = 0,
                reg_type_id = 1,
                name = "Testingcompany",
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
                panid = "XXXXX0000X",
                alt_mob_num = "9022120324",
                rta_id = rtaAudid,
             
        };

        }
        public static FJC_DOC_Upload Docupload(int docid)
        {
            return new FJC_DOC_Upload()
            {
                doc_id = docid,
                upload_type = "tri_partiate_agreement"

            };

        }

        //////////////////////////////////////////////////////company //////////////////////////////////////////////////////////////////
        
        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_GenerateEvent(FJC_GenerateEVENT fJC_GenerateEVENT,string token)
        {
            var get_url1 = await CommanUrl.GenerateEvent().WithOAuthBearerToken(token).PostJsonAsync(fJC_GenerateEVENT).ReceiveString();
            return get_url1;
        }
     
        public async Task<dynamic> Post_Company_Eventdetails(FJC_CompanyUpdate_Event fJC_CompanyUpdate_Event)
        {
            var get_url1 = await CommanUrl.ComEvntDetail().WithOAuthBearerToken(token).PostJsonAsync(fJC_CompanyUpdate_Event).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
      
        public async Task<dynamic> Put_Company_Eventdetails(FJC_CompanyUpdate_Event fJC_CompanyUpdate_Event,string token)
        {
            var get_url1 = await CommanUrl.ComEvntDetail().WithOAuthBearerToken(token).PutJsonAsync(fJC_CompanyUpdate_Event).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Get_Company_Eventdetails(int event_id)
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).SetQueryParam("doc_id", event_id).GetJsonAsync();
            var message = get_url1.data.file_name;
            return get_url1;
        }
        public async Task<dynamic> Post_LogoUpload(string token)
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).PostMultipartAsync(x =>
                            x.AddFile("files", @"C:\Evoting-Github\Files\sample_Logo.jpg")
                            .AddString("upload_type", "Logo")).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_ResolutionUpload(string token)
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).PostMultipartAsync(x =>
                            x.AddFile("files", @"C:\Evoting-Github\Files\Resolution File.docx")
                            .AddString("upload_type", "ResolutionFile")).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_NoticeUpload(string token)
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).PostMultipartAsync(x =>
                            x.AddFile("files", @"C:\Evoting-Github\Files\dummy_POA_20201008_1203600001711415.pdf")
                            .AddString("upload_type", "Notice")).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_FileUpload(string token)
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).PostMultipartAsync(x =>
                            x.AddFile("files", @"C:\Evoting-Github\Files\CDSLForTest.txt")
                            .AddString("upload_type", "ROM")).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_FileUploadnew(string token,string fileLocMove)
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).PostMultipartAsync(x =>
                            x.AddFile("files", fileLocMove)
                            .AddString("upload_type", "ROM")).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Get_FileUpload(int doc_id)   
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithOAuthBearerToken(token).SetQueryParam("doc_id", doc_id).GetJsonAsync();
            var message = get_url1.data.file_name;
            return get_url1;
        }
        public async Task<dynamic> Post_Rom_Upload(FJC_ROMUpload fJC_ROM, string token)
        {
            var get_url1 = await CommanUrl.ComRomUpload().WithOAuthBearerToken(token).PostJsonAsync(fJC_ROM).ReceiveString();
            return get_url1;
        }
       
        public async Task<dynamic> PostApproved_Event(string event_id,string token)
        {
            var get_url1 = await CommanUrl.ApprovedEvent().WithOAuthBearerToken(token).SetQueryParam("event_id", event_id).PostJsonAsync("").ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Get_List(string str,string token)
        {
            var get_url1 = await CommanUrl.CompanyList().WithOAuthBearerToken(token).SetQueryParam("str", str).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Get_PrivateList(string str)
        {
            var get_url1 = await CommanUrl.PrivateList().WithOAuthBearerToken(token).SetQueryParam("str", str).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Get_EventList(string str,string token)
        {
            var get_url1 = await CommanUrl.EventList().WithOAuthBearerToken(token).SetQueryParam("str", str).GetStringAsync();
            //var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Post_ChangePasssword(FJC_ChangePassword fJC_ChangePassword)
        {
            var get_url1 = await CommanUrl.ChangePass().WithOAuthBearerToken(token).PostJsonAsync(fJC_ChangePassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> PostForgotPassword(FJC_ForgotPassword fJC_ForgotPassword)
        {
            var get_url1 = await CommanUrl.ForgotPass().WithOAuthBearerToken(token).PostJsonAsync(fJC_ForgotPassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> Post_Registration(FJC_Registration fJC_Registration)
        {
            var get_url1 = await CommanUrl.Registration().WithOAuthBearerToken(token).PostJsonAsync(fJC_Registration).ReceiveString();
            return get_url1;
        }

        //////public async Task<dynamic> GetRegistration(int aud_id)
        //////{
        //////    var get_url1 = await CommanUrl.Registration().WithHeader("Token", token).SetQueryParam("str", aud_id).GetJsonAsync();
        //////    var message = get_url1.message;
        //////    return get_url1;
        //////}

        //////public async Task<dynamic> Put_Registration(FJC_Registration fJC_Registration)
        //////{
        //////    var get_url1 = await CommanUrl.Registration().WithHeader("Token", token).PutJsonAsync(fJC_Registration).ReceiveString();
        //////    return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        //////}

        public async Task<dynamic> Post_DocUpload(FJC_DOC_Upload fJC_DOC_Upload,string token)
        {
            var get_url1 = await CommanUrl.DocUpload().WithOAuthBearerToken(token).PostJsonAsync(fJC_DOC_Upload).ReceiveString();
            return get_url1;
        }

        //////public  async Task<dynamic> Get_DocUpload(FJC_DOC_Upload fJC_DOC_Upload)
        //////{
        //////   // var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).PostJsonAsync(fJC_DOC_Upload).ReceiveString();
        //////    var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
        //////    return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        //////}
      
        public async Task<dynamic> Get_Docdownload(string token)
        {
            var get_url1 = await CommanUrl.DocDownload().WithOAuthBearerToken(token).GetStringAsync();
            return  get_url1;
          
        }
       

        public async Task<dynamic> Post_Docdownload(string DownloadType,string token)   //tri_partiate_agreement
        {
           // var get_url1 = await CommanUrl.DocDownload().WithOAuthBearerToken(token).SetQueryParam("DownloadType", DownloadType).PostJsonAsync("").ReceiveString();
            var get_url1 = await CommanUrl.DocDownload().WithOAuthBearerToken(token).SetQueryParam("DownloadType", DownloadType).PostJsonAsync("").ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Put_Profile(FJC_Registration fJC_Registration,string token)
        {
            var get_url1 = await CommanUrl.userprofile().WithOAuthBearerToken(token).PutJsonAsync(fJC_Registration).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Get_Profile(string token)
        {
            var get_url1 = await CommanUrl.userprofile().WithOAuthBearerToken(token).GetStringAsync();
            return get_url1;
        }
    }
}
