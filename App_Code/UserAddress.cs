using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///UserAddress 的摘要说明
/// </summary>
public class UserAddress
{
    public int ID { set; get; }
    public string Userid { set; get; }
    public string Name { set; get; }
    public string Address { set; get; }
    public double Money { set; get; }
    public bool IsDefault { set; get; }
	public UserAddress()
	{
	}
    public UserAddress(string u,string n,string a,double m,bool s)
    {
       // ID = i;
        Userid = u;
        Name = n;
        Address = a;
        Money = m;
        IsDefault = s;
    }
}