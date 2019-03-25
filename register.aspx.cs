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

public partial class register : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void register_btnRegister_Click(object sender, EventArgs e)
    {
        string nameid = UserName.Value;
        string password = UserPassword.Value;
        string password2 = UserPassword2.Value;
        string nickname = NickName.Value;
        string trueName = TrueName.Value;
        string phonenum = PhoneNum.Value;
        string address = Address.Value;
        SqlConnection cnn = new SqlConnection(CnnStr);
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            string sqlCha = "select * from UserInfo where UserId='" + nameid + "'";
            SqlCommand cmd = new SqlCommand(sqlCha, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hint.Style.Add("display", "inline");
                hint.InnerHtml = "此会员名已存在！请重新输入一个！";
                UserName.Value = "";
                UserName.Focus();
                return;
            } 
            dr.Close();
                string sqlInsert = "Insert into UserInfo(UserId,UserName,TrueName,UserPwd,Money,PhoneNum,Address)values('" + nameid + "','" + trueName + "','" + nickname + "','" + password + "','" + 100000 + "','" + phonenum + "','" + address + "')";
                SqlCommand cmd2 = new SqlCommand(sqlInsert, cnn);
                cmd2.ExecuteNonQuery();
                hint.Style.Add("display", "none");
                Response.Redirect("login.aspx");
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
