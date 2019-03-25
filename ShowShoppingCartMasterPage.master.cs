using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class ShowShoppingCartMasterPage : System.Web.UI.MasterPage
{
    public string CnnStr
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["WebShopCnnString"].ConnectionString;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ShoppingCart myShoppingCart = new ShoppingCart();
        if (Request.QueryString["sess"] == "logout")
        {
            Session["user"] = null;
            Session["ShoppingCart"] = null;
            Session["ProductId"] = null;
        }
        if (Session["user"] != null)
        {
            
            Label1.Text = "";
            UserInfo u = (UserInfo)Session["user"];
            login.InnerHtml = u.Name;
            login.HRef = "User_Edit.aspx";
            register.InnerHtml = ",log out";
            register.HRef = "index.aspx?sess=logout";
            SqlConnection cnn = new SqlConnection(CnnStr);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();

                }
                string sqlCha = "select * from StoreDetail where StoreUser='" + u.Userid + "'";
                SqlCommand cmd = new SqlCommand(sqlCha, cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // yesStore.Style.Add("display", "list-item");
                    noStore.InnerHtml = "My Store";
                    string storeId = dr["StoreId"].ToString();
                    noStore.HRef = "StoreDisplay.aspx?storeId=" + storeId;
                }
                dr.Close();

                string sqlChaM = "select * from UserInfo where UserId='" + u.Userid + "' and isManager='1'";
                SqlCommand cmdM = new SqlCommand(sqlChaM, cnn);
                SqlDataReader drM = cmdM.ExecuteReader();
                if (drM.Read())
                {
                    noStore.InnerHtml = "商店管理";
                    noStore.HRef = "StoreManage.aspx";
                    yesStore.Visible = false;
                    adminCa.Visible = true;
                }
                else
                {
                    adminCa.Visible = false;
                }
                drM.Close();

                string sqlS = "select count(*) from ShoppingCart where UserId='" + u.Userid + "'";
                SqlCommand cmdS = new SqlCommand(sqlS, cnn);
                int ShoppingCartCount = (int)cmdS.ExecuteScalar();
                spc.InnerHtml = string.Format("<b><a class='ty_menu_select' href='showshoppingcart1.aspx'><span>Cart（{0}）</span></a></b>", ShoppingCartCount);
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
        else
        {
            spc.InnerHtml = string.Format("<b><a class='ty_menu_select' href='login.aspx?msg={1}'><span>Cart（{0}）</span></a></b>", 0, Server.UrlEncode("showshoppingcart1.aspx"));
            Label1.Text = "Hello,welcome to my shopper！Please";
            login.InnerHtml = "Log in";
            login.HRef = "login.aspx";
            register.HRef = "register.aspx";
            //yesStore.Visible = false;
        }
        if (Session["ShoppingCart"] == null)
        {
            Session["ShoppingCart"] = new ShoppingCart();
        }
        else
        {
            myShoppingCart = (ShoppingCart)Session["ShoppingCart"];
        }
        //spc.InnerHtml = string.Format("<b><a class='ty_menu_select' href='showshoppingcart.aspx'><span>Cart（{0}）</span></a></b>", myShoppingCart.myCartItem.Count);
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        Session["queryName"] = txt_Search_Keywords.Value;
        Response.Redirect("productList.aspx?smallTypeId=00102&operate=query");
    }
}
