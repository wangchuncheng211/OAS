<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="WebAppOAS.UserControl.Login" %>

<table border="0" cellpadding="0" cellspacing="0" bgcolor="#f0f0f1" style="width: 224px; font-size:12px;">
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/index_13.jpg" /></td>
    </tr>
    <tr style="line-height:20px">
        <td align="center" >
            &nbsp;&nbsp;<span style="display:-moz-inline-box;display:inline-block;width:50px">用户名：</span>
            <asp:TextBox ID="txtName" runat="server" Width="113px"></asp:TextBox></td>
    </tr>
    <tr style="line-height:20px">
        <td align="center">
            &nbsp;&nbsp;<span style="display:-moz-inline-box;display:inline-block;width:50px">密&nbsp;码：</span>
            <asp:TextBox ID="txtPwd" runat="server" TextMode="password" Width="113px"></asp:TextBox></td>
    </tr>
    <tr style="line-height:20px">
        <td align="center">
            &nbsp;&nbsp;<span style="display:-moz-inline-box;display:inline-block;width:50px">验证码：</span>
            <asp:TextBox ID="Validator" runat="server" TextMode="password" Width="113px"></asp:TextBox>
                </td>
    </tr>
    <tr style="line-height:20px">
        <td align="center">
            <span style="color:Blue;">点击刷新</span>
            <span style="display:-moz-inline-box;display:inline-block;width:50px;">
                <img id="Img1" alt="看不清，请点击我！" onclick="this.src=this.src+'?'" src="../GDI/CheckCode.aspx"
                                        style="width: 73px; height: 22px" align="left" /></span>  
        </td>
    </tr>
    <tr style="line-height:20px;">
        <td align="center">
            <label>
                &nbsp;<asp:RadioButton ID="rdoBtnAdmin" runat="server" Text="管理员登录" GroupName="Check" />
                <asp:RadioButton ID="rdoBtnEmployee" runat="server" Text="职员登录" Checked="True" GroupName="Check" /></label></td>
    </tr>
    <tr style="line-height:20px; font-size:14px;">
        <td align="center" height="11">
            &nbsp;<asp:Button ID="btnLogin" runat="server"  Font-Size="smaller"
                OnClick="btnLogin_Click" Text="登  录" />&nbsp;
            <asp:Button ID="btnCandel" runat="server"  Font-Size="smaller"
                OnClick="btnCandel_Click" Text="取 消" /></td>
    </tr>

</table>