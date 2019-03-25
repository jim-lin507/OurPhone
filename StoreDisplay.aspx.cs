using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;

public partial class StoreDisplay : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            noExist.Visible = false;
            UserInfo uu=(UserInfo)Session["user"];
            string storeId = Request.QueryString["storeId"].ToString();
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("StoreDisplay.aspx?StoreId="+storeId));
            }
            else
            {
                SqlConnection cnn = new SqlConnection(CnnStr);
                string sql = "select * from StoreDetail s,UserInfo u where s.StoreId='" + storeId + "' and s.StoreUser=u.UserId";
                try
                {
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Open();
                    }
                    SqlCommand cmm = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cmm.ExecuteReader();
                    string storeState = "";
                    string storeUserId = "";
                    if (dr.Read())
                    {
                        storeState = dr["StoreState"].ToString();
                        storeName.Text = dr["StoreName"].ToString();
                        storeUser.Text = dr["UserName"].ToString();
                        storeUserId = dr["StoreUser"].ToString();
                        StoreIntro.Text = dr["StoreIntroduce"].ToString();
                        storeAddress.Text = dr["StoreAddress"].ToString();
                        storeTime.Text = Convert.ToDateTime(dr["StoreTime"]).ToShortDateString();
                        shopLogo.Src = "showStoreLogo.aspx?storeId=" + dr["StoreId"].ToString();
                    }
                    if (storeState == "1")
                    {
                        open.Visible = false;
                    }
                    else
                    {
                        open.Visible = true;
                    }
                    if (storeUserId == uu.Userid)
                    {
                        storeModify.Visible = true;
                        storeModify.PostBackUrl = "store_modify.aspx?StoreId=" + storeId;
                    }
                    else
                    {
                        storeModify.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                hotProduct();
            }
        }
    }
    protected void hotProduct()
    {
        string storeId = Request.QueryString["storeId"].ToString();
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            string sql = "select p.ProductId,p.Name,p.Price,tempt.Quantity from(select  top 5 ProductId,Sum(Quantity) as Quantity from Orders where StoreId='" + storeId + "' group by ProductId having Sum(Quantity)>2  order by Sum(Quantity) desc) tempt inner join Products p on p.ProductId=tempt.ProductId";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                noExist.Visible = true;
                return;
            }
            dr.Close();

            //创建DataAdapter对象，使用select语句和连接对象初始化
            //string sql="select pr.ProductId,pr.Name,tempt.Quantity from (select  top 3 o.ProductId,Sum(Quantity) as Quantity from Orders o inner join Products p on p.ProductId=o.ProductId where p.ProductState='1' group by o.ProductId order by Sum(Quantity) desc) tempt inner join Products pr on pr.ProductId=tempt.ProductId";
            SqlDataAdapter daStu = new SqlDataAdapter(sql, cnn);
            //创建DataSet对象
            DataSet dsStu = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daStu.Fill(dsStu, "hotProducts");
                //将StuInfo表绑定到控件上显示
                rptProducts.DataSource = dsStu;
                rptProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}