using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///TypeFactory 的摘要说明
/// </summary>
public class TypeFactory
{
    public List<Type> myTypeFactory = new List<Type>();
	public TypeFactory()
	{
	    
	}
    public void AddItem(Type Type)
    {
        myTypeFactory.Add(Type);
    }
    public void RemoveItem(Type Type)
    {
        myTypeFactory.Remove(Type);
    }
}