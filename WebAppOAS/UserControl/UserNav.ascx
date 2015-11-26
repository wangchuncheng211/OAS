<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNav.ascx.cs" Inherits="WebAppOAS.UserControl.UserNav" %>
<style type="text/css">
        #nav
        {
        	width:110px;
        	float:left;
            height: 427px;
        }
</style>

<div id="nav">
    <asp:TreeView ID="TreeView1" runat="server" Css Font-Size="Small"
          ForeColor="#072EAB" Height="253px" ImageSet="BulletedList3" LineImagesFolder="~/icon"
          ShowExpandCollapse="False" Width="110px">
          
          <ParentNodeStyle Font-Bold="False" />
          <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
          <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                                          
        <Nodes>
            <asp:TreeNode Text="桌面" Value="桌面">
                <asp:TreeNode Text="查看公告" Value="查看公告" NavigateUrl="~/BaseInfo/BaseNoticeList.aspx"></asp:TreeNode>
                <asp:TreeNode Text="规章制度" Value="规章制度" NavigateUrl="~/Rule/RulePreview.aspx"></asp:TreeNode>
                <asp:TreeNode Text="修改登录密码" Value="修改登录密码" NavigateUrl="~/Sys/SystemUserPwdUpdate.aspx"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/BaseInfo/BaseNoteBook.aspx" Text="记事本" Value="记事本">
            </asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="文件管理" Value="文件管理">
                <asp:TreeNode Text="传送文件" Value="传送文件" NavigateUrl="~/fileManage/fileSend.aspx"></asp:TreeNode>
                <asp:TreeNode Text="接收文件" Value="接收文件" NavigateUrl="~/fileManage/fileAccept.aspx"></asp:TreeNode>
                <asp:TreeNode Text="删除文件" Value="删除文件" NavigateUrl="~/fileManage/fileDelete.aspx"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="交流管理" Value="交流管理">
                <asp:TreeNode Text="发送短信息" Value="发送短信息" NavigateUrl="~/MobileInfo/InfoSend.aspx"></asp:TreeNode>
                <asp:TreeNode Text="活动投票" Value="活动投票" NavigateUrl="~/Communication/Voting.aspx"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="考勤管理" Value="考勤管理">
                <asp:TreeNode Text="上班签到" Value="上班签到" NavigateUrl="~/Communication/CheckAttendance/SignIn.aspx?id=1"></asp:TreeNode>
                <asp:TreeNode Text="下班签退" Value="下班签退" NavigateUrl="~/Communication/CheckAttendance/SignIn.aspx?id=0"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="行政管理" Value="行政管理">
                <asp:TreeNode Text="部门职责" Value="部门职责"  NavigateUrl="~/BaseInfo/BaseDepartmentListResponsibility.aspx"></asp:TreeNode>
                <asp:TreeNode Text="员工联系方式" Value="员工联系方式" NavigateUrl="~/BaseInfo/BaseEmployeeContactWay.aspx"></asp:TreeNode>
            </asp:TreeNode>
            
        </Nodes>
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
    </asp:TreeView>

</div>