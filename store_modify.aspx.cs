using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class store_modify : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string StoreId = Request.QueryString["StoreId"].ToString();
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("store_modify.aspx?StoreId=" + StoreId));
            }
            else
            {
                
                //lbStoreId.Text = StoreId;
                hiddenStoreId.Value = StoreId;
                SqlConnection cnn = new SqlConnection(CnnStr);
                string sql = "select * from StoreDetail  where StoreId='" + StoreId + "'";
                try
                {
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Open();
                    }
                    SqlCommand cmm = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cmm.ExecuteReader();
                    if (dr.Read())
                    {
                        StoreName.Text = dr["StoreName"].ToString();
                        StoreAddress.Text = dr["StoreAddress"].ToString();
                        StoreIntro.Value = dr["StoreIntroduce"].ToString();
                        StoreLogo.Src = "showStoreLogo.aspx?StoreId=" + StoreId;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
    protected void modify_Store_Click(object sender, EventArgs e)
    {
        string storeId = hiddenStoreId.Value;
        string storeName = StoreName.Text;
        string storeAddress = StoreAddress.Text;
        string storeIntroduce = StoreIntro.Value;
        SqlConnection cnn = new SqlConnection(CnnStr);
        UserInfo u = (UserInfo)Session["user"];
        string nameid = u.Userid;
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }

            string sqlUpdate = "update StoreDetail set StoreName='" + storeName + "',StoreAddress='" + storeAddress + "',StoreIntroduce='" + storeIntroduce +  "' where StoreId='" + storeId + "'";
            SqlCommand cmd2 = new SqlCommand(sqlUpdate, cnn);
            cmd2.ExecuteNonQuery();
            //hint.Style.Add("display", "none");
            //Response.Redirect("index.aspx");
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
        if (uploadFile.PostedFile.FileName != "")
        {
            //----------- update图片
            Stream imagedatastream;
            SqlConnection myConn = new SqlConnection(CnnStr);
            imagedatastream = Request.Files[0].InputStream;
            int imagedatalen = Request.Files[0].ContentLength;
            string imagedatatype = Request.Files[0].ContentType;

            byte[] image = new byte[imagedatalen];
            imagedatastream.Read(image, 0, imagedatalen);

            //String sql="insert into image(image) values(@imgdata)";
            String Psql = "update StoreDetail set [StoreLogo]=@imgdata where StoreId='" + storeId + "'";

            SqlCommand Pcommand = new SqlCommand(Psql, myConn);

            SqlParameter imgdata = new SqlParameter("@imgdata", SqlDbType.Image);
            imgdata.Value = image;
            Pcommand.Parameters.Add(imgdata);

            myConn.Open();
            Pcommand.ExecuteReader();
            myConn.Close();
        }
        Response.Redirect("StoreDisplay.aspx?StoreId=" + storeId);
    }
}