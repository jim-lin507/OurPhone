using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class product_modify : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserInfo u = (UserInfo)Session["user"];
            string productId = Request.QueryString["productId"].ToString();
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("product_modify.aspx?ProductId="+productId));
            }
            else
            {
                loadInfo();
                int year;

                int month;

                DateTime beginTime;
                beginTime = DateTime.Now.Date;

                year = DateTime.Now.Year;
                month = DateTime.Now.Month;

                for (int i = 0; i <= 100; i++)
                {
                    int y = year - i;
                    MarketTimeYear.Items.Add(new ListItem(y.ToString(), y.ToString()));
                }
                //for (int j = 1; j <= 12; j++)
                //{
                //    // int m = month - j;
                //    MarketTimeMonth.Items.Add(new ListItem(j.ToString(), j.ToString()));
                //}
                //for (int k = 1; k <= 31; k++)
                //{
                //    // int m = month - j;
                //    MarketTimeDay.Items.Add(new ListItem(k.ToString(), k.ToString()));
                //}
                
                ProductId.Text = productId;
                SqlConnection cnn = new SqlConnection(CnnStr);
                string sql = "select * from Products  where ProductId='" + productId + "'";
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
                        ProductName.Value = dr["Name"].ToString();
                        ProductPrice.Value = dr["Price"].ToString();
                        ProductNum.Value = dr["Stock"].ToString();
                        OperatingSystem2.Text = dr["OperatingSystem"].ToString();
                        //NetworkType1.Text = dr["NetworkType"].ToString();
                        //ProductSpeciality.Value = dr["Speciality"].ToString();
                        Size.Value = dr["Size"].ToString();
                        //CoreNumber.Value = dr["CoreNumber"].ToString();
                        Pixel.Value = dr["Pixel"].ToString();
                        BargainPrice.Value = dr["BargainPrice"].ToString();
                        myimg.Src = "showProductPicture.aspx?productId=" + productId;
                        MarketTimeYear.Text = Convert.ToDateTime(dr["MarketTime"]).Year.ToString();
                        //MarketTimeMonth.Text = Convert.ToDateTime(dr["MarketTime"]).Month.ToString();
                        //MarketTimeDay.Text = Convert.ToDateTime(dr["MarketTime"]).Day.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
    protected void loadInfo()
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            UserInfo u = (UserInfo)Session["user"];
            string nameid = u.Userid;
            OperatingSystem2.Items.Add(new ListItem("Select an opotion", "Select an opotion"));
            string sqlCha = "select * from PType where TypeId='002'";
            SqlCommand cmd = new SqlCommand(sqlCha, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                OperatingSystem2.Items.Add(new ListItem(dr["SmallTypeName"].ToString(), dr["SmallTypeName"].ToString()));
            }
            dr.Close();
            //NetworkType1.Items.Add(new ListItem("Select an opotion", "Select an opotion"));
            string sqlCha2 = "select * from PType where TypeId='003'";
            SqlCommand cmd2 = new SqlCommand(sqlCha2, cnn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            //while (dr2.Read())
            //{
            //    NetworkType1.Items.Add(new ListItem(dr2["SmallTypeName"].ToString(), dr2["SmallTypeName"].ToString()));
            //}
            dr2.Close();
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
    protected void submit_update_Click(object sender, EventArgs e)
    {
        string productId = ProductId.Text;
        string productName = ProductName.Value;
        string productPrice = ProductPrice.Value;
        string productNum = ProductNum.Value;
        string operatingSystem = OperatingSystem2.SelectedValue;
        //string networkType = NetworkType1.SelectedValue;
        //string productSpeciality = ProductSpeciality.Value;
        string size = Size.Value;
        //string coreNum = CoreNumber.Value;
        string pixel = Pixel.Value;
        string bargainPrice = BargainPrice.Value;
        string marketTime = MarketTimeYear.SelectedValue;
        SqlConnection cnn = new SqlConnection(CnnStr);
        UserInfo u = (UserInfo)Session["user"];
        string nameid = u.Userid;
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }

            string sqlUpdate = "update Products set Name='" + productName + "',Price='" + productPrice + "',Speciality='" + "" + "',Stock='" + productNum + "',MarketTime='" + marketTime + "',Size='" + size + "',OperatingSystem='" + operatingSystem + "',NetWorkType='" + "" + "',Pixel='" + pixel + "',CoreNumber='" + "" + "',BargainPrice='" + bargainPrice + "' where ProductId='" + productId + "'";
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
            String Psql = "update Products set [BigImgPath]=@imgdata where ProductId='" + productId+"'";

            SqlCommand Pcommand = new SqlCommand(Psql, myConn);

            SqlParameter imgdata = new SqlParameter("@imgdata", SqlDbType.Image);
            imgdata.Value = image;
            Pcommand.Parameters.Add(imgdata);

            myConn.Open();
            Pcommand.ExecuteReader();
            myConn.Close();
        }
        Response.Redirect("infodetail.aspx?productId=" + productId);
    }
}