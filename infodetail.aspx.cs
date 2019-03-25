using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

public partial class infodetail : basepage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["productid"] != null)
            {
                SqlConnection cnn = new SqlConnection(CnnStr);
                try
                {
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Open();
                    }
                    //select distinct u.UserName,s.StoreName from storeDetail s,UserInfo u,Products p where p.UserId=s.StoreUser and s.StoreUser=u.UserId
                    SqlDataAdapter da = new SqlDataAdapter(string.Format("select *from Products where ProductId={0}", Request.QueryString["productid"].ToString()), cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Products");
                    lbNumber.Text = (ds.Tables[0].Rows[0]["ProductId"]).ToString();
                    title.Title = (ds.Tables[0].Rows[0]["Name"]).ToString(); 
                    laName.Text = (ds.Tables[0].Rows[0]["Name"]).ToString();
                    lbPrice.Text = (ds.Tables[0].Rows[0]["Price"]).ToString();
                    //speciality.Text = (ds.Tables[0].Rows[0]["Speciality"]).ToString();
                    markettime.Text = ((DateTime)(ds.Tables[0].Rows[0]["Markettime"])).ToString("yyyy");
                    size.Text = (ds.Tables[0].Rows[0]["Size"]).ToString()+" inches";
                    operatingsystem.Text = (ds.Tables[0].Rows[0]["OperatingSystem"]).ToString();
                    //networktype.Text = (ds.Tables[0].Rows[0]["NetworkType"]).ToString();
                    pixel.Text = (ds.Tables[0].Rows[0]["Pixel"]).ToString();
                    //corenumber.Text = (ds.Tables[0].Rows[0]["CoreNumber"]).ToString()+"核";
                    //bargainPrice.Text = (ds.Tables[0].Rows[0]["BargainPrice"]).ToString();
                    if ((ds.Tables[0].Rows[0]["BargainPrice"]).ToString() != "0")
                    {
                        lbPrice.Style.Add("text-decoration", "line-through");
                        lbPrice.Style.Add("color", "#333");
                        lbPrice.Style.Add("font-size", "14px");
                        d_price.Style.Add("color", "#333");
                        d_price.Style.Add("font-size", "14px");
                        bargainPrice.Text = (ds.Tables[0].Rows[0]["BargainPrice"]).ToString();
                    }
                    else
                    {
                        bp.Visible = false;
                    }
                    Image1.ImageUrl = "showProductPicture.aspx?productid=" + Request.QueryString["productid"].ToString();
                    //storeUser.Text = (ds.Tables[0].Rows[0][11]).ToString();


                    //string sql = "select distinct s.StoreId,u.UserName,s.StoreName,p.ProductState from storeDetail s,UserInfo u,Products p where (select  UserId from Products where ProductId='" + Request.QueryString["productid"].ToString() + "')=s.StoreUser and s.StoreUser=u.UserId";
                    string sql = "select distinct s.StoreId,u.UserName,s.StoreName,p.ProductState,p.stock from storeDetail s,UserInfo u,Products p where p.UserId=u.UserId and s.StoreUser=u.UserId and p.ProductId='" + Request.QueryString["productid"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        storeName.Text = dr["StoreName"].ToString();
                        storeUser.Text = dr["UserName"].ToString();
                        storeDisplay.HRef = "StoreDisplay.aspx?storeId=" + dr["StoreId"].ToString();
                        storeId.Value = dr["StoreId"].ToString();
                        string ProductState=dr["ProductState"].ToString();
                        string stock = dr["Stock"].ToString();
                        if (stock == "0" || ProductState == "0")
                        {
                            if (ProductState == "0")
                            {
                                downMarketProduct.Style.Add("display", "none");
                                down.Style.Add("display", "inline");
                                disapear.Text = "This product is down from market";
                            }
                            if (stock == "0")
                            {
                                downMarketProduct.Style.Add("display", "none");
                                down.Style.Add("display", "inline");
                                disapear.Text = "Stock is not enough";
                            }
                            if (stock == "0" && ProductState == "0")
                            {
                                downMarketProduct.Style.Add("display", "none");
                                down.Style.Add("display", "inline");
                                disapear.Text = "This product is fown from market and stock is not enough";
                            }
                        }
                        else
                        {
                            downMarketProduct.Style.Add("display", "inline");
                            down.Style.Add("display", "none");
                        }
                    }
                                
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
        }

    }
    public products GetItem()
    {
        string id=Request.QueryString["productid"];
        List<products> myProducts=new List<products>();
        myProducts = ProductFactory.GetProductsList();
        for (int i=0; i < myProducts.Count; i++)
        {
            if (myProducts[i].id == id)
            {
                return myProducts[i];
            }
        }
        return null;
    }
    protected void wishList_Click(object sender, EventArgs e)
    {
         string productId = Request.QueryString["productid"].ToString();
        Session["ProductId"] = productId;

        if (Session["user"] == null)
        {
            Response.Redirect("login.aspx?msg=" + Server.UrlEncode("infodetail.aspx?productId=" + Request.QueryString["productid"].ToString()));
            //Response.Write("<script type='text/javascript'>alert('请先登录！');function goToUrl(){window.location='login.aspx'}window.setInterval('goToUrl()',100);</script>");
        }
        else
        {
            UserInfo u = (UserInfo)Session["user"];
            string userId = u.Userid;
            string StoreId = storeId.Value;
            string productNum = TextBox1.Text;
            SqlConnection cnn2 = new SqlConnection(CnnStr);
            try
            {
                if (cnn2.State == ConnectionState.Closed)
                {
                    cnn2.Open();
                }
                string sqlCha = "select * from WishList where UserId='" + userId + "' and ProductId='" + productId + "'";
                SqlCommand cmd = new SqlCommand(sqlCha, cnn2);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    dr.Close();
                    Response.Write("<script type='text/javascript'>alert('此商品已在收藏中！');function goToUrl(){window.location='WishList.aspx'}window.setInterval('goToUrl()',100);</script>");
                    //return;
                }
                else
                {
                    dr.Close();
                    string sqlInsert = "insert into WishList(UserId,StoreId,ProductId)values('" + userId + "','" + StoreId + "','" + productId + "')";
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
        }
    }
    protected void shoppingCart_Click(object sender, EventArgs e)
    {
        string productId = Request.QueryString["productid"].ToString();
        Session["ProductId"] = productId;

        if (Session["user"] == null)
        {
            Response.Redirect("login.aspx?msg=" + Server.UrlEncode("infodetail.aspx?productId=" + Request.QueryString["productid"].ToString()));
            //Response.Write("<script type='text/javascript'>alert('请先登录！');function goToUrl(){window.location='login.aspx'}window.setInterval('goToUrl()',100);</script>");
        }
        else
        {
            UserInfo u = (UserInfo)Session["user"];
            string userId = u.Userid;
            string StoreId = storeId.Value;
            string productNum = TextBox1.Text;
            SqlConnection cnn2 = new SqlConnection(CnnStr);
            try
            {
                if (cnn2.State == ConnectionState.Closed)
                {
                    cnn2.Open();
                }
                string sqlCha = "select * from ShoppingCart where UserId='" + userId + "' and ProductId='" + productId + "'";
                SqlCommand cmd = new SqlCommand(sqlCha, cnn2);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string pn = (int.Parse(dr["ProductNum"].ToString()) + int.Parse(TextBox1.Text)).ToString();
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
                    string sqlInsert = "insert into ShoppingCart(UserId,StoreId,ProductId,ProductNum)values('" + userId + "','" + StoreId + "','" + productId + "','" + productNum + "')";
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
            /*ShoppingCart myShoppingCart = new ShoppingCart();
            if (Session["ShoppingCart"] == null)
            {
                Session["ShoppingCart"] = new ShoppingCart();
            }
            else
            {
                myShoppingCart = (ShoppingCart)Session["ShoppingCart"];
            }
            products myProducts = GetItem();
            string StoreId = storeId.Value;
            CartItem myCartItem = new CartItem(Request.QueryString["productid"].ToString(), laName.Text.ToString(), lbPrice.Text.ToString(), int.Parse(TextBox1.Text), Image1.ImageUrl.ToString(), StoreId);
            myShoppingCart.AddItem(myCartItem);
            Session["ShoppingCart"] = myShoppingCart;*/
        }
    }
}



