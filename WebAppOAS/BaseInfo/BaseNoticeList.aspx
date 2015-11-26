<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseNoticeList.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseNoticeList" Title="企业办公自动化管理系统" %>
<%@ Register src="../UserControl/myPagenavigate.ascx" tagname="myPagenavigate" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:10px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" style="width: 570px; height: 301px" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 390px; height: 34px" align="center">
                    企业公告</td>
            </tr>
            <tr>
                <td style="width: 390px">
                    <asp:DataList ID="DataList1" runat="server" BackColor="white" BorderColor="White"
                        BorderStyle="none" BorderWidth="1px" CellPadding="2" GridLines="horizontal" 
                        OnDeleteCommand="DataList1_DeleteCommand" OnEditCommand="DataList1_EditCommand" 
                        Width="536px" Font-Size="12px">
                        <ItemTemplate>
                            <table border="0" style="width: 658px; height: 0px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 898px">
                                        标题：<a href="../Html/Notice/<%#DataBinder.Eval(Container.DataItem, "noticeHtmlName")%>.html" style="text-decoration:none;" target="_blank">
                                                <%# DataBinder.Eval(Container.DataItem, "noticetitle")%></a></td>
                                    <td align="center" style="width: 266px">
                                        <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="删除公告" CommandName="delete"
                                            Height="21px" Width="61px" ImageUrl="~/images/delete.gif" />
                                        <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="修改公告" CommandName="edit"
                                            Height="21px" Width="61px" ImageUrl="~/images/alter.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 40px; vertical-align: top;">
                                        <%# MyContent((string)Eval("noticecontent"))%><a href="../Html/Notice/<%#DataBinder.Eval(Container.DataItem, "noticeHtmlName")%>.html" style="text-decoration:none;" target="_blank">更多</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 898px">
                                        时间：<%# DataBinder.Eval(Container.DataItem, "noticetime", "{0:yyyy-MM-dd}")%></td>
                                    <td style="width: 266px">
                                        发布人：<%# DataBinder.Eval(Container.DataItem, "noticeperson")%></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <AlternatingItemStyle BackColor="#F7F7F7" />
                        <ItemStyle BackColor="White" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    </asp:DataList></td>
            </tr>
            <tr>
                <td align="right">
                
                    <uc1:myPagenavigate ID="myPagenavigate1" runat="server" />
                
                </td>
            </tr>
            <tr>
                <td style="width: 390px">
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
