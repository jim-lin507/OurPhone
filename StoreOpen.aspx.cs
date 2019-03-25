using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;

public partial class OpenStore : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("StoreOpen.aspx"));
                //Response.Write("<script type='text/javascript'>alert('请先登录！');</script>");
                //Response.Write("<script type='text/javascript' language='javascript'>function goToUrl(){window.location='login.aspx'}window.setInterval('goToUrl()',100);</script>");
            }
        }
    }
    
    protected void register_Store_Click(object sender, EventArgs e)
    {
        string sName = StoreName.Text;
        string sIntro = StoreIntro.Value;
        string sAddress = storeAddress.Text;
        string imgPath = uploadFile.PostedFile.FileName;
        System.Drawing.Image imgupload = null;
        try
        {
            imgupload = System.Drawing.Image.FromFile(imgPath);
        }
        catch
        {
        }

        SqlConnection cnn = new SqlConnection(CnnStr);
        string sql = "select * from StoreDetail where StoreName='" + sName + "'";
        SqlCommand com = new SqlCommand(sql, cnn);
        cnn.Open();
        SqlDataReader dr = com.ExecuteReader();

        /*if (sName == "" || sIntro == "")
        {
            Response.Write("<script language='javaScript'>");
            Response.Write("alert('请填写完整！！！')");
            Response.Write("</script>");
        }
        else */
        if (dr.Read())
        {
            hint.Style.Add("display", "inline");
            hint.InnerHtml = "抱歉，此店名已被人注册！！！";
            //Response.Write("<script language='javaScript'>");
            //Response.Write("alert('抱歉，此店名已被人注册！！！')");
            //Response.Write("</script>");
        }
        else if (uploadFile.PostedFile.FileName != "" && (Path.GetExtension(uploadFile.PostedFile.FileName) != ".gif" && Path.GetExtension(uploadFile.PostedFile.FileName) != ".jpg"))
        {
            Response.Write("<Script>alert('上传的图片格式必须为gif或jpg!!')</Script>");
        }
        else
        {
            UserInfo u = (UserInfo)Session["user"];
            string userName = u.Userid.ToString();
            SqlConnection cnn2 = new SqlConnection(CnnStr);
            string sql2 = "insert into StoreDetail(StoreName,StoreAddress,StoreUser,StoreIntroduce)values('" + sName + "','"+sAddress+"','" + userName + "','" + sIntro + "')";
            SqlCommand com2 = new SqlCommand(sql2, cnn2);
            cnn2.Open();
            com2.ExecuteNonQuery();
            cnn2.Close();
            if (uploadFile.PostedFile.FileName != "")
            {
                Stream imagedatastream;
                SqlConnection myConn = new SqlConnection(CnnStr);
                //string tr=Request.Files["uploadFile"];
                imagedatastream = Request.Files[0].InputStream;//有些不懂
                int imagedatalen = Request.Files[0].ContentLength;
                string imagedatatype = Request.Files[0].ContentType;

                byte[] image = new byte[imagedatalen];
                imagedatastream.Read(image, 0, imagedatalen);

                String Psql = "update StoreDetail set [StoreLogo]=@imgdata where StoreUser='" + userName+"'";

                SqlCommand Pcommand = new SqlCommand(Psql, myConn);

                SqlParameter imgdata = new SqlParameter("@imgdata", SqlDbType.Image);
                imgdata.Value = image;
                Pcommand.Parameters.Add(imgdata);

                myConn.Open();
                Pcommand.ExecuteReader();
                myConn.Close();

            }
            SqlConnection Scnn = new SqlConnection(CnnStr);
            Scnn.Open();
            string Ssql = "select * from StoreDetail where StoreUser='" + userName+"'";
            string storeId;
            SqlCommand Scmd = new SqlCommand(Ssql, Scnn);
            SqlDataReader drS = Scmd.ExecuteReader();
            if (drS.Read())
            {
                storeId=drS["StoreId"].ToString();
                Response.Redirect("StoreDisplay.aspx?storeId=" + storeId);
               // Response.Write("<script language='javaScript'>");
               // Response.Write("alert('恭喜！！！注册店铺成功！！！')");
               // Response.Write("</script>");
                //Response.Write("<script type='text/javascript' language='javascript'>function goToUrl(){window.location='StoreDisplay.aspx?storeId=" + storeId + "'}window.setInterval('goToUrl()',100);</script>");
            }
            
            //Response.Redirect("index.aspx");
        }        
    }
}