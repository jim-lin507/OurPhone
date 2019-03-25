using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ShopCart 的摘要说明
/// </summary>
public class ShoppingCart
{
   public  List<CartItem> myCartItem = new List<CartItem>();
    public ShoppingCart()
    { }
    public ShoppingCart(CartItem CItem)
    {
        myCartItem.Add(CItem);
    }
    public ShoppingCart(List<CartItem> myCartItem)
    {
        this.myCartItem = myCartItem;
    }
    public bool AddItem(CartItem CItem)
    {
        /*foreach (CartItem ci in myCartItem)
        {
            if (ci.ProductId == CItem.ProductId)
            {
                ci.Quantity += CItem.Quantity;
                return true;
            }
        }*/
        myCartItem.Add(CItem);
        return true;
    }
    public void RemoveItem(CartItem CItem)
    {
        myCartItem.Remove(CItem);
    }
    public double Sum()
    {
        double sumPrice = 0;
        /*foreach (CartItem ci in myCartItem)
        {
            sumPrice = sumPrice + ci.Quantity * double.Parse(ci.Price);
        }*/
        return sumPrice;
    }
}