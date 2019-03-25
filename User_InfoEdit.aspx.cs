using System;
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
using System.Data.SqlClient;

public partial class _Default :basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                string url = Request.Url.ToString();
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("User_Edit.aspx"));
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
                    UserInfo u = (UserInfo)Session["user"];
                    userName.Text = u.Userid.ToString();
                    string sql = "select * from UserInfo where UserId='" + u.Userid.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        nickName.Text = dr.GetString(dr.GetOrdinal("UserName"));
                        trueName.Text = dr.GetString(dr.GetOrdinal("trueName"));
                        phoneNum.Text = dr.GetString(dr.GetOrdinal("phoneNum"));
                        address.Text = dr.GetString(dr.GetOrdinal("Address"));
                    }
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
    protected void edit_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            UserInfo u = (UserInfo)Session["user"];
            userName.Text = u.Userid;
            string nickname = nickName.Text;
            string truename = trueName.Text;
            string phonenum = phoneNum.Text;
            string addr = address.Text;
            string sql = "update UserInfo set UserName='" + nickname + "',TrueName='" + truename + "',PhoneNum='" + phonenum + "',Address='" + addr + "' " + "where UserId='" + u.Userid + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            UserInfo uu = new UserInfo(userName.Text, nickname, truename, u.Password, u.Money, phonenum, addr);
            Session["user"] = uu;
            Response.Write("<script type='text/javascript'>alert('用户资料修改成功！');</script>");
            Response.Write("<script type='text/javascript' language='javascript'>parent.location.reload();</script>");
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
