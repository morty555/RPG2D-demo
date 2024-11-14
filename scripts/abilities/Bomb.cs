using Godot;
using System;

public partial class Bomb : ability
{
  
 
    public override void _Ready()
    {
       playernode.AnimationFinished+=handleexpandanimationfinished;
    }

    private void handleexpandanimationfinished(StringName animName)
    {
       if(animName == gameconstants.ANIM_EXPAND)
       {
        playernode.Play(gameconstants.ANIM_EXPLOSION);
       }
       else
       {
        QueueFree();
       }
    }

}
