using Godot;
using System;

public partial class Enemy : character
{
    public override void _Ready()
    {
        base._Ready();
        hurtboxnode.AreaEntered+=handleareaentered;
    }

    private void handleareaentered(Area3D area)
    {
       if(area is not ihitbox hitbox){return;}
       if(hitbox.canstun()&&GetStatresource(stat.health).statvalue!=0)
       {
        statemachinenode.switchstate<Stunstate>();
       }
    }

}
