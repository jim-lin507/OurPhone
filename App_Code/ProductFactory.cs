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
using System.Collections.Generic;

/// <summary>
///ProductFactory 的摘要说明
/// </summary>
public static class ProductFactory
{
	/*public ProductFactory()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private static List<Product> list;
    public static List<Product> GetProductList();
    {   
        Product p1 = new Product();
        p1
    }*/
    static List<products> list = new List<products>();
    public static List<products> GetProductsList()
    {
        list.Clear();//防止产品重复加载
        products p1 = new products();
        p1.id = "0001";
        p1.price = "17.00";
        p1.name = "哈佛女孩刘亦婷";
        p1.imgpath = "proimages/pro(1).jpg";
        p1.author = "张欣武，刘卫华 著";
        p1.bigimgpath = "proimages/bigpro1.jpg";
        list.Add(p1);

        products p2 = new products();
        p2.id = "0002";
        p2.price = "23.00";
        p2.name = "力量";
        p2.imgpath = "proimages/pro(2).jpg";
        p2.author = "（澳）拜恩 著";
        p2.bigimgpath = "proimages/bigpro2.jpg";
        list.Add(p2);

        products p3 = new products();
        p3.id = "0003";
        p3.price = "17.50";
        p3.name = "蛙";
        p3.imgpath = "proimages/pro(3).jpg";
        p3.author = "莫言 著";
        p3.bigimgpath = "proimages/bigpro3.jpg";
        list.Add(p3);

        products p4 = new products();
        p4.id = "0004";
        p4.price = "25.00";
        p4.name = "谁动了我的奶酪？";
        p4.imgpath = "proimages/pro(4).jpg";
        p4.author = "（美）约翰逊 著，魏平 译";
        p4.bigimgpath = "proimages/bigpro4.jpg";
        list.Add(p4);

        products p5 = new products();
        p5.id = "0005";
        p5.price = "27.50";
        p5.name = "借力";
        p5.imgpath = "proimages/pro(5).jpg";
        p5.author = "黄桥 著";
        p5.bigimgpath = "proimages/bigpro5.jpg";
        list.Add(p5);

        products p6 = new products();
        p6.id = "0006";
        p6.price = "28.00";
        p6.name = "哈佛女孩刘亦婷二";
        p6.imgpath = "proimages/pro(6).jpg";
        p6.author = "刘卫华，张欣武 著";
        p6.bigimgpath = "proimages/bigpro6.jpg";
        list.Add(p6);

        products p7 = new products();
        p7.id = "0007";
        p7.price = "47.00";
        p7.name = "潜意识";
        p7.imgpath = "proimages/pro(7).jpg";
        p7.author = "高原 著";
        p7.bigimgpath = "proimages/bigpro7.jpg";
        list.Add(p7);

        products p8 = new products();
        p8.id = "0008";
        p8.price = "34.00";
        p8.name = "魔力";
        p8.imgpath = "proimages/pro(8).jpg";
        p8.author = "（澳）朗达·拜恩（Rhonda Byrne） 著，郑峥　译";
        p8.bigimgpath = "proimages/bigpro8.jpg";
        list.Add(p8);

        products p9 = new products();
        p9.id = "0009";
        p9.price = "34.00";
        p9.name = "史玉柱自述：我的营销心得";
        p9.imgpath = "proimages/pro(9).jpg";
        p9.author = "史玉柱 著";
        p9.bigimgpath = "proimages/shiyuzhu.jpg";
        list.Add(p9);

        products p10 = new products();
        p10.id = "00010";
        p10.price = "19.40";
        p10.name = "正能量";
        p10.imgpath = "proimages/pro(10).jpg";
        p10.author = "(美) 戴尔　著，崔京瑞，王南　译";
        p10.bigimgpath = "proimages/zhengnengliang.jpg";
        list.Add(p10);

        products p11 = new products();
        p11.id = "00011";
        p11.price = "20.40";
        p11.name = "挺住，意味着一切";
        p11.imgpath = "proimages/pro(11).jpg";
        p11.author = "(美) 戴尔　著，崔京瑞，王南　译";
        p11.bigimgpath = "proimages/tingzhu.jpg";
        list.Add(p11);
        return list;
    }
}
