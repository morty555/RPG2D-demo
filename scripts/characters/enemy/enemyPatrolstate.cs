using Godot;
using System;
using System.Runtime.Serialization;

public partial class enemyPatrolstate : enemystate
{
    [Export] private Timer idletimernode;
   [Export(PropertyHint.Range,"0,20,0.1")] private int pointindex = 0;
    private float maxidletime = 4;
    protected override void enterstate()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_MOVE);
        pointindex = 1;
        
        destination = getpointglobalposition(pointindex);
        characternode.agentnode.TargetPosition = destination;
        characternode.agentnode.NavigationFinished += handlenavigationfinished;
        idletimernode.Timeout += handletimeout;
        characternode.chaseareanode.BodyEntered+=handlechaseareabodyentered;
    }

  


    public override void _PhysicsProcess(double delta)
    {
        if(!idletimernode.IsStopped())
        {
            return;
        }
       move();
    }
    private void handlenavigationfinished()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_IDLE);
        RandomNumberGenerator rng = new();
        idletimernode.WaitTime = rng.RandfRange(0,maxidletime);
        idletimernode.Start();
      
    }
    protected override void exitstate()
    {
        characternode.agentnode.NavigationFinished -= handlenavigationfinished;
        idletimernode.Timeout -= handletimeout;
        characternode.chaseareanode.BodyEntered -= handlechaseareabodyentered;
    }
    private void handletimeout()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_MOVE);
        pointindex = Mathf.Wrap(pointindex + 1, 0, characternode.pathnode.Curve.PointCount);
        destination = getpointglobalposition(pointindex);
        characternode.agentnode.TargetPosition = destination;
    }
}
