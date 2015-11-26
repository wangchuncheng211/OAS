<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="BaseEmployeeAdd.aspx.cs" Inherits="WebAppOAS.BaseInfo.BaseEmployeeAdd" Title="企业办公自动化管理系统" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1
        {
        	margin:0 auto;
        	}
        .CommanHeight
        {
        	height:25px;
        	}
        .MyCalendar .ajax__calendar_container {
            border:1px solid #646464;
            background-color: lemonchiffon;
            color: red;
        }
        .MyCalendar .ajax__calendar_other .ajax__calendar_year,
        .MyCalendar .ajax__calendar_other .ajax__calendar_day {
            color: black;
        }
        .MyCalendar .ajax__calendar_hover .ajax__calendar_year,
        .MyCalendar .ajax__calendar_hover .ajax__calendar_month,
        .MyCalendar .ajax__calendar_hover .ajax__calendar_day {
            color: black;
        }
        .MyCalendar .ajax__calendar_active .ajax__calendar_year,
        .MyCalendar .ajax__calendar_active .ajax__calendar_month,
        .MyCalendar .ajax__calendar_active .ajax__calendar_day {
            color: black;
            font-weight:bold;
        }
    </style>
    <script src="../Js/jquery-1.7.min.js" type="text/javascript"></script>
    <script src="../Js/Area.js" type="text/javascript"></script>
    <script src="../Js/AreaData_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function (){
	        initComplexArea('seachprov', 'seachcity', 'seachdistrict', area_array, sub_array, '44', '0', '0');
        });

        //得到地区码
        function getAreaID(){
	        var area = 0;          
	        if($("#seachdistrict").val() != "0"){
		        area = $("#seachdistrict").val();                
	        }else if ($("#seachcity").val() != "0"){
		        area = $("#seachcity").val();
	        }else{
		        area = $("#seachprov").val();
	        }
	        return area;
        }

        //根据地区码查询地区名
        function getAreaNamebyID(areaID){
	        var areaName = "";
	        if(areaID.length == 2){
		        areaName = area_array[areaID];
	        }else if(areaID.length == 4){
		        var index1 = areaID.substring(0, 2);
		        areaName = area_array[index1] + " " + sub_array[index1][areaID];
	        }else if(areaID.length == 6){
		        var index1 = areaID.substring(0, 2);
		        var index2 = areaID.substring(0, 4);
		        areaName = area_array[index1] + " " + sub_array[index1][index2] + " " + sub_arr[index2][areaID];
	        }
	        return areaName;
        }
        
            function GetArea() {
	        //地区码
	        var areaID = getAreaID();
	        //地区名
	        var areaName = getAreaNamebyID(areaID);
	        document.getElementById("<%=Hidden1.ClientID %>").value=areaName;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="table1" align="center" border="0" cellspacing="0" >
            <tr class="CommanHeight">
                <td align="center" colspan="3">
                    －＝注册员工基本信息＝－</td>
            </tr>
            <tr class="CommanHeight">
                <td align="right" style="width:200px">
                    员工姓名：</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtName"
                        ErrorMessage="**　必填项"></asp:RequiredFieldValidator></td>
            </tr>
            <tr class="CommanHeight" style="vertical-align:top">
                <td align="right">
                    员工性别：</td>
                <td style="width:350px">
                    <asp:DropDownList ID="dlSex" runat="server">
                        <asp:ListItem>男性</asp:ListItem>
                        <asp:ListItem>女性</asp:ListItem>
                    </asp:DropDownList></td>
                <td rowspan="2" style="height:76px">    
                    <asp:Image ID="Image1" runat="server" AlternateText="相 片" Width="76px" />
                </td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    相片路径：</td>
                <td style="width:350px">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <%--<input id="File1" runat="server" type="file" />--%>&nbsp;<asp:ImageButton 
                        ID="ImageButton3" runat="server" AlternateText="上传图片" 
                        OnClick="ImageButton3_Click" ImageUrl="~/images/shangchuan.gif" 
                        CausesValidation="False" /></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    出生日期：</td>
                <td colspan="2">
                    <asp:TextBox ID="txtBirthday" runat="server" Width="140px"></asp:TextBox><%--(例:2014-12-12)--%>
                    <asp:ImageButton ID="ImgBtnCalendar" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" CausesValidation="false" />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBirthday" PopupButtonID="ImgBtnCalendar" Format="yyyy/MM/d" CssClass="MyCalendar"></cc1:CalendarExtender>
                    <%--<asp:CompareValidator ID="comparevalidator1" runat="server" ControlToValidate="txtBirthday"
                        ErrorMessage="(格式:yyyy/mm/dd)" Operator="datatypecheck" Type="date" 
                        Width="147px"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ControlToValidate="txtBirthday"
                        ErrorMessage="**　必填项"></asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    学 历：</td>
                <td colspan="2">
                    <asp:TextBox ID="txtLearn" runat="server" Width="140px"></asp:TextBox>
                    <asp:CustomValidator ID="customvalidator1" runat="server" ControlToValidate="txtLearn"
                        ErrorMessage="**　必填项"></asp:CustomValidator></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    员工职称：</td>
                <td colspan="2">
                    <asp:TextBox ID="txtPost" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredfieldvalidator2" runat="server" ControlToValidate="txtpost"
                        ErrorMessage="**　必填项"></asp:RequiredFieldValidator></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    部门：</td>
                <td colspan="2">
                    <asp:DropDownList ID="dlDepartment" runat="server" DataTextField="name" DataValueField="name" Width="140px">
                    </asp:DropDownList></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    职位：</td>
                <td colspan="2">
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
                <td align="right">
                    手机号码：</td>
                <td colspan="2">
                    <asp:TextBox ID="txtTel" runat="server" Width="140px"></asp:TextBox>&nbsp;
                    <asp:RegularExpressionValidator ID="regularexpressionvalidator2" runat="server" ControlToValidate="txttel"
                        ErrorMessage="**　格式不正确　例如:136****1234" ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator5" runat="server" ControlToValidate="txtTel"
                        ErrorMessage="**　必填项"></asp:RequiredFieldValidator></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    地址：</td>
                <td colspan="2">
                    <select id="seachprov" name="seachprov" onChange="changeComplexProvince(this.value, sub_array, 'seachcity', 'seachdistrict');"></select>&nbsp;&nbsp;
                    <select id="seachcity" name="homecity" onChange="changeCity(this.value,'seachdistrict','seachdistrict');"></select>&nbsp;&nbsp;
                    <span id="seachdistrict_div"><select id="seachdistrict" name="seachdistrict"></select></span>&nbsp;&nbsp;
                    <asp:TextBox ID="txtAddress" runat="server" Width="100px" ></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="requiredfieldvalidator3" runat="server" ControlToValidate="txtaddress"
                        ErrorMessage="**　必填项"></asp:RequiredFieldValidator>
                    <input id="Hidden1" type="hidden" runat="server" />
                    </td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    e_mail:</td>
                <td colspan="2">
                    
                    <asp:TextBox ID="txtEmail" runat="server" Width="150px"></asp:TextBox>&nbsp; 
                    <asp:RegularExpressionValidator ID="regularexpressionvalidator3" runat="server" ControlToValidate="txtemail"
                        ErrorMessage="**　格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr class="CommanHeight">
                <td align="right">
                    状态：</td>
                <td colspan="2">
                    <asp:DropDownList ID="dlState" runat="server" Width="60px">
                        <asp:ListItem>在职</asp:ListItem>
                        <asp:ListItem>离职</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr class="CommanHeight">
                <td align="center" colspan="3" style="height: 2px">
                    <asp:ImageButton ID="imgBtnSave" runat="server" AlternateText="保 存" 
                         ImageUrl="~/images/save.gif" style="height: 21px" OnClientClick="GetArea()" OnClick="imgBtnSave_Click" />
                    &nbsp;
                    <asp:ImageButton ID="imgBtnClear" runat="server" AlternateText="清　空" 
                        OnClick="imgBtnClear_Click" ImageUrl="~/images/qingkong.gif" 
                        CausesValidation="False" /></td>
            </tr>
        </table>
</asp:Content>
