<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="Voting.aspx.cs" Inherits="WebAppOAS.Communication.Voting" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:10px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" style="width: 520px; height: 191px" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 663px; height: 32px" align="center">
                活动投票</td>
        </tr>
        <tr>
            <td style="width: 663px; height: 133px">
                <asp:DataList ID="DataList1" runat="server" BackColor="White" Width="590px" 
                    OnItemCommand="DataList1_ItemCommand" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    Font-Size="12px">
                    <ItemTemplate>
                        <table border="0" style="width: 595px; height: 60px" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 97px; height: 5px">
                                    活动：</td>
                                <td style="width: 413px; height: 5px" align="center">
                                    <%# DataBinder.Eval(Container.DataItem,"votetitle") %>
                                </td>
                                <td style="height: 5px">
                                    <asp:LinkButton ID="linkbutton1" runat="server" CommandName="agree">赞成</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="linkbutton2" runat="server" CommandName="disagree">反对</asp:LinkButton>
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 97px">
                                    活动描述：</td>
                                <td colspan="2">
                                    <%#DataBinder.Eval(Container.DataItem, "votecontent")%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                </asp:DataList></td>
        </tr>
        <tr>
            <td style="width: 663px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
