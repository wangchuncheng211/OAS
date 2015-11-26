# OAS
ASP.NET基于复杂三层架构工厂模型的企业办公自动化管理系统



《.NET实例开发》

综合设计使用说明书




题目：       办公自动化管理系统           
成员：   
   王春城    计科123     20121111098   
	 蔡宇渊    计科123      20121111118   
指导老师：    李璟                        
完成日期：   2015年  6月 5日            




网站总体简介
1.总体介绍
a)网站名：企业办公自动化管理系统
b)Framework版本：3.5
c)数据库名：sqlserver2005 access2003
d)Sqlserver版本：2005
2.三层架构
a)Dal层：数据访问层，包括数据库的操作等（IDAL为BLL层提供了统一的接口SQLDAL和OleDbDAL都派生自IDAL；SQLDAL，OleDbDAL构造SQL语句传递给DBUtility，DBUtility，SQLDAL传递操作SQLServer数据库的SQL语句，OleDbDAL传递操作Access数据库的SQL语句；DBUtility用于执行传递过来的SQL语句；DALFactory根据需要生成针对SQLDAL和OleDbDAL操作的接口）
b)Bll层：业务逻辑层，用于处理dal层得到的数据库中的数据
c)Web层：表示层，呈现给用户的网站界面，与用户互动
3.页面简介
  WebAppOAS层
Default.aspx：首页
BaseDepartmentAdd.aspx：OA系统部门的新建和描述
BaseDepartmentListResponsibility.aspx：OA系统部门职责描述
BaseDepartmentManager.aspx：OA系统部门的管理
BaseEmployeeAdd.aspx：企业新员工添加
BaseEmployeeContactWay.aspx：企业员工联系方式
BaseNoteBook.aspx：OA系统记事本
BaseNoticeIssuance.aspx：公告发布
BaseNoticeList.aspx：公告查看
SetingTime.aspx：上下班时间设置
SignIn.aspx：上班签到和下班签退处理
VoteItemSetting.aspx：投票活动设置
VotingResult.aspx：投票结果显示
Voting.aspx：进行活动的投票
FileAccept.aspx：OA系统文件接收
FileDelete.aspx：OA系统文件的删除
FileSend.aspx：文件的发送
InfoSend.aspx：OA系统短信息的发送
RulePreview.aspx：工作制度预览
RuleUpdate.aspx：公司制度的更新
SystemUserPwdUpdate.aspx：用户密码更改
SystemUser.aspx：系统用户管理
BackStage.Master：后台的母版页
Global.asax：全局处理的一些设置
  BLL层
Department.cs：部门业务逻辑处理；
Employee.cs：员工业务逻辑处理；
File.cs：传送文件业务逻辑处理；
Note.cs：记事本业务逻辑处理；
Notice.cs：公告业务逻辑处理；
Rule.cs：规章制度业务逻辑处理；
Sign.cs：签到业务逻辑处理；
signState.cs：签到时间设置业务逻辑处理；
sysUser.cs：系统用户业务逻辑处理；
Vote.cs：投票业务逻辑处理；
  IDAL层
Idepartment.cs：部门数据访问层接口；
Iemployee.cs：员工数据访问层接口；
Ifile.cs：文件数据访问层接口；
Inote.cs：记事本数据访问层接口；
Inotice.cs：公告数据访问层接口；
Irule.cs：规章制度数据访问层接口；
Isign.cs：签到处理数据访问层接口；
IsignState.cs：签到时间设置数据访问层接口；
IsysUser.cs：系统用户数据访问层接口；
Ivote.cs：投票数据访问层接口；
  SQLDAL层（访问SQL Server）
