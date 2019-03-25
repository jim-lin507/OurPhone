using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///UsersFactory 的摘要说明
/// </summary>
public class UsersFactory
{
    public static List<UserInfo> userlist = new List<UserInfo>();
    public static void getuser()
    {
        if (userlist.Count == 0)
        {
            string str1 = "天堂22号";
            string str2 = "地狱29号";
            string str3 = "天堂25号";
            string str4 = "地狱508号";
            string str5 = "天堂32号";
            string strn1 = "青龙";
            string strn2 = "白虎";
            string strn3 = "玄武";
            string strn4 = "朱雀";
            string strn5 = "凤凰";
            List<string> lis1 = new List<string>();
            List<string> lis2 = new List<string>();
            List<string> lis3 = new List<string>();
            List<string> lisn1 = new List<string>();
            List<string> lisn2 = new List<string>();
            List<string> lisn3 = new List<string>();
            lis1.Add(str1);
            lis1.Add(str2);
            lis1.Add(str3);
            lis2.Add(str4);
            lis3.Add(str5);
            lisn1.Add(strn1);
            lisn1.Add(strn2);
            lisn1.Add(strn3);
            lisn2.Add(strn4);
            lisn3.Add(strn5);
            UserInfo u1 = new UserInfo( "police"," ", "警察", "123456", 10000, "110",lis1,lisn1);
            UserInfo u2 = new UserInfo("firemen", " ", "消防", "123456", 20000, "119", lis2, lisn2);
            UserInfo u3 = new UserInfo("doctor", " ", "医疗", "123456", 15000, "120", lis3, lisn3);
            userlist.Add(u1);
            userlist.Add(u2);
            userlist.Add(u3);
        }
    }
    public static List<UserAddress> getuserressbyid(string id)
    {
        List<UserAddress> uar=new List<UserAddress>();
        UserAddress ur;
        foreach(UserInfo u in userlist)
        {
            if (u.Userid == id)
            {                
                for (int i = 0; i < u.AddName.Count; i++)
                {
                    if (i == 0)
                    {
                        ur = new UserAddress(u.Userid, u.AddName[i], u.Address[i], u.Money, true);
                    }
                    else
                    {
                        ur = new UserAddress(u.Userid, u.AddName[i], u.Address[i], u.Money, false);
                    }
                    uar.Add(ur);
                }
            }
        }
        return uar;
    }
}