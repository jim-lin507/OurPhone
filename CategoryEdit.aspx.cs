using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class CategoryEdit : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string smallTypeId = Request.QueryString["SmallTypeId"].ToString();
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("CategoryEdit.aspx?SmallTypeId="+smallTypeId));
            }
            else
            {
                SmallTypeId.Text = smallTypeId;
                SqlConnection cnn = new SqlConnection(CnnStr);
                string sql = "select * from PType  where SmallTypeId='" + smallTypeId + "'";
                try
                {
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Open();
                    }
                    SqlCommand cmm = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cmm.ExecuteReader();
                    if (dr.Read())
                    {
                        TypeName.Text = dr["TypeName"].ToString();
                        SmallTypeName.Value = dr["SmallTypeName"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
    protected void event_submit_do_publish_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        UserInfo u = (UserInfo)Session["user"];
        string smallTypeId = SmallTypeId.Text;
        string smallTypeName = SmallTypeName.Value;
        string nameid = u.Userid;
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }

            string sqlUpdate = "update Ptype set SmallTypeName='" + smallTypeName + "' where SmallTypeId='" +smallTypeId+"'";
            SqlCommand cmd2 = new SqlCommand(sqlUpdate, cnn);
            cmd2.ExecuteNonQuery();
            //hint.Style.Add("display", "none");
            Response.Write("<script type='text/javascript'>alert('修改类型成功！');window.location='CategoryManager.aspx';</script>");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
    }
}