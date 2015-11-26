<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseDepartmentListResponsibility.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseDepartmentListResponsibility" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:50px auto;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" cellpadding="0" cellspacing="0" style="width: 700px;
            height: 1px">
            <tr>
                <td align="center"  colspan="3" style="height: 15px">
                    －＝部门职责＝－</td>
            </tr>
            <tr>
                <td align="left" colspan="3" style="height: 76px">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                        CellPadding="4" DataKeyNames="deptid" Font-Size="Small" GridLines="Horizontal"
                        OnPageIndexChanging="GridView1_PageIndexChanging"
                        Width="700px">
                        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
                            NextPageText="下一页" PreviousPageText="上一页" />
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="部门名称">
                                <HeaderStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="duty_description" HeaderText="部门描述">
                                <HeaderStyle Width="200px" />
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
