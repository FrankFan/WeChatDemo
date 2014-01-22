using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChatDemo
{
    /// <summary>
    /// 用户实体信息类
    /// </summary>
    public class WeChatUserEntity
    {
        public string Subscribe { get; set; }

        public string Openid { get; set; }

        public string Nickname { get; set; }

        public string Sex { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string HeadImgUrl { get; set; }

        public string Subscribe_time { get; set; }

        public string Language { get; set; }
    }
}
