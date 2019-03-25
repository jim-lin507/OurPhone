using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///CartItem 的摘要说明
/// </summary>
public class CartItem
{
    private string _UerId;
    private string _ProductId;
    private int _Quantity;
    private string _StoreId;
    /*private int num = 0;
    private string _Price;
    private string _SmallImagePath;*/
    
    public string UerId
    {
        get { return _UerId; }
        set { this._UerId = value; }
    }
    public string ProductId
    {
        get { return _ProductId; }
        set { this._ProductId = value; }
    }
    public int Quantity
    {
        get { return _Quantity; }
        set { this._Quantity = value; }
    }
    /*public string Price
    {
        get { return _Price; }
        set { this._Price = value; }
    }
    
    public string SmallImagePath
    {
        get { return _SmallImagePath; }
        set { this._SmallImagePath = value; }
    }
    public int Num
    {
        get { return num; }
        set { num = value; }
    }*/
    public string StoreId
    {
        get { return _StoreId; }
        set { this._StoreId = value; }
    }
    public CartItem(string userId, string productid, string storeId, int quantity)
    {
        this._UerId = userId;
        this._ProductId = productid;
        this._StoreId = storeId;
        this._Quantity = quantity;        
    }
    /*public CartItem(string userId, string productid, string price, int quantity, string smallimagepath, string storeId)
    {
        this._UerId = userId;
        this._ProductId = productid;
        this._Price = price;
        this._Quantity = quantity;
        this._SmallImagePath = smallimagepath;
        this._StoreId = storeId;
    }*/
}