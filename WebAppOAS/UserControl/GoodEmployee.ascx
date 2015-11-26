<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoodEmployee.ascx.cs" Inherits="WebAppOAS.UserControl.GoodEmployee" %>

<asp:Image ID="Image" runat="server" ImageUrl="~/images/index_16.jpg" />
<div id="demo" style="height:400px; width:220px;border:2px solid #e0e0e0; overflow:hidden;">
        <div id="demo1">  
<asp:DataList ID="DataList1" runat="server"
    BorderStyle="none" BorderWidth="0px" CellPadding="0" GridLines="horizontal" Width="224px" BackColor="#F0F0F1">
    
    <ItemTemplate>
        <table border="0" cellspacing="0"  style="width: 220px; height: 70px;
            background-color: #ffffff; font-size:12px" cellpadding="0">
            <tr>
                <td rowspan="3" style="margin-left: 0px; margin-right: 0px; width: 73px;">
                    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Show.aspx">--%>
                        <asp:Image ID="image1" runat="server" Height="96px" 
                        ImageUrl='<%# DataBinder.Eval(Container.DataItem,"photopath") %>' Width="80px" />
                    <%--</asp:HyperLink>--%></td>
                <td align="left" colspan="2" style="width: 107px">
                    姓名：<%# DataBinder.Eval(Container.DataItem, "name")%></td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="width: 107px">
                    部门：<%# DataBinder.Eval(Container.DataItem, "dept")%></td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="width: 107px">
                    职务：<%# DataBinder.Eval(Container.DataItem, "job")%></td>
            </tr>
            <tr>
                <td align="left" bgcolor="#f0f0f1" colspan="3" style="height: 20px">
                </td>
            </tr>
        </table>
    </ItemTemplate>
    
    <FooterStyle BackColor="White" ForeColor="#4A3C8C" />
    <SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" />
    <AlternatingItemStyle BackColor="White" BorderColor="White" />
    <ItemStyle BackColor="White" ForeColor="#4A3C8C" />
    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#F7F7F7" />
    <EditItemStyle BackColor="White" />
</asp:DataList>
        </div>
        <!--滚动的javascript-->  
        <script>  
        var speed=20;
        demo1.innerHTML=demo1.innerHTML+demo1.innerHTML; 
        //demo.scrollTop表示demo在垂直方向上已滚动的距离。
        //demo.scrollHeight表示demo在垂直方向上的总高度。
        function Marquees(){  
        demo.scrollTop++;
        if(demo.scrollTop>=demo.scrollHeight/2)
           demo.scrollTop=0;     
        }  

        var MyMars=setInterval(Marquees,speed);
        demo.onmouseover=function() { clearInterval(MyMars); }  
        demo.onmouseout=function() { MyMars=setInterval(Marquees,speed); }  

        </script><!--滚动的javascript结束-->  
</div>