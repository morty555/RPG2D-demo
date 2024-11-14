using Godot;
using System;

public partial class attackHitbox : Area3D,ihitbox
{
    public bool canstun()
    {
        return false;
    }


    public float Getdamage()
    {
        return GetOwner<character>().GetStatresource(stat.strength).statvalue;
    }
}
