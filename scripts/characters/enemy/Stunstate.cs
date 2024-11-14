using Godot;
using System;

public partial class Stunstate : enemystate
{
    protected override void enterstate()
    {
        base.enterstate();
        characternode.animplayernode.Play(gameconstants.ANIM_STUN);
        characternode.animplayernode.AnimationFinished+=handleanimationfinished;
    }

    protected override void exitstate()
    {
        characternode.animplayernode.AnimationFinished-=handleanimationfinished;
    }
    private void handleanimationfinished(StringName animName)
    {
       if(characternode.attackareanode.HasOverlappingBodies())
       {
        characternode.statemachinenode.switchstate<enemyAttackstate>();
       }
       else if(characternode.chaseareanode.HasOverlappingBodies())
       {
        characternode.statemachinenode.switchstate<Chasestate>();
       }
       else
       {
        characternode.statemachinenode.switchstate<enemyIdlestate>();
       }
    }

}
