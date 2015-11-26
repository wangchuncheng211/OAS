<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="SystemDefault.aspx.cs" Inherits="WebAppOAS.SystemDefault" Title="企业办公自动化管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #welcome
        {
        	color:Blue;
        	font-size:30px;
        	text-align:center;
        	margin-top:150px;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="welcome">
        欢迎进入后台管理系统
    </div>
</asp:Content>
