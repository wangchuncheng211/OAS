<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseNoticeIssuance.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseNoticeIssuance" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:10px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" style="width: 700px; height: 40px" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center"  colspan="3">
                    －＝<asp:Label ID="LabelNotice" runat="server" Text="Label"></asp:Label>＝－</td>
            </tr>
            <tr>
                <td style="width: 56px; height: 28px;">
                    标题：</td>
                <td colspan="2" style="width: 621px; height: 28px">
                    <asp:TextBox ID="txtTitle" runat="server" Width="418px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="**  必填项"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 56px; vertical-align: top;">
                    内容：<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td colspan="2" style="width: 621px">
                        <asp:TextBox ID="FreeTextBox1" runat="server" Height="350px" Width="600px"  TextMode="MultiLine" /></td><%--Language="zh-CN"--%>
            </tr>
            <tr style="height:50px">
                <td align="center" colspan="3">
                    <asp:ImageButton ID="imgBtnSave" runat="server" AlternateText="发　布" OnClick="imgBtnSave_Click" ImageUrl="~/images/fabu.gif" />
                    &nbsp;
                    <asp:ImageButton ID="imgBtnClear" runat="server" AlternateText="清　空" OnClick="imgBtnClear_Click" ImageUrl="~/images/qingkong.gif" /></td>
            </tr>
        </table>
</asp:Content>
