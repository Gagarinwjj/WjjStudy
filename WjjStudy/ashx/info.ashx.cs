using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WjjStudy.handler
{
    /// <summary>
    /// info 的摘要说明
    /// </summary>
    public class info : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //提取参数
            //context.Request.QueryString["name"];
            //context.Request.Form["name"];
            
            //json 的 contentType 常见写法有 : text/json & text/javascript .
            //但是 这个 text/json 其实是根本不存在的, 而 text/javascript 在有些时候客户端处理起来会有歧义. 对于json的contentType , rfc里定义的标准写法是 :application/json.在这里毫无疑问 我们应该选择标准写法的 application/Json。
            //如果指定为text/json， 处理方式：firefox，下载；chrome，直接显示。
            context.Response.ContentType = "application/json";//只有具体指定了，firefox的json插件才起作用！
            //context.Response.Write("{\"name\":\"wjj\",\"age\":\"25\"}");
            Hashtable ht = new Hashtable();
            ht["name"] = "wjj";
            ht["age"] = "21";

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(ht);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}