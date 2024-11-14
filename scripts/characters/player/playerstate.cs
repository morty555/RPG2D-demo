using System;
using Godot;

public abstract partial class playerstate:characterstate
{
    public override void _Ready()
    {
        base._Ready();
        characternode.GetStatresource(stat.health).onzero+=handlezerohealth;
    }

    private void handlezerohealth()
    {
        characternode.statemachinenode.switchstate<PlayerDeathstate>();
    }

    protected void checkforattackinput()
    {
        if(Input.IsActionJustPressed(gameconstants.INPUT_ATTACK))
        {
           characternode.statemachinenode.switchstate<Attackstate>();
         
        }
    }
   
}
