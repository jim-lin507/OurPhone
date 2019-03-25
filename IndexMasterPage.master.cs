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

public partial class IndexMasterPage : System.Web.UI.MasterPage
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
            //menu.Style.Add("display", "block");
            
            Label1.Text = "";
            UserInfo u = (UserInfo)Session["user"];
            login.InnerHtml = u.Name;
            login.HRef = "User_Edit.aspx";
            register.InnerHtml = ",log out";
            register.HRef = "index.aspx?sess=logout";
            //Response.Redirect("User_login.aspx");
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
                    noStore.InnerHtml = "My Store";
                    string storeId = dr["StoreId"].ToString();
                    noStore.HRef = "StoreDisplay.aspx?storeId="+storeId;
                }
                dr.Close();

                string sqlChaM = "select * from UserInfo where UserId='" + u.Userid + "' and isManager='1'";
                SqlCommand cmdM = new SqlCommand(sqlChaM, cnn);
                SqlDataReader drM = cmdM.ExecuteReader();
                if (drM.Read())
                {
                    noStore.InnerHtml = "Store Management";
                    noStore.HRef = "StoreManage.aspx";
                    yesStore.Visible = false;
                    adminCa.Visible = true;
                }
                else
                {
                    adminCa.Visible = false;
                }
                drM.Close();

                string sqlS = "select count(*) from ShoppingCart where UserId='"+u.Userid+"'";
                SqlCommand cmdS = new SqlCommand(sqlS,cnn);
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
            
            //yesStore.Style.Add("display", "block");

        }
        else
        {
           // menu.Style.Add("display", "none");
            spc.InnerHtml = string.Format("<b><a class='ty_menu_select' href='login.aspx?msg={1}'><span>Cart（{0}）</span></a></b>", 0, Server.UrlEncode("showshoppingcart1.aspx"));
            Label1.Text = "Hello,welcome to my shopper！Please";
            login.InnerHtml = "Log in";
            login.HRef = "login.aspx";
            register.HRef = "register.aspx";
            //yesStore.Visible = false;
            //yesStore.Style.Add("display", "none");
            
        }
        if (Session["ShoppingCart"] == null)
        {
            Session["ShoppingCart"] = new ShoppingCart();
        }
        else
        {
            myShoppingCart = (ShoppingCart)Session["ShoppingCart"];
        }
        
        //spc.InnerHtml = string.Format("Cart({0})", myShoppingCart.myCartItem.Count);
        //Label1.Text = myShoppingCart.myCartItem.Count.ToString();
        if (!IsPostBack)
        {
            BindTypeData();
            hotProduct();
            bargainProduct();
        }
    }
    protected void bargainProduct()
    {
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            //string sql="select pr.ProductId,pr.Name,tempt.Quantity from (select  top 3 o.ProductId,Sum(Quantity) as Quantity from Orders o inner join Products p on p.ProductId=o.ProductId where p.ProductState='1' group by o.ProductId order by Sum(Quantity) desc) tempt inner join Products pr on pr.ProductId=tempt.ProductId";
            SqlDataAdapter daStu = new SqlDataAdapter("select top 3 * from Products  p inner join StoreDetail sd on p.UserId=sd.StoreUser where p.ProductState='1' and sd.StoreState='1' and p.BargainPrice <>0 order by (p.Price-p.BargainPrice)  desc ", cnn);
            //创建DataSet对象
            DataSet dsStu = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daStu.Fill(dsStu, "bargainProducts");
                //将StuInfo表绑定到控件上显示
                bargainProducts.DataSource = dsStu;
                bargainProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    protected void hotProduct()
    {
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            //string sql="select pr.ProductId,pr.Name,tempt.Quantity from (select  top 3 o.ProductId,Sum(Quantity) as Quantity from Orders o inner join Products p on p.ProductId=o.ProductId where p.ProductState='1' group by o.ProductId order by Sum(Quantity) desc) tempt inner join Products pr on pr.ProductId=tempt.ProductId";
            SqlDataAdapter daStu = new SqlDataAdapter("select p.ProductId,p.Name,p.Price,p.BargainPrice,tempt.Quantity from(select  top 3 ProductId,Sum(Quantity) as Quantity from Orders group by ProductId order by Sum(Quantity) desc) tempt inner join Products p on p.ProductId=tempt.ProductId  inner join StoreDetail sd on p.UserId=sd.StoreUser where p.ProductState='1' and sd.StoreState='1'", cnn);
            //创建DataSet对象
            DataSet dsStu = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daStu.Fill(dsStu, "hotProducts");
                //将StuInfo表绑定到控件上显示
                hotProducts.DataSource = dsStu;
                hotProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    protected void BindTypeData()
    {
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            SqlDataAdapter daStu = new SqlDataAdapter("select distinct TypeName,TypeId from PType order by TypeId asc", cnn);
            //创建DataSet对象
            DataSet dsStu = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daStu.Fill(dsStu, "PType");
                //将StuInfo表绑定到控件上显示
                rpt.DataSource = dsStu;
                rpt.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
   




    protected void BindSmallTypeData(string typeid,Repeater rpt)
    {
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter daPro = new SqlDataAdapter(string.Format("select SmallTypeId,SmallTypeName from PType where TypeId='{0}'", typeid),cnn);
            DataSet dsPro = new DataSet();
            try
            {
                daPro.Fill(dsPro, "PType");
                rpt.DataSource = dsPro;
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
        Repeater rptSmallType = (Repeater)e.Item.FindControl("rptSmallType");
        Label lbTypeId = (Label)e.Item.FindControl("lbTypeId");
        BindSmallTypeData(lbTypeId.Text, rptSmallType);

    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        Session["queryName"] = txt_Search_Keywords.Value;
        Response.Redirect("productList.aspx?smallTypeId=00102&operate=query");
    }
    protected void hotProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hiddenPrice = (HiddenField)e.Item.FindControl("hiddenPrice");
        HiddenField hiddenBargainPrice = (HiddenField)e.Item.FindControl("hiddenBargainPrice");
        Label price = (Label)e.Item.FindControl("price");
        if (hiddenBargainPrice.Value != "0")
        {
            price.Text = hiddenBargainPrice.Value;
        }
    }
}
