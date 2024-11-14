using Godot;
using System;

public partial class abilityHitbox : Area3D,ihitbox
{
    public bool canstun()
    {
       return true;
    }


    public float Getdamage()=>GetOwner<ability>().damage;
    
}
