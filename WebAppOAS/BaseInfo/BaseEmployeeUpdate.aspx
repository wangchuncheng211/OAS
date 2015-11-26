<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseEmployeeUpdate.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseEmployeeUpdate" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:50px auto;
        	}
        .CommanHeight
        {
        	height:30px;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" style="width: 488px" border="0" cellpadding="0" cellspacing="0">
            <tr class="CommanHeight">
                <td style="width: 112px; height: 27px">
                </td>
                <td style="width: 244px; height: 27px">
                    修改员工资料</td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    员工姓名：</td>
                <td style="width: 244px">
                    <asp:TextBox ID="txtName" runat="server" Width="140px"></asp:TextBox></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    员工性别：</td>
                <td style="width: 244px">
                    <asp:DropDownList ID="dlSex" runat="server" Width="52px">
                        <asp:ListItem>男性</asp:ListItem>
                        <asp:ListItem>女性</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    出生日期：</td>
                <td style="width: 244px">
                    <asp:TextBox ID="txtBirthday" runat="server" Width="140px"></asp:TextBox></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    学 历：</td>
                <td style="width: 244px">
                    <asp:TextBox ID="txtLearn" runat="server" Width="140px"></asp:TextBox></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    员工职称：</td>
                <td style="width: 244px">
                    <asp:TextBox ID="txtPost" runat="server" Width="140px"></asp:TextBox></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    部门：</td>
                <td style="width: 244px">
                    <asp:DropDownList ID="dlDepartment" runat="server" DataTextField="name" DataValueField="name"
                        Width="140px">
                    </asp:DropDownList></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    职位：</td>
                <td style="width: 244px">
                    <asp:DropDownList ID="dlJob" runat="server" Width="140px">
                        <asp:ListItem>董事长</asp:ListItem>
                        <asp:ListItem>总经理</asp:ListItem>
                        <asp:ListItem>副总经理</asp:ListItem>
                        <asp:ListItem>部门经理</asp:ListItem>
                        <asp:ListItem>部门主管</asp:ListItem>
                        <asp:ListItem>普通职员</asp:ListItem>
                        <asp:ListItem>秘书长</asp:ListItem>
                        <asp:ListItem>秘书</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    电话：</td>
                <td style="width: 244px">
                    <asp:TextBox ID="txtTel" runat="server" Width="140px"></asp:TextBox></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    地址：</td>
                <td style="width: 244px">
                    <asp:TextBox ID="txtAddress" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    E_mail：</td>
                <td style="width: 244px">
                    <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width: 112px">
                    状态：</td>
                <td style="width: 244px">
                    <asp:DropDownList ID="dlState" runat="server" Width="60px">
                        <asp:ListItem>在职</asp:ListItem>
                        <asp:ListItem>离职</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr class="CommanHeight">
                <td style="width: 112px">
                </td>
                <td style="width: 244px">
                    <asp:ImageButton ID="imgBtnSave" runat="server" AlternateText="保 存" OnClick="imgBtnSave_Click" ImageUrl="~/images/save.gif" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnReturn" runat="server" AlternateText="返　回" OnClick="imgBtnReturn_Click" ImageUrl="~/images/back.jpg" /></td>
            </tr>
        </table>
</asp:Content>
