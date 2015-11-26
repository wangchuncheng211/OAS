<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnlineUser.ascx.cs" Inherits="WebAppOAS.UserControl.OnlineUser" %>

<div style="height:18px;float:left; width: 138px;">
    <asp:Label ID="lblUser" runat="server" Text="Label" Font-Size="12px"></asp:Label>   
</div>
<div style="height:18px;float:left">
    <asp:ImageButton ID="imgBtnLogonOut" runat="server" AlternateText="注　销" Height="18px"
          OnClick="imgBtnLogonOut_Click" Width="43px" ImageUrl="~/images/back_04.jpg" CausesValidation="False" />   
</div>