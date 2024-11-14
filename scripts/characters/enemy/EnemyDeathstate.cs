using Godot;
using System;

public partial class EnemyDeathstate : enemystate
{
    protected override void enterstate()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_DEATH);
        characternode.animplayernode.AnimationFinished += handleanimationfinished;
    }

    private void handleanimationfinished(StringName animName)
    {
        characternode.pathnode.QueueFree();
    }

}
