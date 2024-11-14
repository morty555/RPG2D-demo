using Godot;
using System;

public partial class enemyReturnstate : enemystate
{
    

    public override void _Ready()
    {
        base._Ready();

        destination = getpointglobalposition(0);
    }
    protected override void enterstate()
    {
        
        characternode.animplayernode.Play(gameconstants.ANIM_MOVE);
        characternode.agentnode.TargetPosition = destination;
        characternode.chaseareanode.BodyEntered += handlechaseareabodyentered;
    }
    protected override void exitstate()
    {
        characternode.chaseareanode.BodyEntered -= handlechaseareabodyentered;
    }
    public override void _PhysicsProcess(double delta)
    {
        if(characternode.agentnode.IsNavigationFinished())
        {
           characternode.statemachinenode.switchstate<enemyPatrolstate>();
           return;

        }
   move();
    }
}
