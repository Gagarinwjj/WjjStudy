<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testConStr.aspx.cs" Inherits="WjjStudy.aspx.testConStr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>链接字符串</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <%-- 链接服务器：opendatasource('SQLOLEDB' , 'Data Source=192.168.253;User ID=sa;Password=pdsgj2010').pes2.dbo.t_bus--%>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
