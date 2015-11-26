<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseDepartmentAdd.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseDepartmentAdd" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:50px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" style="width: 450px" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" colspan="3" style="height: 30px; vertical-align:top">
                    新建部门</td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height:">
                    部门名称：</td>
                <td align="left" colspan="2" style="height:">
                    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtName" ErrorMessage="**　必填项"
                        SetFocusOnError="true" Width="144px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height:">
                    部门描述：</td>
                <td colspan="2" style="height:">
                    <asp:TextBox ID="txtContent" runat="server" Height="100px" Rows="8" TextMode="multiline"
                        Width="317px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="height:30px; vertical-align:bottom">
                    <asp:ImageButton ID="imgBtnSave" runat="server" AlternateText="保　存" OnClick="imgBtnSave_Click" ImageUrl="~/images/save.gif" />
                    &nbsp;
                    <asp:ImageButton ID="imgBtnClear" runat="server" AlternateText="清　空" OnClick="imgBtnClear_Click" ImageUrl="~/images/qingkong.gif" /></td>
            </tr>
        </table>
</asp:Content>
