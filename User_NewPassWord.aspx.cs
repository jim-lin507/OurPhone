using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Default2 : basepage
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
                UserInfo u = (UserInfo)Session["user"];
                userName.Text = u.Userid.ToString();
            }
        }
    }
    protected void edit_Click(object sender, EventArgs e)
    {
        UserInfo u = (UserInfo)Session["user"];
        string oldPassword = OldPassword.Value;
        if (oldPassword == "")
        {
            OldPassword_error.Style.Add("visibility", "visible");
            OldPasswordempty.InnerText = "密码不能为空";
        }
        else if (UserPassword.Value == "")
        {
            UserPasswordempty.Style.Add("visibility", "visible");
            UserPasswordempty.InnerText = "密码不能为空";
        }
        else if (UserPassword2.Value == "")
        {
            UserPassword2empty.Style.Add("visibility", "visible");
            UserPassword2empty.InnerText = "密码不能为空";
        }
        else
        {
            if (oldPassword != u.Password)
            {
                OldPassword_error.Style.Add("visibility", "visible");
                OldPasswordempty.InnerText = "密码错误";
            }
            else if (UserPassword.Value != UserPassword2.Value)
            {
                UserPassword2_error.Style.Add("visibility", "visible");
                UserPassword2empty.InnerText = "密码不一致";
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
                    string sql = "update UserInfo set UserPwd='" + UserPassword.Value + "' " + "where UserId='" + u.Userid + "'";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    Session["user"] = null;
                    Response.Write("<script type='text/javascript'>alert('密码修改成功！');</script>");
                    Response.Write("<script type='text/javascript' language='javascript'>parent.location.reload();</script>");
                    //Response.Write("<script type='text/javascript' language='javascript'>function goToUrl(){window.location='login.aspx'}window.setInterval('goToUrl()',100);</script>");
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
}