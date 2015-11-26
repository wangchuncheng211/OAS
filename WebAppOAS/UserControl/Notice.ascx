<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notice.ascx.cs" Inherits="WebAppOAS.UserControl.Notice" %>

<asp:DataList ID="DataList1" runat="server" align="center" BackColor="white"
    BorderStyle="none" BorderWidth="0px" CellPadding="3" ForeColor="white" 
    GridLines="horizontal" Width="440px" >
    
    <FooterStyle BackColor="Fuchsia" ForeColor="#4A3C8C" />
    <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    
    <ItemTemplate>
        <table cellpadding="0" cellspacing="0"  style="width: 750px;
            color: #000000; height: 80px; font-size:14px;">
            <tr>
                <td align="center" colspan="2" style="height: 18px">
                    公告标题：<a style="text-decoration:none;" href="../Html/Notice/<%#DataBinder.Eval(Container.DataItem, "noticeHtmlName")%>.html" target="_blank">
                    <%#DataBinder.Eval(Container.DataItem, "noticetitle")%></a></td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 22px">
                    公告内容：<br />
                    &nbsp; &nbsp; &nbsp; &nbsp;<%# MyContent((string)Eval("noticecontent"))%><a style="text-decoration:none;" href="../Html/Notice/<%#DataBinder.Eval(Container.DataItem, "noticeHtmlName")%>.html" target="_blank">更多</a>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 921px; height: 65px;">
                    公告日期：<%# DataBinder.Eval(Container.DataItem,"noticetime", "{0:yyyy-MM-dd}")%></td>
                <td align="center" style="width: 475px; height: 65px;">
                    发布公告人：<%# DataBinder.Eval(Container.DataItem, "noticeperson")%></td>
            </tr>
        </table>
    </ItemTemplate>
    
    <AlternatingItemStyle BackColor="#F7F7F7" />
    <ItemStyle ForeColor="Black" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
</asp:DataList>