<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testAjax.aspx.cs" Inherits="WjjStudy.aspx.testAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>jquery、ScriptManager调用WebService</title>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script>
        //请求类型默认是application/json
        function ajaxGo() {//默认返回json
            //全路径：命名空间.类名.方法名。不管参数名，按照顺序匹配。
            WjjStudy.asmx.info.GetStudent(100, function (result) {
                console.log(result);//默认就是json
            }, function () {
                console.error("访问失败。");
            });

            WjjStudy.asmx.info.GetStudentJson(100, function (result) {
                console.log(result);//默认就是json
            }, function () {
                console.error("访问失败。");
            });
        }

        //请求类型默认是application/x-www-form-urlencoded; charset=UTF-8
        function jqAjaxGo() {//默认返回xml，如何改成json?
            //1、返回xml
            $.ajax({
                type: 'post',//默认只支持post，如果需要支持get，需要配置web.config
                url: '../asmx/info.asmx/GetStudent',
                async: true,
                data: { "para": 1000 },
                success: function (result) {
                    console.log(result);
                },
                error: function () {
                    console.error("访问失败。");
                }
            });
            //2、返回xml
            $.ajax({
                type: 'post',//默认只支持post，如果需要支持get，需要配置web.config
                url: '../asmx/info.asmx/GetStudentJson',
                async: true,
                data: { para: 1000 },
                success: function (result) {
                    console.log(result);
                },
                error: function () {
                    console.error("访问失败。");
                }
            });

            //如何换成接送？大量的尝试后
            //不管有没有配置web.config，使用get方法均报错：尝试使用 GET 请求调用方法“GetStudent”，但不允许这样做。
            //所以只能post，不能get。

            $.ajax({
                type: 'post',
                url: '../asmx/info.asmx/GetStudent',
                async: true,
                data: '{para:1000}',
                //1、参数列表必须同名，不区分大小写 PARa也行。不管顺序，按照参数名匹配。
                //2、如果指定contentType: 'application/json;charset=UTF-8',直接写{para:1000}报错->无效的json基元。需要写成'{}'
                contentType: 'application/json;charset=UTF-8',//指定contentType才有效，dataType不指望。
                dataType: 'json',//期待返回的类型，服务器会先 根据返回的数据推断，如果推断不了才会用这里的dataType。一般而言，都可以根据头信息推断出来，所以这里dataType几乎没用。
                success: function (result) {
                    console.log(result);
                },
                error: function () {
                    console.error("访问失败。");
                }
            });

            $.ajax({
                type: 'post',
                url: '../asmx/info.asmx/GetStudentJson',
                async: true,
                data: '{ para: 1000 }',
                contentType: 'application/json;charset=UTF-8',
                success: function (result) {
                    console.log(result);
                },
                error: function () {
                    console.error("访问失败。");
                }
            });


        }
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <%--注册脚本，会生成很多其他js--%>
        <asp:ScriptManager ID="clientService" runat="server">
            <Services>
                <asp:ServiceReference Path="~/asmx/info.asmx" />
            </Services>
        </asp:ScriptManager>

        <div id="container">
            <input type="button" value="ScripManager Test Ajax" onclick="ajaxGo();" />
            <br />
            <input type="button" value="jQuery Test Ajax" onclick="jqAjaxGo();" />
            <br />
        </div>
    </form>


</body>
</html>
