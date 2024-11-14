using Godot;
using System;

public partial class Lightning : ability
{
    public override void _Ready()
    {
       playernode.AnimationFinished +=(animname)=>QueueFree();
    }
}
