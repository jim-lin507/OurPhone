using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class productList : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string smallTypeId = Request.QueryString["smallTypeId"].ToString();
        string typeId=smallTypeId.Substring(0, 3);
        string typeName = "";
        string smallTypeName = "";
        if (!IsPostBack)
        {
            if (Session["queryName"] != null)
            {
                BindTypeData();
                ShowProducts();
                Session["queryName"] = null;
            }
            else
            {
                string sql = "select * from PType where smallTypeId='" + smallTypeId + "'";
                SqlConnection cnn = new SqlConnection(CnnStr);
                try
                {
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        smallTypeName = dr["SmallTypeName"].ToString();
                        typeName = dr["TypeName"].ToString();
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                addTypeFactory(typeName, smallTypeName);
                BindTypeData();
                ShowProducts();
            }
        }
    }
    public void addTypeFactory(string typeName, string smallTypeName)
    {
        string smallTypeId = Request.QueryString["smallTypeId"].ToString();
        string operate = Request.QueryString["operate"].ToString();
        string typeId = smallTypeId.Substring(0, 3);
        bool typeFlag = false;
        TypeFactory myFactory = new TypeFactory();
        if (Session["Factory"] == null)
        {
            Session["Factory"] = new TypeFactory();
        }
        else
        {
            myFactory = (TypeFactory)Session["Factory"];
        }
        for (int i = 0; i < myFactory.myTypeFactory.Count; i++)
        {
            if (operate == "delete")
            {
                if (smallTypeId == myFactory.myTypeFactory[i].SmallTypeId)
                {
                    myFactory.myTypeFactory.Remove(myFactory.myTypeFactory[i]);
                    typeFlag = true;
                }
            }
            else
            {
                if (typeId == myFactory.myTypeFactory[i].TypeId)
                {
                    if (smallTypeId == myFactory.myTypeFactory[i].SmallTypeId)
                    {
                        typeFlag = true;
                    }
                    else
                    {
                        myFactory.myTypeFactory[i].SmallTypeId = smallTypeId;
                        myFactory.myTypeFactory[i].SmallTypeName = smallTypeName;
                        typeFlag = true;
                    }
                }
            }
        }
        if (typeFlag == false)
        {
            Type myType = new Type(typeId, typeName, smallTypeId, smallTypeName);
            myFactory.AddItem(myType);
            Session["Factory"] = myFactory;
        }
    }
    public string GetInfoShoppingCart()
    {
        TypeFactory myFactory = new TypeFactory();
        if (Session["Factory"] == null)
        {
            Session["Factory"] = new TypeFactory();
        }
        else
        {
            myFactory = (TypeFactory)Session["Factory"];
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < myFactory.myTypeFactory.Count; i++)
        {
            sb.Append(string.Format("<a class='param-selected icon-tag async-btn' href='productList.aspx?smallTypeId={2}&operate=delete' title='{0}：{1}'>{0}：{1}<span class='close-icon icon-btn-x'>X</span></a>", myFactory.myTypeFactory[i].TypeName, myFactory.myTypeFactory[i].SmallTypeName,myFactory.myTypeFactory[i].SmallTypeId));
        }
        return sb.ToString();
    }
    private void ShowProducts()
    {
        string brand = "";
        string netWorkType = "";
        string operatingSystem = "";
        string price ="";
        string[] priceArray=new string[2];
        TypeFactory myFactory = new TypeFactory();
        if (Session["Factory"] == null)
        {
            Session["Factory"] = new TypeFactory();
        }
        else
        {
            myFactory = (TypeFactory)Session["Factory"];
        }
        if (Session["queryName"]!=null)
        {
            brand = Session["queryName"].ToString();
        }
        for (int i = 0; i < myFactory.myTypeFactory.Count; i++)
        {
            if (myFactory.myTypeFactory[i].TypeName=="Brand"&&myFactory.myTypeFactory[i].SmallTypeName!="其它")
            {
                brand = myFactory.myTypeFactory[i].SmallTypeName;
            }
            if (myFactory.myTypeFactory[i].TypeName == "Network" && myFactory.myTypeFactory[i].SmallTypeName != "其它")
            {
                netWorkType = myFactory.myTypeFactory[i].SmallTypeName;
            }
            if (myFactory.myTypeFactory[i].TypeName == "Operating System" && myFactory.myTypeFactory[i].SmallTypeName != "其它")
            {
                operatingSystem = myFactory.myTypeFactory[i].SmallTypeName;
            }
            if (myFactory.myTypeFactory[i].TypeName == "Price" && myFactory.myTypeFactory[i].SmallTypeName != "其它")
            {
                price = myFactory.myTypeFactory[i].SmallTypeName;
                priceArray = price.Split('-');
            }
        }
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            string[] pNum = new string[2];
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

            }
            string sql = "select * from Products  where ProductState='1' and Name like '%" + brand + "%' and NetworkType like '%" + netWorkType + "%' and OperatingSystem like '%" + operatingSystem + "%'";
            string p = "and Price>='" + priceArray[0] + "' and Price<='" + priceArray[1]+ "'";
            if (price != "")
            {
                sql += p;
            }
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                noExist.Visible = true;
                return;
            }
            dr.Close();
            pNum = sql.Split('*');

            SqlCommand cmd2 = new SqlCommand(pNum[0]+" count(*) "+pNum[1], cnn);
            object count = cmd2.ExecuteScalar();
            int productNum = (int)count;
            productNumber.Text = productNum.ToString();
            SqlDataAdapter daShop = new SqlDataAdapter(sql, cnn);
            DataSet dsShop = new DataSet();
            try
            {
                daShop.Fill(dsShop, "Products");
                reProductList.DataSource = dsShop.Tables[0];
                reProductList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
    protected void BindTypeData()
    {
        using (SqlConnection cnn = new SqlConnection(CnnStr))
        {
            TypeFactory myFactory = new TypeFactory();
            if (Session["Factory"] == null)
            {
                Session["Factory"] = new TypeFactory();
            }
            else
            {
                myFactory = (TypeFactory)Session["Factory"];
            }
            //创建DataAdapter对象，使用select语句和连接对象初始化
            //SqlDataAdapter daStu = new SqlDataAdapter("select distinct TypeName,TypeId from PType where TypeId!='" + smallTypeId.Substring(0,3)+ "' order by TypeId asc", cnn);
            string sql = "";
            if (myFactory.myTypeFactory.Count == 0)
            {
                sql = "select distinct TypeName,TypeId from PType order by TypeId asc";
            }
            else
            {
                sql = "select distinct TypeName,TypeId from PType where ";
            }
            //order by TypeId asc
            for (int i = 0; i < myFactory.myTypeFactory.Count; i++)
            {
                if (i != myFactory.myTypeFactory.Count-1)
                {
                    sql += "TypeId!='" + myFactory.myTypeFactory[i].TypeId + "' and ";
                }
                else
                {
                    sql += "TypeId!='" + myFactory.myTypeFactory[i].TypeId + "' order by TypeId asc";
                }
            }
            //sql += "order by TypeId asc";
            SqlDataAdapter daStu = new SqlDataAdapter(sql, cnn);
            //创建DataSet对象
            DataSet dsStu = new DataSet();
            try
            {
                //调用Fill方法，填充DataSet的数据表StuInfo
                daStu.Fill(dsStu, "PType");
                //将StuInfo表绑定到控件上显示
                rpt.DataSource = dsStu;
                rpt.DataBind();
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
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSmallType = (Repeater)e.Item.FindControl("rptSmallType");
        Label lbTypeId = (Label)e.Item.FindControl("lbTypeId");
        BindSmallTypeData(lbTypeId.Text, rptSmallType);

    }
}