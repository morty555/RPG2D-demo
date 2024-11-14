using Godot;
using System;

public partial class Treasurechest : StaticBody3D
{
   [Export] private Area3D areanode;
   [Export] private Sprite3D spritenode;
   [Export] private rewardresources reward;

    public override void _Ready()
    {
       areanode.BodyEntered+=(body)=>spritenode.Visible=true;
       areanode.BodyExited+=(body)=>spritenode.Visible=false;
    }
    public override void _Input(InputEvent @event)
    {
        if(!areanode.Monitoring||!areanode.HasOverlappingBodies()||!Input.IsActionJustPressed(gameconstants.INPUT_INTERACT))
        {
           return;
        }
        areanode.Monitoring=false;
       gameevents.Raiserewad(reward);
    }
}
