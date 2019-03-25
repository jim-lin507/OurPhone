using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class product_chushou : basepage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo u=(UserInfo)Session["user"];
        if (!IsPostBack)
        {
            //ShowProducts();
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg="+Server.UrlEncode("product_chushou.aspx"));
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
            cmd.CommandText = "select count(*) from Products where ProductState='1' and  UserId='" + u.Userid + "'";
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
            string sql=string.Format("select * from( SELECT ROW_NUMBER () OVER (order BY ProductId) as rownumber, *from Products where ProductState='1' and UserId='{2}' ) tempt where tempt.rownumber  between {0} and {1}", startRecordIndex, endRecordIndex,u.Userid);
            SqlDataAdapter daPro = new SqlDataAdapter(sql, cnn);
            //创建DataSet对象
            DataSet dsPro = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daPro.Fill(dsPro, "Products");
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
        HiddenField hProductId = (HiddenField)e.Item.FindControl("hiddenProductId");
        string productId = hProductId.Value;
        if (e.CommandName == "deleteP")
        {
            string sqlDelete = "delete from Products where ProductId='" + productId + "' and UserId='" + u.Userid + "'";
            operate(sqlDelete);
        }
        if (e.CommandName == "downMarket")
        {
            string sqlDelete = "update Products set ProductState='0'  where ProductId='" + productId + "' and UserId='" + u.Userid + "'";
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
            Response.Redirect("product_chushou.aspx");
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
        HiddenField hiddenProductStock = (HiddenField)e.Item.FindControl("hiddenProductStock");
        HiddenField hiddenProductId = (HiddenField)e.Item.FindControl("hiddenProductId");
        LinkButton shCart = (LinkButton)e.Item.FindControl("shCart");
        LinkButton modifyProduct = (LinkButton)e.Item.FindControl("modifyProduct");
        Label disapear = (Label)e.Item.FindControl("disapear");
        Label price = (Label)e.Item.FindControl("Pprice");
        Label Bargainprice = (Label)e.Item.FindControl("Bargainprice");
        if (Bargainprice.Text != "0")
        {
            price.Style.Add("text-decoration", "line-through");
        }
        else
        {
            Bargainprice.Visible = false;
        }
        modifyProduct.PostBackUrl = "product_modify.aspx?productId="+hiddenProductId.Value;
        if (hiddenProductStock.Value == "0")
        {
            disapear.Text = "库存不足";
        }
    }
}