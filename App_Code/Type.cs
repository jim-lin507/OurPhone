using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Type 的摘要说明
/// </summary>
public class Type
{
    private string _TypeId;
    private string _SmallTypeId;
    private string _TypeName;
    private string _SmallTypeName;
    public string TypeId
    {
        get { return _TypeId; }
        set { this._TypeId = value; }
    }
    public string SmallTypeId
    {
        get { return _SmallTypeId; }
        set { this._SmallTypeId = value; }
    }
    public string TypeName
    {
        get { return _TypeName; }
        set { this._TypeName = value; }
    }
    public string SmallTypeName
    {
        get { return _SmallTypeName; }
        set { this._SmallTypeName = value; }
    }
    public Type(string typeId, string typeName, string smallTypeId, string smallTypeName)
	{
        this._TypeId = typeId;
        this._SmallTypeId = smallTypeId;
        this._TypeName = typeName;
        this._SmallTypeName = smallTypeName;
	}
}