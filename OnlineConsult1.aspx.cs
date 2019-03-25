using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OnlineConsult1 : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ShowProducts();

            AspNetPager1.PageSize = 3;
            AspNetPager1.RecordCount = GetRecordCount();
            OnlineRep.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);

            OnlineRep.DataBind();
        }
    }
    protected int GetRecordCount()
    {

        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter ada1 = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select count(*) from OnlineConsult";
            cmd.Connection = cnn;

            DataSet dsStu = new DataSet();
            try
            {

                cnn.Open();
                object count = cmd.ExecuteScalar();
                return (int)count;

            }
            catch (Exception ex)
            {
                return 0;

            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }
    }

    protected DataSet GetpageNews(int startRecordIndex, int endRecordIndex)
    {

        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            SqlDataAdapter daPro = new SqlDataAdapter(string.Format("select * from( SELECT ROW_NUMBER () OVER (order BY OnlConId desc) as rownumber, *from OnlineConsult ) tempt where tempt.rownumber  between {0} and {1}", startRecordIndex, endRecordIndex), cnn);
            //创建DataSet对象
            DataSet dsPro = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daPro.Fill(dsPro, "Online");
                return dsPro;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        OnlineRep.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);

        OnlineRep.DataBind();
    }
    protected void OnlineRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label replyContent = (Label)e.Item.FindControl("replyContent");
        LinkButton replyUserContent = (LinkButton)e.Item.FindControl("replyUserContent");
        HiddenField hiddenOnlineId = (HiddenField)e.Item.FindControl("hiddenOnlineId");
        replyUserContent.Visible = false;
        SqlConnection cnn = new SqlConnection(CnnStr);
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            string sqlCha = "select * from OnlineConsult where OnlConId='" + hiddenOnlineId.Value+ "'";
            SqlCommand cmd = new SqlCommand(sqlCha, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                    string r = dr["ReplyContent"].ToString();
                    if (r == "")
                    {
                        replyContent.Text = "等待管理员回复";
                        if (Session["user"] != null)
                        {
                            if (isManager() == true)
                            {
                                replyUserContent.Visible = true;
                                replyUserContent.PostBackUrl = "ReplyOnlineConsult.aspx?OnlConId=" + hiddenOnlineId.Value;
                            }
                        }
                    }
                    else
                    {
                        replyContent.Text = dr["ReplyContent"].ToString();
                    }
                return;
            }
            dr.Close();
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
}