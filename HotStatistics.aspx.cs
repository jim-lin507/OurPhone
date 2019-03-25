using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HotStatistics : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo u = (UserInfo)Session["user"];
        if (!IsPostBack)
        {
            //ShowProducts();
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("HotStatistics.aspx"));
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
    protected int GetRecordCount()
    {
        UserInfo u = (UserInfo)Session["user"];
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter ada1 = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            string sqlCount = "";
            if (isManager() == true)
            {
                sqlCount = "select count(distinct ProductId) from Orders";
                sale.HRef = "SaleStatistics.aspx";
                sale.InnerText = "商店销售统计";
                //sale.Attributes.Add("class", "J_MakePoint");
                sale.Style.Add("color","#f40");
            }
            else
            {
                sqlCount = "select count(distinct ProductId) from Orders where StoreId=(select sd.StoreId from StoreDetail sd where sd.StoreUser='" + u.Userid + "')";
            }
            cmd.CommandText = sqlCount;
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
            string sql;
            if (isManager() == true)
            {
                sql = string.Format("select * from(select  ROW_NUMBER () OVER (order BY Sum(o.Quantity) desc) as rownumber,u.UserName,o.StoreId,p.ProductId,p.Name,p.Price,P.BargainPrice,Sum(o.Quantity) as Quantity from Orders o inner join Products p on p.ProductId=o.ProductId inner join StoreDetail sd on sd.StoreId=o.StoreId inner join UserInfo u on u.UserId=sd.StoreUser  group by p.ProductId,o.StoreId,u.UserName,p.Name,p.Price,P.BargainPrice) tempt where tempt.rownumber  between {0} and {1}", startRecordIndex, endRecordIndex);
            }
            else
            {
                sql = string.Format("select * from(select  ROW_NUMBER () OVER (order BY Sum(o.Quantity) desc) as rownumber,u.UserName,o.StoreId,p.ProductId,p.Name,p.Price,P.BargainPrice,Sum(o.Quantity) as Quantity from Orders o inner join Products p on p.ProductId=o.ProductId inner join StoreDetail sd on sd.StoreId=o.StoreId inner join UserInfo u on u.UserId=sd.StoreUser where u.UserId='{2}'  group by p.ProductId,o.StoreId,u.UserName,p.Name,p.Price,P.BargainPrice) tempt where tempt.rownumber  between {0} and {1}", startRecordIndex, endRecordIndex, u.Userid);
            }

            //创建DataAdapter对象，使用select语句和连接对象初始化
             
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
  /*  protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
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
    }*/
    protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hiddenPrice = (HiddenField)e.Item.FindControl("hiddenPrice");
        HiddenField hiddenQuantity = (HiddenField)e.Item.FindControl("hiddenQuantity");
        Label lbTotalPrice = (Label)e.Item.FindControl("lbTotalPrice");
        /*LinkButton shCart = (LinkButton)e.Item.FindControl("shCart");
        LinkButton modifyProduct = (LinkButton)e.Item.FindControl("modifyProduct");
        

        modifyProduct.PostBackUrl = "product_modify.aspx?productId=" + hiddenProductId.Value;
        if (hiddenProductStock.Value == "0")
        {
            disapear.Text = "库存不足";
        }*/
        
        Label price = (Label)e.Item.FindControl("Pprice");
        Label Bargainprice = (Label)e.Item.FindControl("Bargainprice");
        if (Bargainprice.Text != "0")
        {
            price.Style.Add("text-decoration", "line-through");
            lbTotalPrice.Text = (double.Parse(Bargainprice.Text) * double.Parse(hiddenQuantity.Value)).ToString();
        }
        else
        {
            lbTotalPrice.Text = (double.Parse(hiddenPrice.Value) * double.Parse(hiddenQuantity.Value)).ToString();
            Bargainprice.Visible = false;
        }
    }
}