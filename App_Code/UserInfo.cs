using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///UserInfo 的摘要说明
/// </summary>
public class UserInfo
{
    //public int ID { set; get; }
    public string Userid { set; get; }
    public string Name { set; get; }
    public string trueName { set; get; }
    public string Password { set; get; }
    public double Money { set; get; }
    public string Phonenum { set; get; }
    public string Address1 { set; get; }
    public List<string> Address { set; get; }
    public List<string> AddName { set; get; }
    public UserInfo()
    {
        AddName = new List<string>();
        //Address = new List<string>();
    }
	public UserInfo(string u,string n,string t,string p,double m,string nm,List<string> a,List<string> an)
	{
        //ID = i;
        Userid = u;
        Name = n;
        trueName = t;
        Password = p;
        Money = m;
        Phonenum = nm;
        Address = a;
        AddName = an;
	}
    public UserInfo( string u, string n,string t, string p, double m, string nm,string ad)
    {
        //ID = i;
        Userid = u;
        Name = n;
        trueName = t;
        Password = p;
        Money = m;
        Phonenum = nm;
        Address1 = ad;
    }
    public bool isinaddress(string an, string ar)
    {
        int ok = 0;
        for (int i = 0; i < AddName.Count; i++)
        {
            if (AddName[i] == an && Address[i] == ar)
            {
                ok = 1;
            }
        }
        if (ok == 0)
        {
            Address.Add(ar);
            AddName.Add(an);
            return true;
        }
        return false;
    }
    public bool remoaddress(string o)
    {
        int l = int.Parse(o);
        for (int i = 0; i < AddName.Count; i++)
        {
            if (i==l)
            {
                Address.RemoveAt(i);
                AddName.RemoveAt(i);
                return true;
            }
        }        
        return false;
    }
}