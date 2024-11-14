using Godot;
using System;

public partial class playeridlestate : playerstate
{
   
    public override void _PhysicsProcess(double delta)
    {
       
        if(characternode.direction!= Vector2.Zero)
        {
            characternode.statemachinenode.switchstate<Movestate>();
        }
    }
   
    public override void _Input(InputEvent @event)
    {
        checkforattackinput();
        if(Input.IsActionJustPressed(gameconstants.ANIM_DASH))
        {
            characternode.statemachinenode.switchstate<Dashstate>();
        }
    }
    protected override void enterstate()
    {
        base.enterstate();
        characternode.animplayernode.Play(gameconstants.ANIM_IDLE);
    }
}
