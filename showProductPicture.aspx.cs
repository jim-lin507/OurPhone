using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class showProductPicture : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(CnnStr);
        UserInfo uu = (UserInfo)Session["user"];
        string productId = Request.QueryString["productId"].ToString();
        String sql = "SELECT * FROM Products where ProductId='" + productId + "'";
        SqlCommand command = new SqlCommand(sql, conn);
        conn.Open();
        SqlDataReader dr = command.ExecuteReader();
        dr.Read();
        byte[] imgdata = (byte[])dr["BigImgPath"];
        Response.BinaryWrite(imgdata);
        dr.Close();
        conn.Close();
    }
}