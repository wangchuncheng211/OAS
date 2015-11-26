<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="RuleUpdate.aspx.cs" Inherits="WebAppOAS.Rule.RuleUpdate" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:10px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" align="center" border="0"  style="width: 629px; height: 1px" cellpadding="0" cellspacing="0">
        <tr style="height:50px">
            <td align="center"  colspan="3">
                编辑公司规章制度</td>
        </tr>
        <tr>
            <td colspan="3" style="height: 320px">
            <asp:TextBox id="FreeTextBox1" runat="Server" Height="350px" Width="620px" TextMode="MultiLine" /><%-- ButtonSet="OfficeMac" DisableIEBackButton="False" DownLevelMode="TextArea" Language="zh-CN"--%> 
                </td>
        </tr>
        <tr style="height:50px">
            <td align="center" colspan="3" style="height: 17px">
                <asp:Button ID="Button1" runat="server" CssClass="redbuttoncss" OnClick="Button1_Click"
                    Text="提　交" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" CssClass="redbuttoncss" OnClick="Button2_Click"
                    Text="重　置" /></td>
        </tr>
    </table>
</asp:Content>
