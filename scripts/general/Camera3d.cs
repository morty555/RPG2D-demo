using Godot;
using System;

public partial class Camera3d : Camera3D
{
   [Export] private Node target;
   [Export] private Vector3 positionfromtarget;
    public override void _Ready()
    {
        gameevents.onstartgame +=handlestartgame;
        gameevents.onendgame+=handleendgame;
    }

    private void handleendgame()
    {
        Reparent(GetTree().CurrentScene);
    }


    private void handlestartgame()
    {
       Reparent(target);
       Position = positionfromtarget;
    }

}
