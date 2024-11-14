using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : character
{
    public override void _Ready()
    {
        base._Ready();
        gameevents.onreward+=handlereward;
    }

    private void handlereward(rewardresources rewardresources)
    {
      statresource targetstat=GetStatresource(rewardresources.targetsat);
      targetstat.statvalue+=rewardresources.amount;
    }


    public override void _Input(InputEvent @event)
    {
       direction = Input.GetVector(
         gameconstants.INPUT_MOVELEFT, gameconstants.INPUT_MOVERIGHT,
         gameconstants.INPUT_MOVEFORWARD, gameconstants.INPUT_MOVEBACKWARD

        );
      
    }
     

}



