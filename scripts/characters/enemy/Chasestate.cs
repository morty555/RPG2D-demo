using Godot;
using System;
using System.Linq;

public partial class Chasestate : enemystate
{
    [Export] private Timer timernode;
   private CharacterBody3D target;
    protected override void enterstate()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_MOVE);
        target = characternode.chaseareanode.GetOverlappingBodies().First() as CharacterBody3D;
        timernode.Timeout+= handletimeout;
        characternode.attackareanode.BodyEntered +=handleattackbodyentered;
        characternode.chaseareanode.BodyExited+=handlechasebodyentered;
    }

    private void handlechasebodyentered(Node3D body)
    {
        characternode.statemachinenode.switchstate<enemyReturnstate>();
    }


    private void handleattackbodyentered(Node3D body)
    {
       characternode.statemachinenode.switchstate<enemyAttackstate>();

    }


    protected override void exitstate()
    {
        timernode.Timeout -= handletimeout;
        characternode.attackareanode.BodyEntered -= handleattackbodyentered;
        characternode.chaseareanode.BodyExited -= handlechasebodyentered;
    }
    private void handletimeout()
    {
        destination = target.GlobalPosition;
        characternode.agentnode.TargetPosition = destination;
    }


    public override void _PhysicsProcess(double delta)
    {
        
        move();
    }
}
