<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseDepartmentManager.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseDepartmentManager" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:50px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" style="width: 700px; height: 1px" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center"  colspan="3" style="height: 15px">
                    －＝编辑部门信息＝－</td>
            </tr>
            <tr>
                <td align="left" colspan="3" style="height: 76px">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                        CellPadding="4" DataKeyNames="deptid" Font-Size="Small" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDeleting="GridView1_RowDeleting" Width="700px" GridLines="Horizontal">
                        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
                            NextPageText="下一页" PreviousPageText="上一页" />
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="部门名称" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="duty_description" HeaderText="部门描述" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="200px" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="BaseDepartmentUpdate.aspx?id={0}"
                                HeaderText="编辑部门" Text="编辑" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="60px" />
                            </asp:HyperLinkField>
                            <asp:CommandField HeaderText="删除部门" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="60px" />
                                <ItemStyle Font-Size="Small" />
                            </asp:CommandField>
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
