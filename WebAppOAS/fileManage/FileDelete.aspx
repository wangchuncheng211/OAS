<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="FileDelete.aspx.cs" Inherits="WebAppOAS.fileManage.FileDelete" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1{
            margin:10px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" align="center" style="width: 645px; height: 1px" border="0" cellpadding="0">
        <tr>
            <td align="center"  colspan="3" style="width: 685px; height: 31px">
                －＝删除文件＝－</td>
        </tr>
        <tr>
            <td colspan="3" style="height: 17px; width: 685px;">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                    CellPadding="4" Height="38px" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowDeleting="GridView1_RowDeleting" Width="682px" GridLines="Horizontal" Font-Size="12px">
                    
                    <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
                        NextPageText="下一页" PreviousPageText="上一页" />
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="fileid" HeaderText="id" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="filesender" HeaderText="发送人" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="fileaccepter" HeaderText="接收人" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="filetitle" HeaderText="文件标题" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="filetime" HeaderText="发送时间" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="filecontent" HeaderText="文件说明" ItemStyle-HorizontalAlign="Center"/>
                        <asp:CommandField DeleteImageUrl="~/icon/del.gif" HeaderText="删除文件" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center"/>
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
