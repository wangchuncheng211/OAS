<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="InfoSend.aspx.cs" Inherits="WebAppOAS.MobileInfo.InfoSend" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
            margin:50px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" style="width: 711px;" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" colspan="2" style="height: 25px">
                发送短信息</td>
        </tr>
        <tr>
            <td align="right" style="width: 108px; height: 25px">
                信息接收者：</td>
            <td style="width: 657px; height: 10px">
                <asp:TextBox ID="txtAccepter" runat="server" Width="535px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 108px; height: 226px">
                <asp:CheckBoxList ID="chkblEmployee" runat="server" Width="95px">
                </asp:CheckBoxList></td>
            <td style="width: 657px; height: 226px">
                <asp:TextBox ID="txtInfo" runat="server" Height="276px" TextMode="MultiLine" Width="584px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="center" style="width: 108px;height:30px">
                <asp:ImageButton ID="imgBtnSubmit" runat="server" AlternateText="提交接收者" Height="21px"
                    OnClick="ImageButton1_Click" Width="73px" ImageUrl="~/images/tijiao.gif" /></td>
            <td align="center" style="width: 657px;height:30px">
                <asp:ImageButton ID="imgBtnSend" runat="server" AlternateText="发 送" OnClick="imgBtnSend_Click" ImageUrl="~/images/fasong.gif" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:ImageButton
                    ID="imgBtnClear" runat="server" AlternateText="清　空" Height="21px" Width="45px" OnClick="imgBtnClear_Click" ImageUrl="~/images/qingkong.gif" /></td>
        </tr>
    </table>
</asp:Content>
