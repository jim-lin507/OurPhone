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

public partial class showshoppingcart1 :  basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo u;
        if (Session["user"] == null)
        {
            u = new UserInfo();
        }
        else
        {
            
            u = Session["user"] as UserInfo;          
        }
        if (!IsPostBack)
        {
           // GetInfoShoppingCart();
            ShoppingCart shoplist = Session["ShoppingCart"] as ShoppingCart;
            if (shoplist.myCartItem.Count!=0)
            {
                loginForm.Style.Add("display", "inline");
                shopCart.Style.Add("display", "none");
                //hem.InnerText = shoplist.Price().ToString();
                totalPrice.Text = shoplist.Sum().ToString();
                Label2.Text = u.Money.ToString();
                address.Text = u.Address1.ToString() + "（" + u.trueName.ToString() + " 收）" + u.Phonenum.ToString();
                // rtppro.DataSource = shoplist.myCartItem;
                //rtppro.DataBind();
            }
            else
            {
                loginForm.Style.Add("display", "none");
                shopCart.Style.Add("display", "list-item");
                shopCart.Style.Add("margin", "200px 100px 100px 200px");
            }
        }
    }

    public string GetInfoShoppingCart()
    {
        ShoppingCart myShoppingCart = new ShoppingCart();
        if (Session["ShoppingCart"] == null)
        {
            Session["ShoppingCart"] = new ShoppingCart();
        }
        else
        {
            myShoppingCart = (ShoppingCart)Session["ShoppingCart"];
        }
        if (Request.QueryString["operate"] == "add")
        {
            int i = int.Parse(Request.QueryString["productid"]);
            myShoppingCart.myCartItem[i].Quantity++;
        }
        else if (Request.QueryString["operate"] == "drop")
        {
            int i = int.Parse(Request.QueryString["productid"]);
            if (myShoppingCart.myCartItem[i].Quantity >= 1)
                myShoppingCart.myCartItem[i].Quantity--;
        }
        else if (Request.QueryString["operate"] == "delete")
        {
            int i = int.Parse(Request.QueryString["productid"]);
            myShoppingCart.myCartItem.Remove(myShoppingCart.myCartItem[i]);
        }
        StringBuilder sb = new StringBuilder();
        for(int i=0;i<myShoppingCart.myCartItem.Count;i++)
        {
           // sb.Append(string.Format("<tr class='item'><td class='s-title'><a href='infodetail.aspx?productid={6}' title='' class='J_MakePoint'><img src='{0}' class='itempic'><span class='title J_MakePoint'> {1}</span></a></td><td class='s-price'><span class='price '><em class='style-normal-small-black J_ItemPrice'>{2}</em></span></td><td class='s-amount'><a href='showshoppingcart.aspx?operate=drop&productid={5}' class='minus c2c-oper-default'>-</a><input type='text' size='1' value='{3}' /><a href='showshoppingcart.aspx?operate=add&productid={5}' class='plus c2c-oper-default'>+</a></td><td class='s-agio'><div class='J_Promotion promotion'><select name='bundleList_18611841163:33909415313:0'><option value=''>全场免运费</option><option value=''>省137.67元:秒杀</option></select></div></td><td class='s-total'><span class='price '><em style='color:#FF5500'>{4}</em></span></td><td><a href='showshoppingcart.aspx?operate=delete&productid={5}'>删除</a></td></tr>", myShoppingCart.myCartItem[i].SmallImagePath, myShoppingCart.myCartItem[i].Name, myShoppingCart.myCartItem[i].Price, myShoppingCart.myCartItem[i].Quantity, myShoppingCart.myCartItem[i].Quantity * double.Parse(myShoppingCart.myCartItem[i].Price), i, myShoppingCart.myCartItem[i].ID));
        }
        totalPrice.Text = myShoppingCart.Sum().ToString();
        return sb.ToString();
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        UserInfo u;
        if (Session["user"] == null)
        {
            u = new UserInfo();
        }
        else
        {
            u = Session["user"] as UserInfo;
        }
        ShoppingCart myShoppingCart = new ShoppingCart();
        if (Session["ShoppingCart"] == null)
        {
            Session["ShoppingCart"] = new ShoppingCart();
        }
        else
        {
            myShoppingCart = (ShoppingCart)Session["ShoppingCart"];
        }
        double balance = u.Money;
        double totalprice = myShoppingCart.Sum();
        Label2.Text = balance.ToString();
        if (balance - totalprice < 0)
        {
            Response.Write("<script type='text/javascript'>alert('余额不足！');</script>");
            Response.Write("<script type='text/javascript' language='javascript'>function goToUrl(){window.location='showshoppingcart.aspx'}window.setInterval('goToUrl()',100);</script>");
        }
        else
        {
            SqlConnection cnn = new SqlConnection(CnnStr);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();

                }
                for (int i=0; i < myShoppingCart.myCartItem.Count;i++ )
                {
                    /*string sql = "insert into Orders(SalesId,BuyerId,ProductId,Quantity)values('" + myShoppingCart.myCartItem[i].StoreId + "','" + u.Userid + "','" + myShoppingCart.myCartItem[i].ID + "','" + myShoppingCart.myCartItem[i].Quantity+ "') ";
                    SqlCommand cmm = new SqlCommand(sql, cnn);
                    cmm.ExecuteNonQuery();*/
                }
                u.Money = balance - totalprice;
                Session["user"] = u;
                Session["ShoppingCart"] = null;
                Response.Write("<script type='text/javascript'>alert('付款成功！');</script>");
                Response.Write("<script type='text/javascript' language='javascript'>function goToUrl(){window.location='index.aspx'}window.setInterval('goToUrl()',100);</script>");
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
}

