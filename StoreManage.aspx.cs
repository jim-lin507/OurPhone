using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class StoreManage : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo u = (UserInfo)Session["user"];
        if (!IsPostBack)
        {
            //ShowProducts();
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("StoreManage.aspx"));
            }
            else
            {
                AspNetPager1.PageSize = 3;
                AspNetPager1.RecordCount = GetRecordCount();
                rptProducts.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
                rptProducts.DataBind();
            }
        }

    }
    protected int GetRecordCount()
    {
        UserInfo u = (UserInfo)Session["user"];
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter ada1 = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select count(*) from StoreDetail";
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
        UserInfo u = (UserInfo)Session["user"];
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            string sql = string.Format("select * from( SELECT ROW_NUMBER () OVER (order BY StoreId) as rownumber,sd.StoreId,sd.StoreState,sd.StoreName,sd.StoreAddress,sd.StoreTime,u.UserName from StoreDetail sd inner join UserInfo u on u.UserId=sd.StoreUser ) tempt   where tempt.rownumber  between {0} and {1}", startRecordIndex, endRecordIndex, u.Userid);
            SqlDataAdapter daPro = new SqlDataAdapter(sql, cnn);
            //创建DataSet对象
            DataSet dsPro = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daPro.Fill(dsPro, "StoreDetail");
                return dsPro;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
    protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
    {
        rptProducts.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);

        rptProducts.DataBind();
    }
    protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        UserInfo u = (UserInfo)Session["user"];
        HiddenField hStoretId = (HiddenField)e.Item.FindControl("hiddenStoreId");
        LinkButton agreeOpen = (LinkButton)e.Item.FindControl("agreeOpen");
        LinkButton cancelOpen = (LinkButton)e.Item.FindControl("cancelOpen");
        string storetId = hStoretId.Value;
        if (e.CommandName == "deleteP")
        {
            string sqlDelete = "delete from StoreDetail where StoreId='" + storetId+"'";
            operate(sqlDelete);
        }
        if (e.CommandName == "downMarket")
        {
            string sqlDelete = "update StoreDetail set StoreState='0'  where StoreId='" + storetId + "'";
            operate(sqlDelete);
        }
        if (e.CommandName == "upMarket")
        {
            string sqlDelete = "update StoreDetail set StoreState='1'  where StoreId='" + storetId + "'";
            operate(sqlDelete);
        }
    }
    private void operate(string sql)
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            SqlCommand cmd2 = new SqlCommand(sql, cnn);
            cmd2.ExecuteNonQuery();
            Response.Redirect("StoreManage.aspx");
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
    protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hiddenStoreId = (HiddenField)e.Item.FindControl("hiddenStoreId");
        HiddenField hiddenStoreState = (HiddenField)e.Item.FindControl("hiddenStoreState");
        LinkButton agreeOpen = (LinkButton)e.Item.FindControl("agreeOpen");
        LinkButton cancelOpen = (LinkButton)e.Item.FindControl("cancelOpen");
        LinkButton modifyStore = (LinkButton)e.Item.FindControl("modifyStore");
        modifyStore.PostBackUrl = "store_modify.aspx?StoreId=" + hiddenStoreId.Value;

        if (hiddenStoreState.Value=="1")
        {
            agreeOpen.Visible = false;
        }
        if (hiddenStoreState.Value == "0")
        {
            cancelOpen.Visible = false;
        }
    }
}