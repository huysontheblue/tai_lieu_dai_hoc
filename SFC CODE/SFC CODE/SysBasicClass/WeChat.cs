
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Luxshare.Common
{
    public class WeChat
    {
        private static string WeChatPostUrl = "http://oa.luxshare-ict.com/luxshare/workflow/weixin/push_operation.jsp";
        private static string WeChatPostNewUrl = "http://oa.luxshare-ict.com/luxshare/workflow/weixin/push_operation_kp.jsp";


        public static WeChatReturnModel Sent(WeChatSentModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.WorkCodes) && !string.IsNullOrEmpty(model.Content)&&!string.IsNullOrEmpty(model.Title))
            {
                var paras = "workcodes=" + model.WorkCodes + "&tpids=" + model.Tpids + "&title=" + model.Title + "&content=" + model.Content + "&linkurl=" + model.LinkUrl + "&imgurl=" + model.ImgUrl;
                if (!string.IsNullOrEmpty(model.WorkCodes))
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Encoding = Encoding.UTF8;
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";
                        var parasby = Encoding.UTF8.GetBytes(paras);
                        var tt = wc.UploadData(WeChatPostUrl, "POST", parasby);
                        string wechat = Encoding.UTF8.GetString(tt);
                        wechat = wechat.Replace("\n", string.Empty).Replace("\r", string.Empty);
                        int i = wechat.IndexOf("\"msgcode\":\"") + 11;
                        int j = wechat.IndexOf("\"msginfo\":\"") + 11;
                        string code = wechat.Substring(i, 1);
                        string info = wechat.Substring(j);
                        return new WeChatReturnModel
                        {
                            Msgcode = code,
                            Msginfo = info
                        };
                    }
                }
            }
            return null;
        }


        public static WeChatReturnModel NewSent(WeChatNewSentModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.workcodes) && !string.IsNullOrEmpty(model.content))
            {
                if (!string.IsNullOrEmpty(model.workcodes))
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {

                            var paras = "content=" + model.content + "&msgtype=text&title=" + model.title + "&workcodes=" + model.workcodes + "&pass=luxshare888..";
                            if (model.type == MsgTypeEnum.textcard)
                            {
                                paras = "btntxt=" + model.btntxt + "&content=" + model.content + "&linkurl=" + model.linkurl + "&msgtype=textcard&title=" + model.title + "&workcodes=" + model.workcodes + "&pass=luxshare888..";
                            }
                            wc.Encoding = Encoding.UTF8;
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";
                            var parasby = Encoding.UTF8.GetBytes(paras);
                            var tt = wc.UploadData(WeChatPostNewUrl, "POST", parasby);
                            string wechat = Encoding.UTF8.GetString(tt);
                            wechat = wechat.Replace("\n", string.Empty).Replace("\r", string.Empty);
                            int i = wechat.IndexOf("\"msgcode\":\"") + 11;
                            string code = wechat.Substring(i, 1);
                            return new WeChatReturnModel
                            {
                                Msgcode = code
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        var errMsg = ex.Message;
                        return null;
                    }
                }
            }
            return null;
        }
    }

    public class WeChatSentModel
    {
        /// <summary>
        /// 消息模板ID 09f8da7f49884184923a7663d92db55f
        /// </summary>
        public string Tpids { set; get; }

        /// <summary>
        /// 消息接收人员工号
        /// </summary>
        public string WorkCodes { set; get; }

        /// <summary>
        /// 推送的内容
        /// </summary>
        public string Content { set; get; }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 消息背景图
        /// </summary>
        public string ImgUrl { set; get; }

        /// <summary>
        /// 消息连接
        /// </summary>
        public string LinkUrl { set; get; }
    }

    public class WeChatReturnModel
    {
        /// <summary>
        /// 0:发送成功。 -1:发失败。
        /// </summary>
        public string Msgcode { set; get; }

        /// <summary>
        /// 发送状态描述
        /// </summary>
        public string Msginfo { set; get; }
    }


    public class WeChatNewSentModel
    {
        public string btntxt { set; get; }

        public string content { set; get; }

        public string linkurl { set; get; }

        public string msgtype { set; get; }

        public MsgTypeEnum type { set; get; }
        public string title { set; get; }

        public string workcodes { set; get; }

        public string pass { set; get; }
    }

    public enum MsgTypeEnum
    {
        /// <summary>
        /// 有链接
        /// </summary>
        textcard = 1,

        /// <summary>
        /// 纯文本
        /// </summary>
        text = 2,
    }
}
