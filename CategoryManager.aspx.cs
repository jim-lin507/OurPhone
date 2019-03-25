using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class CategoryManager : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx?msg=" + Server.UrlEncode("CategoryManager.aspx"));
            }
            else
            {
                BindTypeData();
            }
        }
    }
    protected void BindTypeData()
    {
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            //创建DataAdapter对象，使用select语句和连接对象初始化
            SqlDataAdapter daStu = new SqlDataAdapter("select distinct TypeName,TypeId from PType order by TypeId asc", cnn);
            //创建DataSet对象
            DataSet dsStu = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daStu.Fill(dsStu, "PType");
                //将StuInfo表绑定到控件上显示
                reType.DataSource = dsStu;
                reType.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    protected void BindSmallTypeData(string typeid, Repeater rpt)
    {
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            SqlDataAdapter daPro = new SqlDataAdapter(string.Format("select SmallTypeId,SmallTypeName from PType where TypeId='{0}'", typeid), cnn);
            DataSet dsPro = new DataSet();
            try
            {
                daPro.Fill(dsPro, "PType");
                rpt.DataSource = dsPro;
                rpt.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

    }
    protected void reType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSmallType = (Repeater)e.Item.FindControl("reSmallType");
        Label lbTypeId = (Label)e.Item.FindControl("lbTypeId");
        LinkButton addType = (LinkButton)e.Item.FindControl("addType");
        addType.PostBackUrl = "CategoryAdd.aspx?TypeId="+lbTypeId.Text;
        BindSmallTypeData(lbTypeId.Text, rptSmallType);
    }
    protected void reSmallType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        UserInfo u = (UserInfo)Session["user"];
        HiddenField hiddenSmallTypeId = (HiddenField)e.Item.FindControl("hiddenSmallTypeId");
        if (e.CommandName == "deleteP")
        {
            string sqlDelete = "delete from PType where SmallTypeId='" + hiddenSmallTypeId.Value + "'";
            operate(sqlDelete);
        }
    }
    private void operate(string sql)
    {
        SqlConnection cnn = new SqlConnection(CnnStr);
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            SqlCommand cmd2 = new SqlCommand(sql, cnn);
            cmd2.ExecuteNonQuery();
            Response.Redirect("CategoryManager.aspx");
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
    protected void reType_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSmallType = (Repeater)e.Item.FindControl("reSmallType");
        rptSmallType.ItemCommand += new RepeaterCommandEventHandler(reSmallType_ItemCommand);
    }
}