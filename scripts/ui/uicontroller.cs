using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
public partial class uicontroller : Control
{
    private Dictionary<containertype, uicontainer> containers;
    private bool canpause=false;
    public override void _Ready()
    {
        containers = GetChildren().Where(
            (element)=>element is uicontainer)
            .Cast<uicontainer>().ToDictionary((element)=>element.container);
            containers[containertype.start].Visible = true;
            containers[containertype.start].buttonnode.Pressed+=handlestartpressed;
        containers[containertype.pause].buttonnode.Pressed += handlepausepressed;
        containers[containertype.reward].buttonnode.Pressed+=handlerewardpressed;
        gameevents.onendgame+=handleendgame;
            gameevents.onvictory+=handlevictory;
            gameevents.onreward+=handlereward;
    }

    private void handlerewardpressed()
    {
        canpause = true;
        GetTree().Paused = false;
        containers[containertype.stats].Visible = true;
        containers[containertype.reward].Visible = false;

    }


    private void handlereward(rewardresources rewardresources)
    {
        canpause=false;
        GetTree().Paused=true;
        containers[containertype.stats].Visible=false;
        containers[containertype.reward].Visible=true;
        containers[containertype.reward].texturenode.Texture=rewardresources.spritetexture;
        containers[containertype.reward].labelnode.Text=rewardresources.description;
    }


    private void handlepausepressed()
    {
        GetTree().Paused=false;
        containers[containertype.pause].Visible=false;
        containers[containertype.stats].Visible=true;
    }


    public override void _Input(InputEvent @event)
    {
        if(!canpause)
        {
        return;
        }
       if(!Input.IsActionJustPressed(gameconstants.INPUT_PAUSE))
       {
        return;
       }
       containers[containertype.stats].Visible=GetTree().Paused;
       GetTree().Paused=!GetTree().Paused;
        containers[containertype.pause].Visible = GetTree().Paused;
    }

    private void handlevictory()
    {
        canpause=false;
        containers[containertype.stats].Visible=false;
        containers[containertype.victory].Visible=true;
        GetTree().Paused=true;
    }


    private void handleendgame()
    {
        canpause=false;
        containers[containertype.stats].Visible=false;
        containers[containertype.defeat].Visible=true;
    }


    private void handlestartpressed()
    {
        GetTree().Paused=false;
        canpause=true;
        containers[containertype.start].Visible=false;
        containers[containertype.stats].Visible=true;
        
        gameevents.raisestartgame();
    }

}
