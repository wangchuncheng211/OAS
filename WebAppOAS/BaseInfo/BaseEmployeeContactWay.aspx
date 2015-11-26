<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseEmployeeContactWay.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseEmployeeContactWay" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:0 auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" cellpadding="0" cellspacing="0" style="width: 696px; height: 139px">
            <tr>
                <td align="center" style="height: 31px">
                    －＝员工联系方式＝－</td>
            </tr>
            <tr>
                <td>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="2px"
            CellPadding="2" GridLines="Horizontal" Height="97px" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" Width="697px" Font-Size="12px">
            <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
                NextPageText="下一页" PreviousPageText="上一页" />
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="姓名">
                    <HeaderStyle Width="40px" HorizontalAlign="Left" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="sex" HeaderText="性别">
                    <HeaderStyle Width="30px" HorizontalAlign="Left" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="dept" HeaderText="部门">
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
                    <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="job" HeaderText="职务">
                    <HeaderStyle Width="50px" HorizontalAlign="Left" />
                    <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="tel" HeaderText="联系电话">
                    <HeaderStyle Width="60px" HorizontalAlign="Left" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="address" HeaderText="联系地址">
                    <HeaderStyle Width="100px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="state" HeaderText="在职否">
                    <HeaderStyle Width="50px" HorizontalAlign="Left" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
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
