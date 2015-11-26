<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="VotingResult.aspx.cs" Inherits="WebAppOAS.Communication.VotingResult" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:10px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" align="center" style="width: 591px; height: 1px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center"  colspan="3">
                活动投票结果</td>
        </tr>
        <tr>
            <td colspan="3" rowspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                    CellPadding="4" Height="23px" OnRowDeleting="GridView1_RowDeleting"
                    OnRowEditing="GridView1_RowEditing" Width="740px" GridLines="Horizontal" Font-Size="12px">
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="votetitle" HeaderText="标题" 
                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="votecontent" HeaderText="活动描述" 
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" >
<ItemStyle HorizontalAlign="Center" Width="300px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="agreeQty" HeaderText="赞成票数" 
                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="disagreeQty" HeaderText="反对票数" 
                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:HyperLinkField HeaderText="饼型图表" DataNavigateUrlFields="id" 
                            DataNavigateUrlFormatString="VotingResultPie.aspx?id={0}" Text="详细情况"  />
                        <asp:CommandField HeaderText="删除活动" ShowDeleteButton="True" 
                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:CommandField>
                        <asp:CommandField EditText="投票清零" HeaderText="投票清零" ShowEditButton="True" 
                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="第一页" LastPageText="最后一页"
                        NextPageText="下一页" PreviousPageText="上一页" Mode="NextPreviousFirstLast" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
