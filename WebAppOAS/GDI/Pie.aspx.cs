using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OAS.MODEL;
using OAS.BLL;
using System.Drawing;  //添加引用
using System.Data.SqlClient;  //添加引用

namespace WebAppOAS
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["Sum"])
                || string.IsNullOrEmpty(Request.QueryString["AgreeQty"])
                || string.IsNullOrEmpty(Request.QueryString["DisagreeQty"]))
            {
                // There is missing data, so don't display anything.
                // Or return an image with some static error text.
                return;
            }
            else
            {
                int Sum = Convert.ToInt32(Request.QueryString["Sum"]);
                int AgreeQty = Convert.ToInt32(Request.QueryString["AgreeQty"]);
                int DisagreeQty = Convert.ToInt32(Request.QueryString["DisagreeQty"]);
                CreateImage(Sum, AgreeQty, DisagreeQty);
            }
        }

        protected class GDIPlace
        {
            public int BackGround_X;
            public int BackGround_Y;
            public int BackGround_Width;
            public int BackGround_Height;
            public int TitlePoint_X;
            public int TitlePoint_Y;
            public float Pie_X;
            public float Pie_Y;
            public float Pie_Width;
            public float Pie_Height;
            public float RangeBox_X;
            public float RangeBox_Y;
            public float RangeBox_Width;
            public float RangeBox_Height;
            public float AgreeBox_X;
            public float AgreeBox_Y;
            public float AgreeString_X;
            public float AgreeString_Y;
            public float DisagreeBox_X;
            public float DisagreeBox_Y;
            public float DisagreeString_X;
            public float DisagreeString_Y;
            public float Agreements_Width;
            public float Agreements_Height;

            public int Offset_X;
            public int Offset_Y;
        }

        private void CreateImage(int Summery, int AgreeQty, int DisagreeQty)
        {
            GDIPlace Place = new GDIPlace();
            Place.Offset_X = 0;
            Place.Offset_Y = 0;
            Place.BackGround_X = 0 + Place.Offset_X;
            Place.BackGround_Y = 0 + Place.Offset_Y;
            Place.BackGround_Width = 400;
            Place.BackGround_Height = 450;
            Place.TitlePoint_X = 80 + Place.Offset_X;
            Place.TitlePoint_Y = 20 + Place.Offset_Y;
            Place.Pie_X = 100 + Place.Offset_X;
            Place.Pie_Y = 100 + Place.Offset_Y;
            Place.Pie_Width = 150;
            Place.Pie_Height = 150;
            Place.RangeBox_X = 50 + Place.Offset_X;
            Place.RangeBox_Y = 300 + Place.Offset_Y;
            Place.RangeBox_Width = 300;
            Place.RangeBox_Height = 100;
            Place.AgreeBox_X = 90 + Place.Offset_X;
            Place.AgreeBox_Y = 320 + Place.Offset_Y;
            Place.AgreeString_X = 120 + Place.Offset_X;
            Place.AgreeString_Y = 320 + Place.Offset_Y;
            Place.DisagreeBox_X = 90 + Place.Offset_X;
            Place.DisagreeBox_Y = 360 + Place.Offset_Y;
            Place.DisagreeString_X = 120 + Place.Offset_X;
            Place.DisagreeString_Y = 360 + Place.Offset_Y;
            Place.Agreements_Width = 20;
            Place.Agreements_Height = 10;

            int Sum = Summery;

            //获取赞成票数
            int P_Int_AgreeQty = AgreeQty;

            //获取反对票数
            int P_Int_DisagreeQty = DisagreeQty;

            //创建画图对象
            Bitmap bitmap = new Bitmap(Place.BackGround_Width, Place.BackGround_Height);
            Graphics g = Graphics.FromImage(bitmap);

            try
            {
                //清空背景色
                g.Clear(Color.White);
                Pen pen1 = new Pen(Color.Red);
                Brush brush1 = new SolidBrush(Color.White);
                Brush brush2 = new SolidBrush(Color.Blue);
                Brush brush3 = new SolidBrush(Color.Brown);
                Font font1 = new Font("Courier New", 16, FontStyle.Bold);
                Font font2 = new Font("Courier New", 8);
                //绘制背景图
                g.FillRectangle(brush1, Place.BackGround_X, Place.BackGround_Y, Place.BackGround_Width, Place.BackGround_Height);    
                //书写标题
                g.DrawString("活动投票饼形图", font1, brush2, new Point(Place.TitlePoint_X, Place.TitlePoint_Y));  
                //赞成票数在圆中分配的角度
                float angle1 = Convert.ToSingle((360 / Convert.ToSingle(Sum)) * Convert.ToSingle(P_Int_AgreeQty));
                //反对票数在圆中分配的角度
                float angle2 = Convert.ToSingle((360 / Convert.ToSingle(Sum)) * Convert.ToSingle(P_Int_DisagreeQty));
                //绘制赞成票数所占比例
                g.FillPie(brush2, Place.Pie_X, Place.Pie_Y, Place.Pie_Width, Place.Pie_Height, 0, angle1);
                //绘制反对票数所占比例
                g.FillPie(brush3, Place.Pie_X, Place.Pie_Y, Place.Pie_Width, Place.Pie_Height, angle1, angle2);  

                //绘制标识
                g.DrawRectangle(pen1, Place.RangeBox_X, Place.RangeBox_Y, Place.RangeBox_Width, Place.RangeBox_Height);  //绘制范围框
                g.FillRectangle(brush2, Place.AgreeBox_X, Place.AgreeBox_Y, Place.Agreements_Width, Place.Agreements_Height);  //绘制小矩形
                g.DrawString("赞成票数占总投票数比例:" + Convert.ToSingle(P_Int_AgreeQty) * 100 / Convert.ToSingle(Sum) + "%", font2, brush2, Place.AgreeString_X, Place.AgreeString_Y);
                g.FillRectangle(brush3, Place.DisagreeBox_X, Place.DisagreeBox_Y, Place.Agreements_Width, Place.Agreements_Height);
                g.DrawString("反对票数占总投票数比例:" + Convert.ToSingle(P_Int_DisagreeQty) * 100 / Convert.ToSingle(Sum) + "%", font2, brush3, Place.DisagreeString_X, Place.DisagreeString_Y);
            }
            catch (Exception md)
            {
                Response.Write(md.Message);
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
        }
    }
}
