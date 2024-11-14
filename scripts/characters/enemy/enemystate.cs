using System;
using Godot;

public abstract partial class enemystate : characterstate
{
  protected Vector3 destination;
    public override void _Ready()
    {
        base._Ready();
        characternode.GetStatresource(stat.health).onzero+=handlezerohealth;
    }

    private void handlezerohealth()
    {
        characternode.statemachinenode.switchstate<EnemyDeathstate>();
    }

    protected Vector3 getpointglobalposition(int index)
  {
        Vector3 localposition = characternode.pathnode.Curve.GetPointPosition(index);
        Vector3 globalposition = characternode.pathnode.GlobalPosition;
        return localposition + globalposition;
    }
    protected void move()
    {
        characternode.agentnode.GetNextPathPosition();
        characternode.Velocity = characternode.GlobalPosition.DirectionTo(destination);
        characternode.MoveAndSlide();
        characternode.flip();
    }
    protected void handlechaseareabodyentered(Node3D body)
    {
      characternode.statemachinenode.switchstate<Chasestate>();
    }

}