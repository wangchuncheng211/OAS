<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseEmployeeManager.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseEmployeeManager" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:10px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" cellpadding="0" cellspacing="0" style="height:1px">
            <tr>
                <td align="center"  colspan="3">
                    －＝员工基本信息＝－</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 18px">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="2px"
                        CellPadding="2" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting"
                        PageSize="15" Width="736px" GridLines="Horizontal" Height="97px" Font-Size="12px">
                        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
                            NextPageText="下一页" PreviousPageText="上一页" />
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="name" HeaderText="姓名" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sex" HeaderText="性别" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="learnDegree" HeaderText="学历" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="post" HeaderText="职称" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dept" HeaderText="部门" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="job" HeaderText="职务" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tel" HeaderText="联系电话" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="address" HeaderText="联系地址" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="state" HeaderText="在职否" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="50px" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="BaseEmployeeUpdate.aspx?id={0}"
                                HeaderText="编辑" Text="编辑" ItemStyle-HorizontalAlign="Center"/>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
</asp:Content>
