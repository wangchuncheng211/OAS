<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="myPagenavigate.ascx.cs" Inherits="WebAppOAS.UserControl.myPagenavigate" %>
<table id="Page" border="0" cellpadding="0" cellspacing="0" style="font-size: 12px;">
    <tr>
        <td >
            <asp:Label ID="labCurrentPage" runat="server"></asp:Label>
            /
            <asp:Label ID="labPageCount" runat="server"></asp:Label>
            <asp:LinkButton ID="lnkbtnFirst" runat="server" CommandName="first" Font-Underline="False" 
                                    ForeColor="#6600FF" oncommand="Pager_Command">首页</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnFront" runat="server" CommandName="pre" Font-Underline="False" 
                                    ForeColor="#6600FF" oncommand="Pager_Command">上一页</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnNext" runat="server" CommandName="next" Font-Underline="False" 
                                    ForeColor="#6600FF" oncommand="Pager_Command">下一页</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnLast" runat="server" CommandName="last" Font-Underline="False" 
                                    ForeColor="#6600FF" oncommand="Pager_Command">尾页</asp:LinkButton>
            &nbsp;&nbsp; 跳转至：<asp:TextBox ID="txtPage" runat="server" Width="35px" 
                                    Height="21px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CommandName="search" Text="GO" Height="24px" Width="46px" 
                oncommand="Pager_Command" />
            <br />
        </td>
    </tr>
</table>
<style type="text/css"> 
    a{ color: #000000; text-decoration: none; } a:hover { color: #428eff; text-decoration: none; } 
</style>