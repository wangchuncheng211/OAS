<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="SystemUser.aspx.cs" Inherits="WebAppOAS.Sys.SystemUser" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:50px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" style="width: 370px" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" colspan="3">
                    系统操作员设置</td>
            </tr>
            <tr>
                <td>
                    职员姓名：</td>
                <td>
                    <asp:DropDownList ID="dlEmployee" runat="server" Width="160px">
                    </asp:DropDownList></td>
                <td rowspan="3" style="width: 204px">
                    &nbsp;<asp:ListBox ID="ListBox1" runat="server" Height="90px" Width="105px">
                    </asp:ListBox></td>
            </tr>
            <tr>
                <td>
                    操作角色：</td>
                <td style="width: 374px">
                    <asp:RadioButton ID="RadioButtonManager" runat="server" Text="管理员" 
                        GroupName="Role" oncheckedchanged="RadioButtonManager_CheckedChanged" />&nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButtonUser" runat="server" Text="用户" GroupName="Role" 
                        oncheckedchanged="RadioButtonUser_CheckedChanged" /></td>                 
            </tr>
            <tr>
                <td style="width:1000px">
                    系统密码：</td>
                <td style="width: 374px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="160px"></asp:TextBox></td>
            </tr>
            <tr style="height:50px">
                <td align="center" colspan="2">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"
                        Text="保存密码" /></td>
                <td align="center" style="width: 204px">
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click"
                        Text="删除操作员" /></td>
            </tr>
        </table>
</asp:Content>
