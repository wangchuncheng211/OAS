<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppOAS.Default" %>

<%@ Register src="UserControl/Login.ascx" tagname="Login" tagprefix="uc1" %>

<%@ Register src="UserControl/GoodEmployee.ascx" tagname="GoodEmployeel" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>企业办公自动化管理系统</title>
    <link type="text/css" href="CSS/Default.css" rel="Stylesheet" />
    <script  type="text/javascript" src="Js/XMLDoxParse.js"></script>
    <script  type="text/javascript" src="Js/AjaxNotice.js"></script>
    <script  type="text/javascript" src="Js/ShowNotice.js"></script>
</head>
<body>
    <form id="form1" runat="server" target="_blank">
    <div id="container">
        <div id="top">
            <p id="onlineCount"><asp:Label ID="Label1" runat="server" Text="Label" 
                    Width="150px"></asp:Label> </p>             
        </div>
        
        <div id="main">
            <div id="left">
                
                <asp:Image ID="Image2" runat="server"  ImageUrl="images/index_04.jpg" />
                
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                    BorderColor="#3366CC" Font-Names="Verdana" 
                    Font-Size="8pt" ForeColor="#003399" Height="200px" 
                    Width="224px" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest">
                    <SelectedDayStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <DayHeaderStyle ForeColor="#336666" 
                        Height="1px" BackColor="#99CCCC" />
                    <TitleStyle BackColor="#003399" Font-Bold="True" 
                        Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" BorderColor="#3366CC" 
                        BorderWidth="1px" />
                </asp:Calendar>
                
                <uc1:Login ID="Login1" runat="server" />
                
                
                <uc3:GoodEmployeel ID="GoodEmployeel1" runat="server" />
                
            </div>
            
            <div id="right">
                
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/index_06.jpg" />
                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/index_09.jpg" />
                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/index_10.jpg" />
                <div id="divContent">正在获取数据...</div>
                   <script type="text/javascript">
                           showContent('Xml/NoticeXml/Notice','Table1','divContent');
                   </script>
            </div>
        </div>        
        
        <div id="footer">
        </div>
    </div>
    </form>
</body>
</html>
