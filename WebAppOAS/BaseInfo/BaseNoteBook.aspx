<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseNoteBook.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseNoteBook" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:0px auto;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" style="width: 648px; height: 138px" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center"  colspan="3">
                    记事本</td>
            </tr>
            <tr>
                <td style="width: 91px">
                    记事标题：</td>
                <td colspan="2">
                    <asp:TextBox ID="txtTitle" runat="server" Width="407px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="** 必填项" Width="146px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 91px">
                    记事内容：</td>
                <td colspan="2">
                    <asp:TextBox ID="txtContent" runat="server" Height="100px" TextMode="multiline" 
                        Width="451px"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnSave" runat="server" AlternateText="保　存" OnClick="imgBtnSave_Click" ImageUrl="~/images/save.gif" />
                </td>
            </tr>
            <tr>
                <td align="center"  colspan="3" style="height: 22px">
                    记事本信息列表</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                        CellPadding="4" GridLines="Horizontal" Height="1px" OnRowDataBound="GridView1_RowDataBound"
                        OnRowDeleting="GridView1_RowDeleting" Width="649px" Font-Size="12px" >
                        <PagerSettings FirstPageText="第一条" LastPageText="最后一条" NextPageText="下一条" PreviousPageText="上一条" Mode="NextPreviousFirstLast" />
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="title" HeaderText="标题">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="noteContent" HeaderText="内容">
                                <ItemStyle Width="260px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="notetime" HeaderText="记事时间">
                                <ItemStyle Width="80px" HorizontalAlign="Center"/>
                            </asp:BoundField>

                            <asp:CommandField HeaderText="删除信息" ShowDeleteButton="True" ShowHeader="True">
                                <ItemStyle Width="80px" HorizontalAlign="Center"/>
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
