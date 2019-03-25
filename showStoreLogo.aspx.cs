using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class showStoreLogo : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //String strID = Request.QueryString["id"].ToString();

        SqlConnection conn = new SqlConnection(CnnStr);
        UserInfo uu=(UserInfo)Session["user"];
        string storeId=Request.QueryString["storeId"].ToString();
        String sql = "SELECT * FROM StoreDetail where StoreId='" +storeId+"'";
        SqlCommand command = new SqlCommand(sql, conn);
        conn.Open();
        SqlDataReader dr = command.ExecuteReader();
        dr.Read();
        byte[] imgdata = (byte[])dr["StoreLogo"];
        Response.BinaryWrite(imgdata);
        dr.Close();
        conn.Close();
    }
}