SQLdepartment.cs：部门数据访问；
SQLemployee.cs：员工数据访问；
SQLfile.cs：文件传输数据访问；
SQLnote.cs：记事本数据访问；
SQLnotice.cs：公告数据访问；
SQLrule.cs：规章制度数据访问；
SQLsign.cs：签到数据访问；
SQLsignState.cs：签到时间设置数据访问；
SQLsysUser.cs：系统用户数据访问；
SQLvote.cs：投票数据访问；
OleDbDAL层（访问Access）
OleDbdepartment.cs：部门数据访问；
OleDbemployee.cs：员工数据访问；
OleDbfile.cs：文件传输数据访问；
OleDbnote.cs：记事本数据访问；
OleDbnotice.cs：公告数据访问；
OleDbrule.cs：规章制度数据访问；
OleDbsign.cs：签到数据访问；
OleDbsignState.cs：签到时间设置数据访问；
OleDbsysUser.cs：系统用户数据访问；
OleDbvote.cs：投票数据访问；
  DALFactory层
DataAccess.cs：数据访问工厂类（选择用Access还是SQL Server）；
  MODEL层
MDepartment.cs：部门实体类；
MEmployee.cs：员工实体类；
MFile.cs：文件实体类；
MNote.cs：记事本实体类；
MNotice.cs：公告实体类；
MRule.cs：规章制度实体类；
MSign.cs：签到实体类；
MSignState.cs：签到时间设置实体类；
MSysUser.cs：系统用户实体类；
MVote.cs：投票实体类；
  DBUtility层
OleDbHelper.cs：Access数据库SQL执行层；
SQLDbHelper.cs：SQL Server数据库SQL执行层；
本地运行说明书
注：确保本地PC机安装了Microsoft Visual Studio 2008和sqlserver2005或者更高版本。
1.网站打开
双击网站文件夹下的OAS.sln文件，利用Microsoft Visual Studio 2008打开网站解决方案。
2.网站运行
1)右击“解决方案资源管理器“中的”web“文件夹下的Default.aspx，选择”在浏览器中查看“在浏览器中看到网站的登陆界面
2)在主页面时可以直接查看系统公告
3)利用wcc用户名和密码111,在输入正确的验证码选择管理员登陆即可登陆。
  注：登录名和密码输入有验证控件验证，不能为空。验证码输入错误需要重新输入才能进行登录。
4)点击查看公告，进行历史公告的查看和管理
5)点击发布公告可以进行公告发布
6)点击文件传送进行文件的传送
7)点击接收文件进行文件的接收
  同时也可以查看已接收的文件
8)点击文件删除进行接收文件的管理
9)点击记事本进行常用事务的记录
10)点击发送短信息进行信息的发送
11)点击设置投票活动进行投票的设置
12)点击活动投票可以进行当前有效活动投票
13)点击投票结果查看可以看到历史投票的结果
   同时可以查看投票的比例，点击详细情况，应用饼状图进行显示
14)点击考勤时间设置可以进行上下班时间的设置
15)点击上班签到和下班签退可以分别进行上下班的签到签退活动
16)电子个人密码设置可以进行密码的设置
17)点击操作员设置可以进行操作员和登录用户身份角色的设置
18)点击新建部门进行部门的新建
19)点击编辑部门信息进行部门信息的编辑
20)点击添加员工信息进行新员工信息的录入和添加
21)点击编辑员工信息进行员工信息的编辑
22)点击更新公司规章制度可以进行规章制度的修改和调整
23)点击预览规章制度可以进行规章制度的预览
24)注销当前用户，重新利用蔡宇渊用户名和密码111,在输入正确的验证码选择普通用户登陆。
   注：登录名和密码输入有验证控件验证，不能为空。验证码输入错误需要重新输入才能进行登录。
25)点击公告查看和规章制度预览可以分别进行公告和规章制度的预览和查看
26)点击修改登录密码进行当前用户的密码修改
27)点击记事本进行事务的记录
28)点击传送文件进行文件的传送
29)点击接收文件进行文件接收
30)点击删除文件对接收的文件进行管理
31)点击发送短信息进行短信息发送
32)点击活动投票进行相应活动的投票
33)点击上班签到进行上班的签到
34)点击下班签退进行下班签退
35)点击部门职责进行部门职责的查看
36)点击员工联系方式查看员工联系方式
以上是本网站的全部功能。
