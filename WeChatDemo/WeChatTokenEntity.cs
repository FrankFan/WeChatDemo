using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChatDemo
{
    /// <summary>
    /// 微信Token实体类
    /// </summary>
    public class WeChatTokenEntity
    {
        public string Access_token { get; set; }

        public string Expires_in { get; set; }
    }
}
