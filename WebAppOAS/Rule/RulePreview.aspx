<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="RulePreview.aspx.cs" Inherits="WebAppOAS.Rule.RulePreview" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:10px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" border="0" style="width: 663px; height: 336px" cellpadding="0" cellspacing="0">
        <tr style="height:50px">
            <td align="center"  colspan="3">
                公司规章制度</td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; height: 350px">
                <%--<asp:Table ID="Table1" runat="server" Width="666px" CaptionAlign="Left" Font-Size="12px">
                </asp:Table>--%>
                <asp:TextBox id="TextBox1" runat="Server" Height="400px" Width="655px" 
                    TextMode="MultiLine"  ReadOnly="True" />
            </td>
        </tr>
        </table>
</asp:Content>
