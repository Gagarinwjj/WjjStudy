using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using WjjStudy.model;

namespace WjjStudy.asmx
{
    /// <summary>
    /// info 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://gagarin.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class info : System.Web.Services.WebService
    {

        [WebMethod(Description = "返回类型是对象")]
        public Student GetStudent(int para)
        {
            return new Student { ID = para, Name = "wjj" };
            //{"d":{"__type":"WjjStudy.model.Student","ID":100,"Name":"wjj"}}
        }

        [WebMethod(Description = "返回类型是字符串")]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)] 没用
        public string GetStudentJson(int para)//返回给客户端为json字符串，需要将该字符串再次序列化。
        {
            //1、拼凑JSON字符串
            //return "{\"ID\":" + para + ",\"Name\":\"wjj\"}";

            //2、借助JavaScriptSerializer
            //this.Context.Request.ContentType = "application/json";//没用
            //this.Context.Response.ContentType = "application/json";//没用

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(new Student { ID = para, Name = "wjj" });
            //{"d":"{\"ID\":100,\"Name\":\"wjj\"}"}
        }
    }
}
