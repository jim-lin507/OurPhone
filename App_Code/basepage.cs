using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
///basepage 的摘要说明
/// </summary>
public class basepage : System.Web.UI.Page
{
    public basepage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public string CnnStr
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["WebShopCnnString"].ConnectionString;
        }
    }
}