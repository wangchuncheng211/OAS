<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="SystemUserPwdUpdate.aspx.cs" Inherits="WebAppOAS.Sys.SystemUserPwdUpdate" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:50px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0"  
            style="width: 460px" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 100px; height:34px">
                    职员：</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="label" Width="144px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px;height:34px">
                    新密码：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="password" Width="140px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px;height:34px">
                    确认新密码：</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="password" Width="140px"></asp:TextBox>
                    <asp:CompareValidator ID="comparevalidator1" runat="server" ControlToCompare="TextBox1" ControlToValidate="TextBox2"
                        ErrorMessage="** 两次输入的密码不一致"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 34px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提　交" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button2" runat="server" CausesValidation="false" Text="重　置" onclick="Button2_Click" />
                    </td>
            </tr>
        </table>
</asp:Content>
