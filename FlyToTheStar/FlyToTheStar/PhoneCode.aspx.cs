using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Sms.V20190711;
using TencentCloud.Sms.V20190711.Models;

namespace FlyToTheStar
{
    public partial class PhoneCode : System.Web.UI.Page
    {
        //生成随机6位验证码
        public static string randCode()
        {
            string result = "";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                result += r.Next(10).ToString();
            }
            if (result == "000000")
            {
                result = "123456";
            }
            return result;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string phone = Request["phone"];
            ClientScript.RegisterStartupScript(Page.GetType(), "test", "<script>sendMessage()</script>");

            Credential cred = new Credential
            {
                SecretId = "AKID94kMk8QAWgrrgZkCyoUyH4fY9WIwMCl7",
                SecretKey = "vd7HDuBN2ZyQeeTAePyKsb62qd9y3ywi"
            };
            ClientProfile clientProfile = new ClientProfile();
            /* SDK默认用TC3-HMAC-SHA256进行签名
             * 非必要请不要修改这个字段 */
            clientProfile.SignMethod = ClientProfile.SIGN_TC3SHA256;
            HttpProfile httpProfile = new HttpProfile();
            httpProfile.Timeout = 10;
            httpProfile.Endpoint = "sms.tencentcloudapi.com";
            //  httpProfile.WebProxy = Environment.GetEnvironmentVariable("HTTPS_PROXY");
            clientProfile.HttpProfile = httpProfile;
            SmsClient client = new SmsClient(cred, "", clientProfile);
            SendSmsRequest req = new SendSmsRequest();
            req.SmsSdkAppid = "1400517358";
            req.Sign = "飞星学习网";
            // req.ExtendCode = "x";
            req.TemplateID = "369239";
            //req.SenderId = "361190";
            //req.SessionContext = "";
            req.PhoneNumberSet = new String[] { $"+86{phone}" };
            /* 模板 ID: 必须填写已审核通过的模板 ID。模板ID可登录 [短信控制台] 查看 */
            req.TemplateID = "952237";
            /* 模板参数: 若无模板参数，则设置为空*/
            string code = randCode();
            Session["code"] = code;
            req.TemplateParamSet = new String[] { $"{code}", "3" };
            client.SendSmsSync(req);
            Session.Add("code", code);

        }
    }
}