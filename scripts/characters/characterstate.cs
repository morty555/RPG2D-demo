using System;
using Godot;

public abstract partial class characterstate : Node
{
    protected character characternode;
    public Func<bool> cantransition=()=>true;
    public override void _Ready()
    {
        characternode = GetOwner<character>();

        SetPhysicsProcess(false);
        SetProcessInput(false);
    }
    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == gameconstants.NOTIFICATION_ENTER_STATE)
        {

            enterstate();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == gameconstants.NOTIFICATION_EXIT_STATE)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
            exitstate();
        }
    }
    protected virtual void enterstate()
    {

    }
    protected virtual void exitstate(){}
}
