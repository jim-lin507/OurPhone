using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class product_sale : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("product_sale.aspx"));
            }
            else
            {

                UserInfo u = Session["user"] as UserInfo;
                noExist.Visible = false;
                string countSql = "select count(*) from Orders where StoreId=(select sd.StoreId from StoreDetail sd where sd.StoreUser='" + u.Userid + "')";
                string newSql = "select * from( SELECT ROW_NUMBER () OVER (order BY OrderId desc) as rownumber, *from Orders where StoreId=(select sd.StoreId from StoreDetail sd where sd.StoreUser='" + u.Userid + "')  ) tempt   inner join Products p on p.ProductId=tempt.ProductId where tempt.rownumber  between {0} and {1} order by tempt.rownumber asc";
                AspNetPager1.PageSize = 3;
                AspNetPager1.RecordCount = GetRecordCount(countSql);
                repOrderProduct.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, newSql);
                repOrderProduct.DataBind();
            }
        }
    }
    protected int GetRecordCount(string sql)
    {
        UserInfo u = Session["user"] as UserInfo;
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter ada1 = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
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
    protected DataSet GetpageNews(int startRecordIndex, int endRecordIndex, string NewsSql)
    {
        UserInfo u = Session["user"] as UserInfo;
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            //string sql = string.Format("select * from( SELECT ROW_NUMBER () OVER (order BY OrderId) as rownumber, *from Orders where BuyerId='{2}' ) tempt inner join StoreDetail sd on sd.StoreId=tempt.StoreId inner join UserInfo u on u.UserId=sd.StoreUser inner join Products p on p.ProductId=tempt.ProductId where tempt.rownumber  between {0} and {1} order by tempt.rownumber asc", startRecordIndex, endRecordIndex, u.Userid);
            string sql = string.Format(NewsSql, startRecordIndex, endRecordIndex);
            SqlDataAdapter daPro = new SqlDataAdapter(sql, cnn);
            //创建DataSet对象
            DataSet dsPro = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daPro.Fill(dsPro, "Orders");
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
        UserInfo u = Session["user"] as UserInfo;
        string newSql = "";
        if (J_BaobeiName.Text == "")
        {
            newSql = "select * from( SELECT ROW_NUMBER () OVER (order BY OrderId desc) as rownumber, *from Orders where StoreId=(select sd.StoreId from StoreDetail sd where sd.StoreUser='" + u.Userid + "')  ) tempt   inner join Products p on p.ProductId=tempt.ProductId where tempt.rownumber  between {0} and {1} order by tempt.rownumber asc";
        }
        else
        {
            newSql = "select * from(Select ROW_NUMBER () OVER (order BY OrderId desc) as rownumber,o.OrderId,o.OrderTime,o.Quantity,p.ProductId,p.Name,p.Price,p.BargainPrice,u.UserName,sd.StoreId,sd.StoreName From Products p inner join Orders o on o.ProductId=p.ProductId inner join StoreDetail sd on sd.StoreUser=p.UserId inner join UserInfo u on u.UserId=StoreUser Where p.Name Like '%" + J_BaobeiName.Text + "%' and o.BuyerId='" + u.Userid + "') tempt where tempt.rownumber  between {0} and {1} order by tempt.rownumber asc";
        }
        repOrderProduct.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, newSql);

        repOrderProduct.DataBind();
    }
    protected void repOrderProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label totalPrice = (Label)e.Item.FindControl("totalPrice");
        HiddenField hiddenPrice = (HiddenField)e.Item.FindControl("hiddenPrice");
        HiddenField hiddenQuantity = (HiddenField)e.Item.FindControl("hiddenQuantity");
        Label price = (Label)e.Item.FindControl("Pprice");
        Label Bargainprice = (Label)e.Item.FindControl("Bargainprice");
        if (Bargainprice.Text != "0")
        {
            price.Style.Add("text-decoration", "line-through");
            totalPrice.Text = (double.Parse(Bargainprice.Text) * double.Parse(hiddenQuantity.Value)).ToString();
        }
        else
        {
            totalPrice.Text = (double.Parse(hiddenPrice.Value) * double.Parse(hiddenQuantity.Value)).ToString();
            Bargainprice.Visible = false;
        }
    }
    protected void repOrderProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        UserInfo u = (UserInfo)Session["user"];
        Label labelOrderId = (Label)e.Item.FindControl("labelOrderId");
        if (e.CommandName == "deleteOrder")
        {
            string sqlDelete = "delete from Orders where  OrderId='" + labelOrderId.Text + "' and BuyerId='" + u.Userid + "'";
            operate(sqlDelete);
            Response.Redirect("Product_sale.aspx");
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
    protected void OrderSearch_Click(object sender, EventArgs e)
    {
        UserInfo u = (UserInfo)Session["user"];
        //searchFlag = true;
        string countSql ="select count(*) from Orders o inner join Products p on o.ProductId=p.ProductId where StoreId=(select sd.StoreId from StoreDetail sd where sd.StoreUser='"+u.Userid+"') and p.Name like '%"+J_BaobeiName.Text+"%'";
        string newSql = "select * from (Select ROW_NUMBER () OVER (order BY OrderId desc) as rownumber,tempt.OrderTime,tempt.OrderId,tempt.Quantity,p.ProductId,p.Price,p.BargainPrice,p.Name from( SELECT *from Orders o  where o.StoreId=(select sd.StoreId from StoreDetail sd where sd.StoreUser='" + u.Userid + "')) tempt   inner join Products p on p.ProductId=tempt.ProductId where p.Name like '%" + J_BaobeiName.Text + "%' ) tempt2 where tempt2.rownumber  between {0} and {1} order by tempt2.rownumber asc";
        SqlConnection cnn = new SqlConnection(CnnStr);
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            string sqlCha = "select * from(Select ROW_NUMBER () OVER (order BY OrderId desc) as rownumber,o.OrderId,o.OrderTime,o.Quantity,p.ProductId,p.Name,p.Price,p.BargainPrice,u.UserName,sd.StoreId,sd.StoreName From Products p inner join Orders o on o.ProductId=p.ProductId inner join StoreDetail sd on sd.StoreUser=p.UserId inner join UserInfo u on u.UserId=StoreUser Where p.Name Like '%" + J_BaobeiName.Text + "%' and o.BuyerId='" + u.Userid + "') tempt";
            SqlCommand cmd = new SqlCommand(sqlCha, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                noExist.Visible = true;
            }
            else
            {
                noExist.Visible = false;
            }
            dr.Close();
            AspNetPager1.PageSize = 3;
            AspNetPager1.RecordCount = GetRecordCount(countSql);
            repOrderProduct.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, newSql);
            repOrderProduct.DataBind();
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