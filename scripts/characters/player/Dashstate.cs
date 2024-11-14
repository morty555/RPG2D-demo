using Godot;
using System;

public partial class Dashstate : playerstate
{
    [Export]private PackedScene bombscene;
    [Export]private Timer dashtimernode;
    [Export]private Timer cooldowntimernode;
    [Export(PropertyHint.Range,"0,20,0.1")]private float speed =10;
    public override void _Ready()
    {
        base._Ready();
        dashtimernode.Timeout += handledashtimeout;
        cantransition=()=>cooldowntimernode.IsStopped();
    }
    protected override void enterstate()
    {
     
            characternode.animplayernode.Play(gameconstants.ANIM_DASH);
            characternode.Velocity = new(
                characternode.direction.X,0,characternode.direction.Y
            );
            if(characternode.Velocity==Vector3.Zero)
            {
                characternode.Velocity=characternode.spritenode.FlipH ?
                Vector3.Left:
                Vector3.Right;

            }
            characternode.Velocity*=speed;
            dashtimernode.Start();
            Node3D bomb =bombscene.Instantiate<Node3D>();
            GetTree().CurrentScene.AddChild(bomb);
            bomb.GlobalPosition = characternode.GlobalPosition;
        
    }
    public override void _PhysicsProcess(double delta)
    {
       characternode.MoveAndSlide();
       characternode.flip();
    }
    private void handledashtimeout()
    {
        cooldowntimernode.Start();
        characternode.Velocity = Vector3.Zero;
        characternode.statemachinenode.switchstate<playeridlestate>();
    }
}
