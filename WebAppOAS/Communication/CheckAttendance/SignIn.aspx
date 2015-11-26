<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebAppOAS.Communication.CheckAttendance.SignIn" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1{
            margin:50px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" align="center" border="1" cellspacing=0 cellpadding=0 style="width: 350px">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="labTitle" runat="server" Text="上下班考勤" Width="172px"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 6px">
                <asp:Label ID="Label1" runat="server" Text="label" Width="179px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 14px">
                上班签到：</td>
            <td style="width: 195px; height: 14px">
                <asp:Label ID="lblSTime" runat="server" Text="2014-12-12 15:42:48" Width="100px"></asp:Label><%#System.DateTime.Now.ToString() %></td>
            <td style="height: 14px">
                <asp:Button ID="btnSignIn" runat="server" OnClick="Button1_Click"
                    Text="签　到" Width="58px" /></td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 22px">
                <asp:Label ID="Label2" runat="server" Text="label" Width="173px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 14px">
                下班签退：</td>
            <td style="width: 195px; height: 14px">
                <asp:Label ID="lblXTime" runat="server" Text="2014-12-12 15:42:48" Width="100px"></asp:Label></td>
            <td style="height: 14px">
                <asp:Button ID="btnSignOut" runat="server" OnClick="Button2_Click"
                    Text="签　退" Width="58px" /></td>
        </tr>
        <tr>
            <td align="right" colspan="3" style="height: 16px">
                **请您自觉遵守考勤制度</td>
        </tr>
    </table>
</asp:Content>
