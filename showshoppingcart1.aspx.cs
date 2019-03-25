using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class showshoppingcart2 : basepage
{
    private float sum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("showshoppingcart1.aspx"));
            }
            else
            {
               
                UserInfo u = Session["user"] as UserInfo;
                emptyBalance.Text = "$"+u.Money.ToString();
                address.Text = u.Address1.ToString() + "（" + u.trueName.ToString() + "）" + u.Phonenum.ToString();
                balance.Text = "$"+u.Money.ToString() ;
                submitShoppingCart.Attributes.Add("onclick ", "return confirm( 'Comfirm your address:" + u.Address1.ToString() + "(" + u.Name.ToString() + ")" + u.Phonenum.ToString() + "');"); 
                //ShowProducts();
                //TotalPrice();
                BindTypeData();
                SqlConnection cnn = new SqlConnection(CnnStr);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                
                string sqlS = "select count(*) from ShoppingCart where UserId='" + u.Userid + "'";
                SqlCommand cmdS = new SqlCommand(sqlS, cnn);
                int ShoppingCartCount = (int)cmdS.ExecuteScalar();

                if (ShoppingCartCount != 0)
                {
                    loginForm.Style.Add("display", "inline");
                    shopCart.Style.Add("display", "none");
                }
                else
                {
                    loginForm.Style.Add("display", "none");
                    shopCart.Style.Add("display", "list-item");
                    shopCart.Style.Add("margin", "100px 20px 10px 20px");
                }
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
            Session["ShoppingCart"] = null;
            //string sql = "select distinct u.UserName,sd.StoreId,sd.StoreName,p.ProductId,p.Price,p.name,p.Size,p.OperatingSystem,p.NetworkType,p.Pixel,p.CoreNumber,sc.ProductNum,p.UserId,p.ProductState from ShoppingCart sc inner join Products p on sc.ProductId=P.ProductId inner join StoreDetail sd on sc.StoreId=sd.StoreId inner join UserInfo u on sd.StoreUser=u.UserId  where sc.UserId='" + u.Userid + "'";
            string sql = "select tempt.StoreId,sd.StoreName,u.UserName  from (select distinct sc.StoreId from ShoppingCart sc where sc.UserId='"+u.Userid+"') tempt inner join StoreDetail sd on sd.StoreId=tempt.StoreId inner join UserInfo u on u.UserId=sd.StoreUser";
            SqlDataAdapter daShop = new SqlDataAdapter(sql, cnn);
            DataSet dsShop = new DataSet();
            try
            {
                daShop.Fill(dsShop, "Products");
                rpShoppingCart.DataSource = dsShop.Tables[0];
                rpShoppingCart.DataBind();
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
    protected void BindSmallTypeData(string StoreId, Repeater rpt)
    {
        UserInfo u = Session["user"] as UserInfo;
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            string sql = "select * from ShoppingCart sc inner join Products p on p.ProductId=sc.ProductId where sc.UserId='" + u.Userid + "' and sc.StoreId='" + StoreId + "'";
            SqlDataAdapter daPro = new SqlDataAdapter(sql, cnn);
            DataSet dsPro = new DataSet();
            try
            {
                daPro.Fill(dsPro, "Products");
                rpt.DataSource = dsPro;
                rpt.ItemDataBound+=new RepeaterItemEventHandler(rpt_ItemDataBound);
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
        UserInfo u = (UserInfo)Session["user"];
        //Label p = (Label)e.Item.FindControl("productPrice");
        TextBox n = (TextBox)e.Item.FindControl("productNum");
        Label pp = (Label)e.Item.FindControl("PPrice");
        Label BargainPrice = (Label)e.Item.FindControl("BargainPrice");
        LinkButton m = (LinkButton)e.Item.FindControl("minus");
        LinkButton plus = (LinkButton)e.Item.FindControl("plus");
        Label productPrice = (Label)e.Item.FindControl("productPrice");
        Label productStock = (Label)e.Item.FindControl("productStock");
        LinkButton addWishList = (LinkButton)e.Item.FindControl("addWishList");
        HiddenField hProductState = (HiddenField)e.Item.FindControl("hiddenProductState");
        HiddenField hiddenProductStock = (HiddenField)e.Item.FindControl("hiddenProductStock");
        HiddenField hProductId = (HiddenField)e.Item.FindControl("hiddenProductId");
        HiddenField hStoreId = (HiddenField)e.Item.FindControl("hiddenStoreId2");
        //n.TextChanged+=new EventHandler(n_TextChanged);
        /*int scCount = myShoppingCart.myCartItem.Count;
        shop.Text = scCount.ToString();*/
        float price=0;
        if (BargainPrice.Text != "0")
        {
            price = float.Parse(BargainPrice.Text) * float.Parse(n.Text);
            pp.Style.Add("text-decoration", "line-through");
        }
        else
        {
            BargainPrice.Visible = false;
            price = float.Parse(pp.Text) * float.Parse(n.Text);
        }
        
        
        productPrice.Text = price.ToString();


       
        if (int.Parse(n.Text)>=int.Parse(hiddenProductStock.Value))
        {
            productStock.Visible = true;
            plus.CssClass = "J_Plus no-plus";
            plus.Style.Add("Cursor","default");
            plus.Enabled = false;
            n.Text = hiddenProductStock.Value;
            //price = float.Parse(pp.Text) * float.Parse(hiddenProductStock.Value);
            
            if (BargainPrice.Text != "0")
            {
                price = float.Parse(BargainPrice.Text) * float.Parse(hiddenProductStock.Value);
                pp.Style.Add("text-decoration", "line-through");
            }
            else
            {
                BargainPrice.Visible = false;
                price = float.Parse(pp.Text) * float.Parse(n.Text);
            }
            productPrice.Text = price.ToString();
        }
        if (hProductState.Value == "0")
        {
            addWishList.Text = "This product is down from market";
            addWishList.Enabled = false;
            n.Visible = false;
            m.Visible = false;
            plus.Visible = false;
            productPrice.Visible = false;
            addWishList.Style.Add("text-decoration", "none");
            addWishList.Style.Add("color", "grey");
            addWishList.Attributes.Add("title", "This product is down from market");
        }
        
        else
        {
            sum += price;
            totalPrice.Text = "$"+sum.ToString();
            ShoppingCart myShoppingCart = new ShoppingCart();
            if (Session["ShoppingCart"] == null)
            {
                Session["ShoppingCart"] = new ShoppingCart();
            }
            else
            {
                myShoppingCart = (ShoppingCart)Session["ShoppingCart"];
            }
            CartItem myCartItem = new CartItem(u.Userid, hProductId.Value, hStoreId.Value, int.Parse(n.Text));
            myShoppingCart.AddItem(myCartItem);
            Session["ShoppingCart"] = myShoppingCart;

        }
        if (int.Parse(n.Text) == 1 || int.Parse(hiddenProductStock.Value)==0)
        {
            m.CssClass = "J_Minus no-minus";
            m.Enabled = false;
        }
        else
        {
            m.CssClass = "J_Minus minus";
        }
    }
    
    protected void rpShoppingCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSmallType = (Repeater)e.Item.FindControl("rpProduct");
        HiddenField lbStoreId = (HiddenField)e.Item.FindControl("hiddenStoreId");
        BindSmallTypeData(lbStoreId.Value, rptSmallType);
    }
    protected void rptSmallType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        UserInfo u=(UserInfo)Session["user"];
        HiddenField hProductId = (HiddenField)e.Item.FindControl("hiddenProductId");
        HiddenField hStoreId = (HiddenField)e.Item.FindControl("hiddenStoreId2");
        LinkButton m = (LinkButton)e.Item.FindControl("minus");
        string productId = hProductId.Value;
        string storeId = hStoreId.Value;
        
        if (e.CommandName == "deleteP")
        { 
            string sqlDelete = "delete from ShoppingCart where ProductId='" + productId + "' and UserId='" + u.Userid + "'";
            operate(sqlDelete);
            Response.Redirect("showshoppingcart1.aspx");
        }
        else if (e.CommandName == "minusP")
        {
            TextBox n = (TextBox)e.Item.FindControl("productNum");
            string productNum = (int.Parse(n.Text) - 1).ToString();
            string sqlUpdateMinus = "update ShoppingCart set ProductNum='" + productNum + "' where ProductId='" + productId + "' and UserId='" + u.Userid + "'"; ;
            operate(sqlUpdateMinus);
            Response.Redirect("showshoppingcart1.aspx");
        }
        else if (e.CommandName == "plusP")
        {
            TextBox n = (TextBox)e.Item.FindControl("productNum");
            string productNum = (int.Parse(n.Text) + 1).ToString();
            string sqlUpdatePlus = "update ShoppingCart set ProductNum='" + productNum + "' where ProductId='" + productId + "' and UserId='" + u.Userid + "'"; ;
            operate(sqlUpdatePlus);
            Response.Redirect("showshoppingcart1.aspx");
        }
        else if (e.CommandName == "addWishListP")
        {
            SqlConnection cnn2 = new SqlConnection(CnnStr);
            try
            {
                if (cnn2.State == ConnectionState.Closed)
                {
                    cnn2.Open();
                }
                string sqlDelete = "delete from ShoppingCart where ProductId='" + productId + "' and UserId='" + u.Userid + "'";
                SqlCommand cmd3 = new SqlCommand(sqlDelete, cnn2);
                cmd3.ExecuteNonQuery();
                string sqlCha = "select * from WishList where UserId='" + u.Userid + "' and ProductId='" + productId + "'";
                SqlCommand cmd = new SqlCommand(sqlCha, cnn2);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    dr.Close();
                    Response.Write("<script type='text/javascript'>alert('This Product is already in the watchlist！');function goToUrl(){window.location='WishList.aspx'}window.setInterval('goToUrl()',100);</script>");
                    //return;
                }
                else
                {
                    dr.Close();
                    string sqlInsert = "insert into WishList(UserId,StoreId,ProductId)values('" + u.Userid + "','" + storeId + "','" + productId + "')";
                    SqlCommand cmd2 = new SqlCommand(sqlInsert, cnn2);
                    cmd2.ExecuteNonQuery();
                    Response.Redirect("WishList.aspx");
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
            /*string sqlAddWishList = "insert into WishList(UserId,StoreId,ProductId)values('" + u.Userid + "','" + storeId + "','" + productId + "')";
            operate(sqlAddWishList);
            string sqlDelete = "delete from ShoppingCart where ProductId='" + productId + "' and UserId='" + u.Userid + "'";
            operate(sqlDelete);*/
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
            //Response.Redirect("showshoppingcart1.aspx");
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
    protected void rpShoppingCart_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSmallType = (Repeater)e.Item.FindControl("rpProduct");
        rptSmallType.ItemCommand+=new RepeaterCommandEventHandler(rptSmallType_ItemCommand);
        rptSmallType.ItemCreated+=new RepeaterItemEventHandler(rptSmallType_ItemCreated);
        /*TextBox productNum=(TextBox)rptSmallType.FindControl("productNum");
        string num = productNum.Text;
        productNum.TextChanged+=new EventHandler(productNum_TextChanged);*/
    }
    protected void rptSmallType_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        TextBox productNum = (TextBox)e.Item.FindControl("productNum");
        string num = productNum.Text;
        productNum.TextChanged += new EventHandler(productNum_TextChanged);
    }
    protected void productNum_TextChanged(object sender, EventArgs e)
    {
        UserInfo u=(UserInfo)Session["user"];
        TextBox  tb = (TextBox)sender;
        string productNum = tb.Text;
        //HiddenField hProductId = (HiddenField)e.Item.FindControl("hiddenProductId");
        HiddenField hProductId = (HiddenField)tb.Parent.FindControl("hiddenProductId");
        string sqlUpdateMinus = "update ShoppingCart set ProductNum='" + productNum + "' where ProductId='" + hProductId.Value + "' and UserId='" + u.Userid + "'"; ;
        operate(sqlUpdateMinus);
        Response.Redirect("showshoppingcart1.aspx");
        //Response.Write("<script type='text/javascript'>alert('" + hProductId.Value+ "');</script>");
    }
    protected void submitShoppingCart_Click(object sender, EventArgs e)
    {
        ShoppingCart myShoppingCart = new ShoppingCart();
        SqlConnection cnn = new SqlConnection(CnnStr);
        if (Session["ShoppingCart"] == null)
        {
            Session["ShoppingCart"] = new ShoppingCart();
        }
        else
        {
            myShoppingCart = (ShoppingCart)Session["ShoppingCart"];
        }
        for (int i = 0; i < myShoppingCart.myCartItem.Count; i++)
        {
            CartItem myCI = myShoppingCart.myCartItem[i];
            //myShoppingCart.myCartItem.Remove(myShoppingCart.myCartItem[i]);
            string sqlInsertOrders = "insert into Orders(StoreId,BuyerId,ProductId,Quantity)values('"+myCI.StoreId+"','"+myCI.UerId+"','"+myCI.ProductId+"','"+myCI.Quantity+"')";
            operate(sqlInsertOrders);

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            string sqlCha = "select * from Products where  ProductId='" + myCI.ProductId + "'";
            SqlCommand cmd = new SqlCommand(sqlCha, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string pn = (int.Parse(dr["Stock"].ToString()) - myCI.Quantity).ToString();
                dr.Close();
                string sqlUpdate = "update Products set Stock='" + pn + "' where ProductId='" + myCI.ProductId + "'";
                operate(sqlUpdate);
            }

        }
        
        UserInfo u = (UserInfo)Session["user"];
        double sy=u.Money - double.Parse(sum.ToString());
        if(sy>=0)
        {
            u.Money = sy;
            string sqlDeleteShoppingCart = "delete from ShoppingCart where  UserId='" + u.Userid + "'";
            operate(sqlDeleteShoppingCart);
            string sqlUpateMoney = "update UserInfo set Money='" + u.Money + "' where  UserId='" + u.Userid + "'";
            operate(sqlUpateMoney);
            // Response.Write("<script type='text/javascript'>confirm('" + u.Address1.ToString() + "（" + u.trueName.ToString() + " 收）" + u.Phonenum.ToString() + "！');window.location='product_buy.aspx';</script>");
            Response.Write("<script type='text/javascript'>alert('Successfully!');window.location='product_buy.aspx';</script>");
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('Balance is not enough.');window.location='showshoppingcart1.aspx';</script>");
        }
    }
}