using Godot;
using System;

public partial class enemyIdlestate : enemystate
{
    protected override void enterstate()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_IDLE);
        characternode.chaseareanode.BodyEntered +=handlechaseareabodyentered;
    }
    protected override void exitstate()
    {
        characternode.chaseareanode.BodyEntered -= handlechaseareabodyentered;
    }
    public override void _PhysicsProcess(double delta)
    {
        characternode.statemachinenode.switchstate<enemyReturnstate>();
    }
}

