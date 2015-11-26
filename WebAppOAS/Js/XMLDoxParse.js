//　1、通过JS读取XML文件，主要是判断各个浏览器　
// 加载xml文档 
function parseXMLDoc(xmlFile){ // 加载解析XML文件的成员方法
    var xmlDoc;
    try //Internet Explorer
      {
          xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
          xmlDoc.async=false;
          xmlDoc.load(xmlFile);
          
      }catch(e)
      {
          try //Firefox, Mozilla, Opera, etc.
            {
                xmlDoc=document.implementation.createDocument("","",null);
                xmlDoc.async=false;
                xmlDoc.load(xmlFile);
            }catch(e) 
            {
                 try
                 {//Chrome
                    var xmlhttp = new window.XMLHttpRequest(); 
                    xmlhttp.open("GET",xmlFile,false); 
                    xmlhttp.send(null); 
                    if(xmlhttp.readyState == 4){ 
                        xmlDoc = xmlhttp.responseXML.documentElement; 
                    }
                 }
                 catch(e){alert(e.message);}
            }
      }    
    return xmlDoc;
}

//function loadXMLString(txt){
//if (window.DOMParser)
//  {
//  parser=new DOMParser();
//  xmlDoc=parser.parseFromString(txt,"text/xml");
//  }
//else // Internet Explorer
//  {
//  xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
//  xmlDoc.async="false";
//  xmlDoc.loadXML(txt);
//  return(xmlDoc);
//  }
//}

//XMLDoc.prototype.print = function(readTagName,readTagCnt) 
//{ // 打印输出读取的XML文件的内容信息 
//    var xmlDoc = this.parseXMLDoc(); // 调用成员方法parseXMLDoc()加载解析XML文件 
//    var users = xmlDoc.getElementsByTagName(readTagName); // 获取指定标签名称的数据的一个数组users 
//    for(var i = 0 ; i < users.length; i++) 
//    { // 双重循环迭代输出 
//        document.write("<b>第" + (i+1) + "条记录信息：</b><br/>"); 
//        for(var j=0; j < readTagCnt; j++) 
//        { 
//            var tagname = users[i].childNodes[j].tagName; 
//            var textvalue = users[i].childNodes[j].text;
//            document.write(tagname + " = " + textvalue + ".<br/>"); 
//        } 
//    } 
//} 

//var xmlDoc = new XMLDoc(); // 创建一个XMLDoc了IDE对象实例 
//xmlDoc.xmlFile = "user.xml"; // 设置对象实例的成员变量的数据 
//xmlDoc.print("user",6); // 打印输出 