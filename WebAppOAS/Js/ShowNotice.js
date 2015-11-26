//加载xml
function LoadXml(xmlname,colname)
  {
   var xmlFile = xmlname+".xml"; // xml文件
   var xmlDoc = parseXMLDoc(xmlFile); // 调用方法parseXMLDoc()加载解析XML文件 
//   //检索的记录数
//   maxNum = xmlDoc.getElementsByTagName(colname).length;
//   //每条记录的列对象
//   column=xmlDoc.getElementsByTagName(colname).item(0).childNodes;
//   //每条记录的列数
//   colNum=column.length;
   //总页数
//   G_pagesNumber = Math.ceil(maxNum/G_pagenum)-1; 
   return xmlDoc;
  }
  
//显示当前页中的公告信息
function showContent(xmlname,colname,showID)
  {
   var tmpTag = "null"; //获取行对象集
   var tmpCol = "null"; //获取每行对象
   var P1,P2,P3,P4,P5; //参数集
   //获取XML名称
   G_xmltmpname=xmlname;
   //获取列名称
   G_coltmpname=colname;
   //获取用户展示对象ID
   G_showtmpID=showID;
   //计算各参数值
  var xmlDoc = LoadXml(xmlname,colname);
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
          P1 = tmpCol.getElementsByTagName("noticeID")[0].firstChild.nodeValue;
          P2 = tmpCol.getElementsByTagName("noticeTitle")[0].firstChild.nodeValue; 
          P3 = tmpCol.getElementsByTagName("noticeTime")[0].firstChild.nodeValue; 
          P4 = tmpCol.getElementsByTagName("noticePerson")[0].firstChild.nodeValue;
          P5 = tmpCol.getElementsByTagName("noticeHtmlName")[0].firstChild.nodeValue;
          G_divPageContent += RuleInput(P1,P2,P3,P4,P5,n); 
        }
      //在页面中显示
      document.getElementById(showID).innerHTML=G_divPageContent+"<div class='sysPage'>"+pageBar(G_page)+"</div>";
      }
   else
    {
   	 document.getElementById(showID).innerHTML='没有获取合适数据!';
	}
   //清空数据 
   G_divPageContent="";
 }
 
 //格式化输出 
 function RuleInput(p1,p2,p3,p4,p5,p6,intRow)
   { 
    //默认背景色
    var TmpBgColor="#ffe";
    //偶数时发生变化
    if (intRow%2==0) 
    {
        TmpBgColor="#fff";
    }
    //格式化内容
    var TmpShow  = "<div class='sysRcontent' style='background:"+TmpBgColor+";width:758px;'>";
        TmpShow +=    "<table style='width:95%;'>";
        TmpShow +=      "<tr>";
        TmpShow +=         "<td style='width:20px;padding-left:50px;'><img alt='公告' src='images/sound.png' /></td>";
        TmpShow +=         "<td align='left' style='width:300px;'>"
        TmpShow +=            "<a style='display:block;width:300px;overflow:hidden;text-overflow:ellipsis;word-break:keep-all;white-space:nowrap;' title='"+p2+"' href='Html/Notice/"+p5+".html' target='_blank'>"+ p2 +"</a>";
        TmpShow +=         "</td>";
        TmpShow +=         "<td>"+ p4 +"</td>";
        TmpShow +=         "<td>"+ p3.substring(0,10) +"</td>";
        TmpShow +=      "</tr>";
        TmpShow +=    "</table>";
        TmpShow += "</div>";
    return TmpShow; 
   } 