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
using System.Data.SqlClient;

public partial class login : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
            
    }
    protected void login_btnLogin_Click(object sender, EventArgs e)
    {
        string name = UserName.Value;
        string password = login_txtPassword.Value;
        if (name.Equals("") || password.Equals(""))
        {
            hint.InnerHtml = "用户名和密码不能为空！";
            hint.Style.Add("display", "inline");
        }
        else
        {
            SqlConnection cnn = new SqlConnection(CnnStr);
            //string sql = "select * from StoreDetail s,UserInfo u where s.StoreId='" + storeId + "' and s.StoreUser=u.UserId";
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand cmm = new SqlCommand(string.Format("select * from UserInfo where UserId='{0}' and UserPwd='{1}'", name, password), cnn);
                SqlDataReader dr = cmm.ExecuteReader();
                if (dr.Read())
                {
                    string u = dr["UserId"].ToString();
                    string n = dr["UserName"].ToString();
                    string t = dr["TrueName"].ToString();
                    string p = dr["UserPwd"].ToString();
                    double m = double.Parse(dr["money"].ToString());
                    string nm = dr["PhoneNum"].ToString();
                    string ad = dr["Address"].ToString();
                    UserInfo uu = new UserInfo(u, n, t, p, m, nm, ad);
                    Session["user"] = uu;
                    if (Request.QueryString["msg"] == null)
                    {
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        Response.Redirect(Server.UrlDecode(Request.QueryString["msg"].ToString()));
                    }
                }
                else
                {
                    hint.Style.Add("display", "inline");
                    hint.InnerHtml = "您输入的密码和账户名不匹配，请重新输入。或者您<a style=' color:Red;' href='#' tabindex='1' target='_self'>忘记了密码？</a>";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                cnn.Close();
            }   
        }
    }
}