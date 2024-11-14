using Godot;
using System;
public partial class Movestate : playerstate
{
    [Export(PropertyHint.Range,"0,20,0.1")]private float speed = 5;
   
    public override void _PhysicsProcess(double delta)
    {
        if(characternode.direction==Vector2.Zero)
        {
            characternode.statemachinenode.switchstate<playeridlestate>();
        return;
        }
        
        characternode.Velocity = new(characternode.direction.X, 0, characternode.direction.Y);
        characternode.Velocity = characternode.Velocity * speed;
        characternode.MoveAndSlide();
        characternode.flip();
    }
    protected override void enterstate()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_MOVE);
    }
    public override void _Input(InputEvent @event)
    {
        checkforattackinput();
        if(Input.IsActionJustPressed(gameconstants.ANIM_DASH))
        {
            characternode.statemachinenode.switchstate<Dashstate>();
            
        }
    }
}
