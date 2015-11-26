/**
 * @author wcc
 * div+xml静态页面实现数据分页
 * 2015/06/15
 */
//定义相关参数  
var G_pagenum=34; //每页显示数量
var G_page=0; //初始化当前页
var G_divPageContent=""; //内容
var G_pagesNumber; //总页数
var G_xmltmpname; //全局xmlDoc名称
var G_coltmpname; //全局xmlCol名称
var G_showtmpID; //全局用于展示对象ID号
 
  
//首页
function FirstPage(page)
  {
   thePage="首页"
   if(page!=0) thePage="<a href='javascript:void(0)' onclick='javascript:return FirstPageGo()'>首页</a>";
   return thePage;
  }
  
//获取首页数据
function FirstPageGo()
  { 
   G_page=0;
   showContent(G_xmltmpname,G_coltmpname,G_showtmpID); 
   //清空数据 
   G_divPageContent=""; 
  }  

//上一个页面
function UpPage(page)
  {
   thePage="前一页";
   if(page > 0) thePage="<a href='javascript:void(0)' onclick='javascript:return UpPageGo()'>前一页</a>";
   return thePage;
  }
  
//获取上一页数据
function UpPageGo()
  { 
   if(G_page>0) G_page--; 
   showContent(G_xmltmpname,G_coltmpname,G_showtmpID); 
   //清空数据 
   G_divPageContent=""; 
  }  

//下一个页面
function NextPage(page)
  {
   thePage="下一页";
   if(page<G_pagesNumber) thePage="<a href='javascript:void(0)' onclick='javascript:return NextPageGo()'>下一页</A>";
   return thePage;
  }
  
//获取下一页数据
function NextPageGo()
  { 
   if (G_page < G_pagesNumber) G_page++;
   showContent(G_xmltmpname,G_coltmpname,G_showtmpID);
   //清空数据  
   G_divPageContent="";
  } 
  
 //尾页
function LastPage(page)
  {
   thePage="尾页";
   if(page!=G_pagesNumber) thePage="<a href='javascript:void(0)' onclick='javascript:return LastPageGo()'>尾页</A>";
   return thePage;
  }
  
//获取尾页数据
function LastPageGo()
  { 
   G_page=G_pagesNumber;
   showContent(G_xmltmpname,G_coltmpname,G_showtmpID); 
   //清空数据 
   G_divPageContent=""; 
  }  
 
//实现数字分页
function changePage(tpage)
  { 
   G_page=tpage
   if(G_page >= 0) G_page--; 
   if (G_page < G_pagesNumber) G_page++;
   showContent(G_xmltmpname,G_coltmpname,G_showtmpID);
   //清空数据  
   G_divPageContent="";
}

//数字分页
function spanNum(page)
  {
  	var inta;
	var intb;
	var intc;
	//由于起始页码为0
	var tmpPage = page + 1;
	intc=Math.floor(tmpPage / G_pagenum);
	if (tmpPage > intc * G_pagenum  &&  tmpPage <= (intc+1) * G_pagenum){
		inta=intc * G_pagenum + 1;
		intb=(intc+1) * G_pagenum;
		if(intb > G_pagesNumber+1) intb = G_pagesNumber+1;
	}
	if (tmpPage % G_pagenum==0){
		if (intc!=1){
			inta=(intc-1) * G_pagenum;
			intb=(intc+1) * G_pagenum;
		}
		else{
			inta = 1;
			intb=(intc+1) * G_pagenum;
		}
		if(intb > G_pagesNumber+1) intb = G_pagesNumber+1;
	}
	var sp;
	sp=" ";
	if (inta<0) inta=1;
	for (t=inta;t<=intb;t++)
    {
	   	if (tmpPage!=t){
			sp=sp+"&nbsp;<a href='javascript:void(0)' onclick='javascript:return changePage("+(t-1)+")'><span>"+(t)+"</span>&nbsp;</a>";
		}else{
			sp=sp+"&nbsp;<span>"+(t)+"</span>&nbsp;";
		}
        
     }
	return sp;
  }

//显示当前的页数
function curPage()
  {
   var cp;
   cp=G_page+1;
   return cp;
  }

//显示总共页数
function sumPage()
  {
   var ap;
   ap=G_pagesNumber+1;
   return ap
  }
  
//显示分页内容框
function pageBar(page)
  {
   var pb;
   pb=curPage()+" / "+sumPage()+" &nbsp;"+FirstPage(page)+" "+UpPage(page)+" "+spanNum(page)+" "+NextPage(page)+" "+LastPage(page);
   return pb;
  }
  

