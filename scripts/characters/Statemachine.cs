using Godot;
using System;
using System.Linq;

public partial class Statemachine : Node
{
    [Export]private Node currentstate;
    [Export]private characterstate[] states;
    public override void _Ready()
    {
        currentstate.Notification(gameconstants.NOTIFICATION_ENTER_STATE);
    }

public void switchstate<T>()
{
    characterstate newstate = states.Where((state)=>state is T).FirstOrDefault();
    
        if (newstate == null) { return; }
        if(currentstate is T){return;}
        if(!newstate.cantransition()){return;}
        currentstate.Notification(gameconstants.NOTIFICATION_EXIT_STATE);
        currentstate = newstate;
        currentstate.Notification(gameconstants.NOTIFICATION_ENTER_STATE);
    }
}