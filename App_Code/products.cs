using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///products 的摘要说明
/// </summary>
public class products
{
	public products()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    string Id;
    string Name;
    string Price;
    string Author;
    string ImgPath;
    string BigImgPath;
   /* string TypeId;
    string Desc;
    string SmallTypeId;*/
    public string id
    {
        get
        {
            return Id;
        }
        set
        {
            Id = value;
        }
    }
    public string name
    {
        get
        {
            return Name;
        }
        set
        {
            Name = value;
        }
    }
    public string price
    {
        get
        {
            return Price;
        }
        set
        {
            Price = value;
        }
    }
    public string author
    {
        get
        {
            return Author;
        }
        set
        {
            Author = value;
        }
    }
    public string bigimgpath
    {
        get
        {
            return BigImgPath;
        }
        set
        {
            BigImgPath = value;
        }
    }
    public string imgpath
    {
        get
        {
            return ImgPath;
        }
        set
        {
            ImgPath = value;
        }
    }
    public products(string id, string name, string price, string imgth)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.ImgPath = imgpath;
    }
}
