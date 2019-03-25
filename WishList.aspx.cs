using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WishList : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("WishList.aspx"));
            }
            else
            {
                UserInfo u = Session["user"] as UserInfo;
                //BindTypeData();
                //address.Text = u.Address1.ToString() + "（" + u.trueName.ToString() + " 收）" + u.Phonenum.ToString();
                //ShowProducts();
                //TotalPrice();
                AspNetPager1.PageSize = 2;
                AspNetPager1.RecordCount = GetRecordCount();
                repWishList.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
                repWishList.DataBind();
                //downMarketProduct();
            }
        }
    }
    private void BindTypeData()
    {
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            UserInfo u = Session["user"] as UserInfo;
            //string sql = "select distinct u.UserName,sd.StoreId,sd.StoreName,p.ProductId,p.Price,p.name,p.Size,p.OperatingSystem,p.NetworkType,p.Pixel,p.CoreNumber,sc.ProductNum,p.UserId,p.ProductState from ShoppingCart sc inner join Products p on sc.ProductId=P.ProductId inner join StoreDetail sd on sc.StoreId=sd.StoreId inner join UserInfo u on sd.StoreUser=u.UserId  where sc.UserId='" + u.Userid + "'";
            string sql = "select tempt.StoreId,sd.StoreName,u.UserName  from (select distinct sc.StoreId from WishList sc where sc.UserId='" + u.Userid + "') tempt inner join StoreDetail sd on sd.StoreId=tempt.StoreId inner join UserInfo u on u.UserId=sd.StoreUser";
            SqlDataAdapter daShop = new SqlDataAdapter(sql, cnn);
            DataSet dsShop = new DataSet();
            try
            {
                daShop.Fill(dsShop, "Products");
                repWishList.DataSource = dsShop.Tables[0];
                repWishList.DataBind();
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
    protected int GetRecordCount()
    {
        UserInfo u = Session["user"] as UserInfo;
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter ada1 = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select count(*) from (select distinct sc.StoreId from WishList sc where sc.UserId='"+u.Userid+"') tempt";
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
        UserInfo u = Session["user"] as UserInfo;
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            string sql = string.Format("select * from ( select ROW_NUMBER () OVER (order BY sd.StoreId) as rownumber,sd.StoreId,sd.StoreName,u.UserName from (select distinct sc.StoreId from WishList sc where sc.UserId='{2}') tempt inner join StoreDetail sd on tempt.StoreId=sd.StoreId inner join UserInfo u on u.UserId=sd.StoreUser ) tempt2 where tempt2.rownumber  between {0} and {1}", startRecordIndex, endRecordIndex, u.Userid);
            //string sql = string.Format("select  distinct tempt.rownumber,u.UserName,sd.StoreId,sd.StoreName,p.Stock,p.ProductId,p.Price,p.name,p.Size,p.OperatingSystem,p.NetworkType,p.Pixel,p.CoreNumber,p.UserId,p.ProductState  from( SELECT ROW_NUMBER () OVER (order BY ProductId) as rownumber, * from WishList where UserId='{2}' ) tempt inner join Products p on tempt.ProductId=P.ProductId inner join StoreDetail sd on tempt.StoreId=sd.StoreId  inner join UserInfo u on sd.StoreUser=u.UserId where tempt.rownumber  between {0} and {1}", startRecordIndex, endRecordIndex,u.Userid);
            SqlDataAdapter daPro = new SqlDataAdapter(sql, cnn);
            //创建DataSet对象
            DataSet dsPro = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daPro.Fill(dsPro, "WishList");
                return dsPro;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
    protected void rptSmallType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        UserInfo u = (UserInfo)Session["user"]; 
        HiddenField hProductId = (HiddenField)e.Item.FindControl("hiddenProductId");
        HiddenField hStoreId = (HiddenField)e.Item.FindControl("hiddenStoreId2");
        //LinkButton shCart = (LinkButton)e.Item.FindControl("shCart");
        //shCart.Text = "This product is down from market";
        string productId = hProductId.Value;
        string storeId = hStoreId.Value;
        if (e.CommandName == "deleteP")
        {
            string sqlDelete = "delete from WishList where ProductId='" + productId + "' and UserId='" + u.Userid + "'";
            operate(sqlDelete);
        }
        else if (e.CommandName == "addShoppingCart")
        {
            //string sqlDelete = "delete from WishList where ProductId='" + productId + "' and UserId='" + u.Userid + "'";
            //operate(sqlDelete);
            //string StoreId = storeId.Value;
            string productNum = "1";
            SqlConnection cnn2 = new SqlConnection(CnnStr);
            try
            {
                if (cnn2.State == ConnectionState.Closed)
                {
                    cnn2.Open();
                }
                string sqlCha = "select * from ShoppingCart where UserId='" + u.Userid + "' and ProductId='" + productId + "'";
                SqlCommand cmd = new SqlCommand(sqlCha, cnn2);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string pn = (int.Parse(dr["ProductNum"].ToString()) + 1).ToString();
                    dr.Close();
                    string sqlUpdate = "update ShoppingCart set ProductNum='" + pn + "' where ProductId='" + productId + "'";
                    SqlCommand cmdUp = new SqlCommand(sqlUpdate, cnn2);
                    cmdUp.ExecuteNonQuery();
                    Response.Redirect("showshoppingcart1.aspx");
                    //return;
                }
                else
                {
                    dr.Close();
                    string sqlInsert = "insert into ShoppingCart(UserId,StoreId,ProductId,ProductNum)values('" + u.Userid + "','" + storeId + "','" + productId + "','" + productNum + "')";
                    SqlCommand cmd2 = new SqlCommand(sqlInsert, cnn2);
                    cmd2.ExecuteNonQuery();
                    Response.Redirect("showshoppingcart1.aspx");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (cnn2.State == ConnectionState.Open)
                {
                    cnn2.Close();
                }
            }
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
            Response.Redirect("WishList.aspx");
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
    protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
    {
        repWishList.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);

        repWishList.DataBind();
    }
    protected void BindSmallTypeData(string StoreId, Repeater rpt)
    {
        UserInfo u = Session["user"] as UserInfo;
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            string sql = "select * from WishList sc inner join Products p on p.ProductId=sc.ProductId where sc.UserId='" + u.Userid + "' and sc.StoreId='" + StoreId + "'";
            SqlDataAdapter daPro = new SqlDataAdapter(sql, cnn);
            DataSet dsPro = new DataSet();
            try
            {
                daPro.Fill(dsPro, "WishList");
                rpt.DataSource = dsPro;
                rpt.ItemDataBound += new RepeaterItemEventHandler(rpt_ItemDataBound);
                rpt.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton shCart = (LinkButton)e.Item.FindControl("shCart");
        HiddenField hProductState = (HiddenField)e.Item.FindControl("hiddenProductState");
        HiddenField hiddenProductStock = (HiddenField)e.Item.FindControl("hiddenProductStock");
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
        if (hProductState.Value == "0")
        {
            shCart.Text = "This product is down from market"; 
            shCart.Enabled = false;
            shCart.Style.Add("text-decoration", "none");
            shCart.Style.Add("color", "grey");
            shCart.Attributes.Add("title", "This product is down from market");
        }
        if (hiddenProductStock.Value == "0")
        {
            shCart.Text = "Stock is not enough";
            shCart.Enabled = false;
            shCart.Style.Add("text-decoration", "none");
            shCart.Style.Add("color", "grey");
            shCart.Attributes.Add("title", "Stock is not enough");
        }
        if (hiddenProductStock.Value == "0" && hProductState.Value == "0")
        {
            shCart.Text = "This product is fown from market and stock is not enough";
            shCart.Enabled = false;
            shCart.Style.Add("text-decoration", "none");
            shCart.Style.Add("color", "grey");
            shCart.Attributes.Add("title", "This product is fown from market and stock is not enough");
        }
    }
    protected void repWishList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSmallType = (Repeater)e.Item.FindControl("rpProduct");
        HiddenField lbStoreId = (HiddenField)e.Item.FindControl("hiddenStoreId");
        BindSmallTypeData(lbStoreId.Value, rptSmallType);
        /*LinkButton shCart = (LinkButton)e.Item.FindControl("shCart");
        HiddenField hProductState = (HiddenField)e.Item.FindControl("hiddenProductState");
        if(hProductState.Value=="0")
        {
            shCart.Text = "This product is down from market";
            shCart.Enabled = false;
            shCart.Style.Add("text-decoration", "none");
            shCart.Style.Add("color", "grey");
            shCart.Attributes.Add("title", "This product is down from market");
        }*/

    }
    protected void repWishList_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSmallType = (Repeater)e.Item.FindControl("rpProduct");
        rptSmallType.ItemCommand += new RepeaterCommandEventHandler(rptSmallType_ItemCommand);
    }
}