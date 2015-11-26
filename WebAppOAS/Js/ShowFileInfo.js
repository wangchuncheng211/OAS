function ReceivedClick()
{
    G_page=0;//从首页开始显示
    LoadXml('../Xml/FileInfoXml/ReceivedFileInfo');
    showContent('../Xml/FileInfoXml/ReceivedFileInfo','Table1','divContent');
}
function NotReceivedClick()
{
    G_page=0;//从首页开始显示
    LoadXml('../Xml/FileInfoXml/NotReceivedFileInfo');
    showContent('../Xml/FileInfoXml/NotReceivedFileInfo','Table1','divContent');
}

//加载xml
function LoadXml(xmlname)
  {
   var xmlFile = xmlname+".xml"; // xml文件
   xmlDoc = parseXMLDoc(xmlFile); // 调用方法parseXMLDoc()加载解析XML文件 
//   //检索的记录数
//   maxNum = xmlDoc.getElementsByTagName(colname).length;
//   //每条记录的列对象
//   column=xmlDoc.getElementsByTagName(colname).item(0).childNodes;
//   //每条记录的列数
//   colNum=column.length;
   //总页数
//   G_pagesNumber = Math.ceil(maxNum/G_pagenum)-1; 
  }
  
//显示当前页中的公告信息
function showContent(xmlname,colname,showID)
  {
   var tmpTag = "null"; //获取行对象集
   var tmpCol = "null"; //获取每行对象
   var P1,P2,P3,P4,P5,P6,P7,P8,P9; //参数集
   //获取XML名称
   G_xmltmpname=xmlname;
   //获取列名称
   G_coltmpname=colname;
   //获取用户展示对象ID
   G_showtmpID=showID;
     //检索的总记录数
  var maxNum = xmlDoc.getElementsByTagName(colname).length;
  G_pagesNumber = Math.ceil(maxNum/G_pagenum)-1;
   if (maxNum!=0)
   {
      //G_pagenum为每页显示数量。已定义G_pagenum=
   	  //page为当前页页码。
   	  if (!G_page) G_page=0;   	  
      var n = G_page * G_pagenum; //开始记录号
      endNum = (G_page+1) * G_pagenum; //结束段记录号
      if (endNum>maxNum) endNum=maxNum; //超出时为最大记录号
      //循环分段获取数据
      tmpTag = xmlDoc.getElementsByTagName(colname); 
      for (; n<endNum; n++){ 
          tmpCol = tmpTag[n];
          P1 = tmpCol.getElementsByTagName("fileID")[0].firstChild.nodeValue;
          P2 = tmpCol.getElementsByTagName("fileSender")[0].firstChild.nodeValue; 
          P3 = tmpCol.getElementsByTagName("fileAccepter")[0].firstChild.nodeValue; 
          P4 = tmpCol.getElementsByTagName("fileTitle")[0].firstChild.nodeValue;
          P5 = tmpCol.getElementsByTagName("fileTime")[0].firstChild.nodeValue;
          P6 = tmpCol.getElementsByTagName("fileContent")[0].firstChild.nodeValue;
          P7 = tmpCol.getElementsByTagName("path")[0].firstChild.nodeValue;
          P8 = tmpCol.getElementsByTagName("examine")[0].firstChild.nodeValue;
          P9 = tmpCol.getElementsByTagName("fileName")[0].firstChild.nodeValue;
          G_divPageContent += RuleInput(P1,P2,P3,P4,P5,P6,P7,P8,P9,n); 
        }
       //在页面中显示
        document.getElementById(showID).innerHTML=G_divPageContent+"<div class='sysPage'>"+pageBar(G_page)+"</div>";
        var myn = G_page * G_pagenum; //开始记录号  	
        for(; myn < endNum; myn++)
        {
            if(document.getElementById("examine"+myn).innerHTML=="已接收")
            {document.getElementById("lnkExamine"+myn).style.display = "none";}
        }	
      }
   else
    {
   	 document.getElementById(showID).innerHTML='没有获取合适数据!';
	}
   //清空数据 
   G_divPageContent="";
 }
 
 //格式化输出 
 function RuleInput(p1,p2,p3,p4,p5,p6,p7,p8,p9,intRow)
   { 
    //默认背景色
    var TmpBgColor="#eee";
    //偶数时发生变化
    if (intRow%2==1) 
    {
        TmpBgColor="#fff";
    }
    //格式化内容
    var TmpShow  ="<div class='sysRcontent' style='background:"+TmpBgColor+";width:700px;'>";
        TmpShow +="<table border='0' style='width:700px;font-size:12px' cellpadding='0' cellspacing='0'>";
        TmpShow +="    <tr>";
        TmpShow +="        <td align='center' style='width:80px;height:18px;'>";
        TmpShow +="            文件标题：</td>";
        TmpShow +="        <td align='left'  colspan='2' style='height:18px'>"+p4+"</td>";
        TmpShow +="    </tr>";
        TmpShow +="    <tr>";
        TmpShow +="        <td align='center' style='height:18px'>";
        TmpShow +="            来自：</td>";
        TmpShow +="        <td style='width: 237px'>"+ p2 +"</td>";
        TmpShow +="        <td align='center'>";
        TmpShow +="            接收状态：<label id='examine"+intRow+"'>"+p8+"</label>";
        TmpShow +="            <a id='lnkExamine"+intRow+"' onclick='changeExamine("+p1+","+intRow+")' style='color:blue;cursor:pointer;' >确认接收</a></td>";
        TmpShow +="    </tr>";
        TmpShow +="    <tr>";
        TmpShow +="       <td align='center' style='height:35px;'>";
        TmpShow +="            文件内容：</td>";
        TmpShow +="        <td colspan='2' style='height:35px'>"+p6+"</td>";
        TmpShow +="    </tr>";
        TmpShow +="    <tr>";
        TmpShow +="        <td align='center' style='height:18px;'>";
        TmpShow +="            附件：</td>";
        TmpShow +="        <td align='center' style='width:237px;height:18px;'>"+p9+"";
        TmpShow +="            <a href='"+p7.toString().substring(1,p7.toString().length)+"'>下载</a>";
        TmpShow +="        </td>";
        TmpShow +="        <td style='height:18px'>";
        TmpShow +="            时间："+p5.substring(0,10)+"</td>";
        TmpShow +="   </tr>";
        TmpShow +="</table>";
        TmpShow +="</div>";

    return TmpShow; 
   } 
   

  
//   window.onload = function(){//等待页面内DOM、图片资源加载完毕后触发执行

//}