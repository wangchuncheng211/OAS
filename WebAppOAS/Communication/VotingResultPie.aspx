<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="VotingResultPie.aspx.cs" Inherits="WebAppOAS.Communication.VotingResultPie" Title="活动投票结果图表" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width:480px;height:460px;margin:10px auto;">
<img id="ImgPie" alt="看不清，请点击我！" onclick="this.src=this.src+'?'" src="../GDI/Pie.aspx?Sum=<%= Sum %>&AgreeQty=<%= AgreeQty %>&DisagreeQty=<%= DisagreeQty %>"
                                        style="width:420px; height:450px; " align="left" />
</div>
</asp:Content>
