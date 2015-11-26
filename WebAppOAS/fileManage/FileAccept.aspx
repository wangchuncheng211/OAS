<%@ Page Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="FileAccept.aspx.cs" Inherits="WebAppOAS.fileManage.FileAccept" Title="企业办公自动化管理系统" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #table1{
            margin:10px auto;
        }
        .sysPage
        {
        	font-size:12px;
            background:#e1cbcb;
            float:right;
            margin-top:10px;
        	margin-right:30px;
        	}
    </style>
    <script type="text/javascript" src="../Js/XMLDoxParse.js"></script>
    <script type="text/javascript" src="../Js/AjaxAcceptFile.js"></script>
    <script type="text/javascript" src="../Js/ShowFileInfo.js"></script>
    <script type="text/javascript">       function changeExamine(fileID,intRow)
       {
            document.getElementById("examine"+intRow).innerHTML = "已接收";
            
            FileAccept.UpdateFileExaminByFileID(fileID);
            
//            var xmldoc = parseXMLDoc("../Xml/FileInfoXml/FileInfo.xml"); 
//            
//            var tmpTag =  xmldoc.getElementsByTagName("Table1"); 
//            
//            for(var j=0; j<tmpTag.length; j++)
//            {
//                var x = tmpTag[j].getElementsByTagName("fileID")[0];//                  if(x.firstChild.nodeValue == fileID)//                  {//                    x.parentNode.childNodes[7].firstChild.nodeValue = "已接收";//                    alert(x.parentNode.childNodes[7].firstChild.nodeValue);//                  }
//            }
            
       }     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" align="center" border="0" style="width: 536px; height: 1px" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center"  colspan="3" style="height: 1px">
                －＝文件接收＝－</td>
        </tr>
        <tr>
            <td align="right" colspan="3" style="height: 1px">
                <input id="Radio1" type="radio" name="examine" checked="checked" onclick="NotReceivedClick()" />未接收&nbsp;&nbsp;
                <input id="Radio2" type="radio" name="examine" onclick="ReceivedClick()" />已接收
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="divContent">正在获取数据...</div>
                   <script type="text/javascript">
                           NotReceivedClick();
                   </script>
            </td>
        </tr>
    </table>
</asp:Content>
