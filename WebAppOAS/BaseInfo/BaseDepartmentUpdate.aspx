<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseDepartmentUpdate.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseDepartmentUpdate" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:50px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" style="width: 392px; height: 100px" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center"  colspan="3" style="height: 50px">
                    －＝修改部门信息＝－</td>
            </tr>
            <tr>
                <td style="width: 77px">
                    <asp:Label ID="label1" runat="server" Font-Size="small" Text="部门名称：" Width="73px"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="txtName" runat="server" Font-Size="small" Width="206px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtName"
                        ErrorMessage="requiredfieldvalidator" SetFocusOnError="true" Width="105px">**</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 77px">
                    <asp:Label ID="label2" runat="server" Font-Size="small" Text="部门描述：" Width="73px"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="txtContent" runat="server" Font-Size="small"
                        Height="59px" TextMode="multiline" Width="308px"></asp:TextBox></td>
            </tr>
            <tr style="height:50px">
                <td align="center" colspan="3">
                    <asp:ImageButton ID="imgBtnSave" runat="server" AlternateText="保　存" OnClick="imgBtnSave_Click" ImageUrl="~/images/save.gif" />
                    &nbsp;
                    <asp:ImageButton ID="imgBtnReturn" runat="server" AlternateText="返　回" OnClick="imgBtnReturn_Click" ImageUrl="~/images/back.jpg" /></td>
            </tr>
        </table>
</asp:Content>
