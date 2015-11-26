using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using OAS.MODEL;
using OAS.BLL;

namespace WebAppOAS.BaseInfo
{
    public partial class BaseNoteBook : System.Web.UI.Page
    {
        note notes = new note();
        MNote objNote = new MNote();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                objNote.NotePerson = Session["loginName"].ToString();

                GridView1.DataSource = notes.SelectNoteByUserName(objNote);
                GridView1.DataKeyNames = new String[] { "id" };
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objNote.ID = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
            notes.DeleteNoteByID(objNote);

            objNote.NotePerson = Session["loginName"].ToString();
            GridView1.DataSource = notes.SelectNoteByUserName(objNote);
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Convert.ToDateTime(e.Row.Cells[2].Text).ToShortDateString();
            }
        }
        protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            objNote.Title = txtTitle.Text.Trim().ToString();
            objNote.NoteContent = txtContent.Text.Trim().ToString();
            objNote.NoteTime = DateTime.Today;
            objNote.NotePerson = Session["loginName"].ToString();
            if (notes.InsertIntoNote(objNote))
            {
                string myscript = @"alert('数据提交成功！');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", myscript, true);
                objNote.NotePerson = Session["loginName"].ToString();
                GridView1.DataSource = notes.SelectAllNotesByNotePerson(objNote);
                GridView1.DataKeyNames = new String[] { "id" };
                GridView1.DataBind();
            }
            else
            {
                string myscript = @"alert('数据提交失败！');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", myscript, true);
            }
        }
    }
}
