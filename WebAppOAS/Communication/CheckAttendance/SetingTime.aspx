<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="SetingTime.aspx.cs" Inherits="WebAppOAS.Communication.CheckAttendance.SetingTime" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1{
            margin:50px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" align="center" border="1" cellspacing="0" style="width: 500px;
        height: 1px">
        <tr>
            <td align="center"  colspan="3" style="height: 13px">
                员工上下班时间设置</td>
        </tr>
        <tr>
            <td style="width: 120px">
                员工上班时间：</td>
            <td style="width: 84px">
                <asp:TextBox ID="TextBox1" runat="server" Width="80px">08:00:00</asp:TextBox></td>
            <td>
                格式例如：08:30:00<asp:RegularExpressionValidator ID="regularexpressionvalidator1" runat="server"
                    ControlToValidate="TextBox1" ErrorMessage="** 格式不正确" ValidationExpression="^(0?[0-9]|1[0-9]|2[0-3]):([0-5])+([0-9]):([0-5])+([0-9])"></asp:RegularExpressionValidator></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 120px">
                员工下班时间：</td>
            <td style="width: 84px">
                <asp:TextBox ID="TextBox2" runat="server" Width="80px">17:00:00</asp:TextBox></td>
            <td>
                格式例如：16:30:00<asp:RegularExpressionValidator ID="regularexpressionvalidator2" runat="server"
                    ControlToValidate="TextBox2" ErrorMessage="** 格式不正确" ValidationExpression="^(0?[0-9]|1[0-9]|2[0-3]):([0-5])+([0-9]):([0-5])+([0-9])"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <asp:Button ID="btnSave" runat="server" CssClass="bluebuttoncss" OnClick="btnSave_Click"
                    Text="设　置" />
                &nbsp; &nbsp;
                <asp:Button ID="btnClear" runat="server" CausesValidation="false" CssClass="bluebuttoncss"
                    OnClick="btnClear_Click" Text="重　置" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
