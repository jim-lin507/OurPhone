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
public partial class index : basepage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ShowProducts();

            AspNetPager1.PageSize = 10;
            AspNetPager1.RecordCount = GetRecordCount();
            rptProducts.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);

            rptProducts.DataBind();
        }
                                                        
    }
    private void ShowProducts()
    {
       using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter daShop = new SqlDataAdapter("select * from Products where ProductState='1'", cnn);
            DataSet dsShop = new DataSet();
            try
            {
                daShop.Fill(dsShop, "Products");
                rptProducts.DataSource = dsShop.Tables[0];
                rptProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
    protected int GetRecordCount()
    {

        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter ada1 = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select count(*) from Products p inner join StoreDetail sd on p.UserId=sd.StoreUser where sd.StoreState='1' and p.ProductState='1'";
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

        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            SqlDataAdapter daPro = new SqlDataAdapter(string.Format("select * from( SELECT ROW_NUMBER () OVER (order BY p.ProductId) as rownumber, *from Products p inner join StoreDetail sd on p.UserId=sd.StoreUser where p.ProductState='1' and sd.StoreState='1') tempt where tempt.rownumber  between {0} and {1}", startRecordIndex, endRecordIndex), cnn);
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
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        rptProducts.DataSource = GetpageNews(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);

        rptProducts.DataBind();
    }
    protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
