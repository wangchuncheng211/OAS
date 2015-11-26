<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="VoteItemSetting.aspx.cs" Inherits="WebAppOAS.Communication.VoteItemSetting" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:50px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="1" cellspacing=0 cellpadding=0 style="width: 520px; height: 100px">
            <tr>
                <td align="center"  colspan="3" style="height: 9px">
                    －＝设置活动投票信息＝－</td>
            </tr>
            <tr>
                <td>
                    活动标题：</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="326px"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="**　必填项！" Width="100px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    活动描述：</td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" Height="80px" TextMode="multiline"
                        Width="326px"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="requiredfieldvalidator2" runat="server" ControlToValidate="txtContent"
                        ErrorMessage="**　必填项！" Width="100px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:ImageButton ID="imgBtnSave" runat="server" AlternateText="提　交" OnClick="imgBtnSave_Click" ImageUrl="~/images/tt.gif" />
                    &nbsp;
                    <asp:ImageButton ID="imgBtnClear" runat="server" AlternateText="清　空" OnClick="imgBtnClear_Click" ImageUrl="~/images/qingkong.gif" /></td>
            </tr>
            </table>
</asp:Content>
