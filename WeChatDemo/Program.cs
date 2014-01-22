using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChatDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WeChatDemo wcd = new WeChatDemo();
            WeChatTokenEntity wte = wcd.GetWechatToken();
            string token = wte.Access_token;
            string openId = "ok6Pkt0MFH3ipvpzdx2qRHdjU3O0";

            Console.WriteLine("第一步：获得access_token:\n " + token + "\n");

            Console.WriteLine("第二步：获得用户信息");
            WeChatUserEntity user = wcd.GetUserIfo(token, openId);

            Console.WriteLine("\n昵称：" + user.Nickname);
            Console.WriteLine("国家：" + user.Country);
            Console.WriteLine("省份：" + user.Province);
            Console.WriteLine("城市：" + user.City);
            Console.WriteLine("语言：" + user.Language);
            Console.WriteLine("性别：" + user.Sex);
            Console.WriteLine("OpenId：" + user.Openid);
            Console.WriteLine("是否订阅：" + user.Subscribe);
            Console.WriteLine("时间：" + wcd.TimeStamp2DateTime(user.Subscribe_time));
            Console.WriteLine("头像地址：" + user.HeadImgUrl);

            Console.WriteLine("\n第三步：获取微信声音地址");
            string mediaId = "puMLEUsFl9aZr_zI-dcdJJsUGyZGS8G1LxpFXnCQOBA7bnwvDcAy2dDkSG-WxE6D";

            string voiceAddress = wcd.GetVoice(token, mediaId);
            Console.WriteLine("声音地址：" + voiceAddress);


            Console.Read();
        }
    }
}
