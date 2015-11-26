<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="FileSend.aspx.cs" Inherits="WebAppOAS.fileManage.FileSend" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1{
            margin:10px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" align="center" border="0" style="width: 661px; height: 200px" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" colspan="3" style="height: 31px">
                文件传送</td>
        </tr>
        <tr>
            <td style="width: 80px;height: 31px">
                接收人：</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlName" runat="server" Width="154px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 80px;height: 31px">
                文件标题：</td>
            <td colspan="2">
                <asp:TextBox ID="txtTitle" runat="server" Width="490px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="**　必填项"></asp:RequiredFieldValidator></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 80px; height: 14px">
                文件内容：</td>
            <td colspan="2" style="height: 14px">
                <asp:TextBox ID="txtContent" runat="server" Height="109px" TextMode="multiline"
                    Width="490px"></asp:TextBox><asp:RequiredFieldValidator ID="requiredfieldvalidator2"
                        runat="server" ControlToValidate="txtContent" ErrorMessage="**　必填项"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 80px; height: 31px">
                附件：</td>
            <td colspan="2" style="height: 31px">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="220px" /></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="btnSend" runat="server" CssClass="redbuttoncss" OnClick="btnSend_Click"
                    Text="发　送" Width="72px" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancle" runat="server" CausesValidation="false" CssClass="redbuttoncss"
                    OnClick="btnCancle_Click" Text="重　置" Width="72px" /></td>
        </tr>
    </table>
</asp:Content>
