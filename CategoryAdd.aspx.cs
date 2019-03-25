using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class CategoryAdd : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string typeId = Request.QueryString["TypeId"].ToString();
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("CategoryAdd.aspx?TypeId=" + typeId));
            }
            else
            {
                TypeId.Text = typeId;
                SqlConnection cnn = new SqlConnection(CnnStr);
                string sql = "select * from PType  where TypeId='" + typeId + "' order by SmallTypeId desc";
                try
                {
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Open();
                    }
                    int smallMaxNum;
                    SqlCommand cmm = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cmm.ExecuteReader();
                    if (dr.Read())
                    {
                        TypeName.Text = "添加" + dr["TypeName"].ToString();
                        hiddenTypeName.Value = dr["TypeName"].ToString(); 
                        smallMaxNum = int.Parse(dr["SmallTypeId"].ToString().Substring(3, 2));
                        //Label1.Text = smallMaxNum.ToString();
                        hiddenSmallMaxNum.Value = smallMaxNum.ToString();
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
        string typeId = Request.QueryString["TypeId"].ToString();
        SqlConnection cnn = new SqlConnection(CnnStr);
        UserInfo u = (UserInfo)Session["user"];
        string nameid = u.Userid;
        string smallTypeId="";
        int smallMaxNum = int.Parse(hiddenSmallMaxNum.Value) + 1;
        if (smallMaxNum < 10)
        {
            smallTypeId = typeId + "0" + smallMaxNum.ToString();
        }
        else
        {
           smallTypeId = typeId + smallMaxNum.ToString();
        }
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }

            string sqlInsert = "insert into PType(TypeId,TypeName,SmallTypeId,SmallTypeName) values ('" + typeId + "','" + hiddenTypeName.Value + "','" + smallTypeId + "','" + addTypeName.Value + "')";
            SqlCommand cmd2 = new SqlCommand(sqlInsert, cnn);
            cmd2.ExecuteNonQuery();
            //hint.Style.Add("display", "none");
            //Response.Redirect("CategoryManager.aspx");
            Response.Write("<script type='text/javascript'>alert('添加类型成功！');window.location='CategoryManager.aspx';</script>");
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