using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ComplaintSuggestion : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected bool isManager()
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();

        }
        UserInfo u = (UserInfo)Session["user"];
        string sqlChaM = "select * from UserInfo where UserId='" + u.Userid + "' and isManager='1'";//判断是否为管理员
        SqlCommand cmdM = new SqlCommand(sqlChaM, cnn);
        SqlDataReader drM = cmdM.ExecuteReader();
        if (drM.Read())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}