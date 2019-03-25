using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ReplyOnlineConsult : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("OnlineConsult.aspx"));
            }
            else
            {
                UserInfo u = (UserInfo)Session["user"];
                displayContent();
                using (SqlConnection cnn = new SqlConnection(CnnStr))
                {
                    //创建DataAdapter对象，使用select语句和连接对象初始化
                    string sql = "";
                    if (isManager() == true)
                    {
                        sql = "select * from OnlineConsult";
                    }
                    else
                    {
                        sql = "select * from OnlineConsult where UserId='" + u.Userid + "'";
                    }
                    SqlDataAdapter daStu = new SqlDataAdapter(sql, cnn);
                    //创建DataSet对象
                    DataSet dsStu = new DataSet();
                    try
                    {
                        //调用Fill方法，填充DataSet的数据表StuInfo
                        daStu.Fill(dsStu, "CS");
                        //将StuInfo表绑定到控件上显示
                        reOnCo.DataSource = dsStu;
                        reOnCo.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
        }
    }
    protected bool isManager()
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();

        }
        UserInfo u = (UserInfo)Session["user"];
        string sqlChaM = "select * from UserInfo where UserId='" + u.Userid + "' and isManager='1'";
        SqlCommand cmdM = new SqlCommand(sqlChaM, cnn);
        SqlDataReader drM = cmdM.ExecuteReader();
        if (drM.Read())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void displayContent()
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        string onlConId = Request.QueryString["OnlConId"].ToString();
        onlConNum.Text = onlConId;
        string sql = "select * from OnlineConsult where OnlConId='" + onlConId + "'";
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
                txt_email.Text = dr["Email"].ToString();
                txt_name.Text = dr["UserName"].ToString();
                txt_tel.Text = dr["PhoneNum"].ToString();
                txt_content.Text = dr["Description"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            string replyContent = txt_replyContent.Value;
            UserInfo u = (UserInfo)Session["user"];
            string onlConId = Request.QueryString["OnlConId"].ToString();
            string sqlUpdate = "UPDATE OnlineConsult SET ReplyContent = '" + replyContent + "' WHERE OnlConId = '" + onlConId + "' ";
            SqlCommand cmd = new SqlCommand(sqlUpdate, cnn);
            cmd.ExecuteNonQuery();
            Response.Write("<script language='JavaScript'>");
            Response.Write("alert('管理员回复成功'); window.location='OnlineConsult1.aspx';");
            Response.Write("</script>");
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