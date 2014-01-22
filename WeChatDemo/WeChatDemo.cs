using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;//System.Web.Extensions添加dll引用

namespace WeChatDemo
{
    /// <summary>
    /// 微信开发Demo：测试和微信服务器沟通
    /// </summary>
    public class WeChatDemo
    {
        /*
         * 步骤：
         * 1.通过appid和secret请求微信url，得到token
         * 2.通过access_token和openid得到用户信息（头像地址等）
         * 3.通过access_token和media_id得到用户发送的微信消息
         * 
         */

        string appId = "wx0632c45ef2a8a6c3";
        string appSecret = "0a89e17d8509c3d65159c4672138ce47";
        string wechatUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";


        public WeChatDemo()
        {
            
        }

        /// <summary>
        /// 获取token信息
        /// </summary>
        /// <returns></returns>
        public WeChatTokenEntity GetWechatToken()
        {   
            //请求的url地址
            string tokenUrl = string.Format(wechatUrl, appId, appSecret);
            WeChatTokenEntity myToken;

            try
            {
                //声明并实例化一个WebClient对象
                WebClient client = new WebClient();
                //从执行url下载数据
                byte[] pageData = client.DownloadData(tokenUrl);
                //把原始数据的byte数组转为字符串
                string jsonStr = Encoding.Default.GetString(pageData);
                //初始化一个JavaScriptSerializer json解析器
                //序列化注意：需要引用System.Web.Extensions
                JavaScriptSerializer jss = new JavaScriptSerializer();
                //将字符串反序列化为Token对象
                myToken = jss.Deserialize<WeChatTokenEntity>(jsonStr);
            }
            catch (WebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return myToken;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public WeChatUserEntity GetUserIfo(string accessToken, string openId)
        {
            WeChatUserEntity wue = new WeChatUserEntity();

            string url = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}";

            url = string.Format(url, accessToken, openId);

            try
            {
                WebClient wc = new WebClient();
                byte[] pageData = wc.DownloadData(url);
                string jsonStr = Encoding.UTF8.GetString(pageData);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                wue = jss.Deserialize<WeChatUserEntity>(jsonStr);

            }
            catch (WebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wue;
        }

        /// <summary>
        /// 时间戳转为当前时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public DateTime TimeStamp2DateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long time = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(time);
            return dtStart.Add(toNow);
        }

    }
}
