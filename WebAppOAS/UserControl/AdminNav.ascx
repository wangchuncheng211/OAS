<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminNav.ascx.cs" Inherits="WebAppOAS.UserControl.AdminNav" %>
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
        ForeColor="#072EAB" Height="427px" ImageSet="BulletedList3" LineImagesFolder="~/icon" ShowExpandCollapse="False"
        Width="110px" BorderWidth="0px">
        
        <ParentNodeStyle Font-Bold="False" />
        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" /> 
        <Nodes>
            <asp:TreeNode Text="公告管理" Value="公告管理">
                <asp:TreeNode NavigateUrl="~/BaseInfo/BaseNoticeList.aspx" Text="查看公告" Value="查看公告"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/BaseInfo/BaseNoticeIssuance.aspx?mess=1" Text="发布公告" Value="发布公告"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="文件管理" Value="文件管理">
                <asp:TreeNode NavigateUrl="~/fileManage/FileSend.aspx" Text="传送文件" Value="传送文件"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/fileManage/FileAccept.aspx" Text="接收文件" Value="接收文件"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/fileManage/FileDelete.aspx" Text="删除文件" Value="删除文件"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/BaseInfo/BaseNoteBook.aspx" Text="记事本" Value="记事本"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="交流管理" Value="交流管理">
                <asp:TreeNode NavigateUrl="~/MobileInfo/InfoSend.aspx" Text="发送短信息" Value="发送短信息"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/Communication/VoteItemSetting.aspx" Text="设置投票活动" Value="设置投票活动"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/Communication/Voting.aspx" Text="活动投票" Value="活动投票"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/Communication/VotingResult.aspx" Text="查看投票结果" Value="查看投票结果"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="考勤管理" Value="考勤管理">
                <asp:TreeNode NavigateUrl="~/Communication/CheckAttendance/SetingTime.aspx" Text="考勤时间设置" Value="考勤时间设置"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/Communication/CheckAttendance/SignIn.aspx?id=1" Text="上班签到" Value="上班签到"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/Communication/CheckAttendance/SignIn.aspx?id=0" Text="下班签退" Value="下班签退"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="系统管理" Value="系统管理">
                <asp:TreeNode NavigateUrl="~/Sys/SystemUserPwdUpdate.aspx" Text="个人密码设置" Value="个人密码设置"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/Sys/SystemUser.aspx" Text="操作员设置" Value="操作员设置"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Checked="True" Text="部门管理" Value="部门管理">
                <asp:TreeNode NavigateUrl="~/BaseInfo/BaseDepartmentAdd.aspx" Text="新建部门" Value="新建部门"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/BaseInfo/BaseDepartmentManager.aspx" Text="编辑部门信息" Value="编辑部门信息"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="员工管理" Value="员工管理">
                <asp:TreeNode NavigateUrl="~/BaseInfo/BaseEmployeeAdd.aspx" Text="添加员工信息"  Value="添加员工信息"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/BaseInfo/BaseEmployeeManager.aspx" Text="编辑员工信息" Value="编辑员工信息"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="规章制度管理" Value="规章制度管理">
                <asp:TreeNode NavigateUrl="~/Rule/RuleUpdate.aspx" Text="更新规章制度" Value="更新规章制度"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/Rule/RulePreview.aspx" Text="预览规章制度" Value="预览规章制度"></asp:TreeNode>
            </asp:TreeNode>
            
        </Nodes>
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
    </asp:TreeView>

</div>