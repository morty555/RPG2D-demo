using Godot;
using System;


public partial class PlayerDeathstate : playerstate
    {
        protected override void enterstate()
        {
            characternode.animplayernode.Play(gameconstants.ANIM_DEATH);
            characternode.animplayernode.AnimationFinished += handleanimationfinished;
        }

        private void handleanimationfinished(StringName animName)
        {
            gameevents.raiseendgame();
            characternode.QueueFree();
        }

    }


