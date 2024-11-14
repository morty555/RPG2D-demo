using Godot;
using System;

public partial class statLabel : Label
{
    [Export] private statresource statresource;
    public override void _Ready()
    {
        statresource.onupdate+=handleupdate;
        Text = statresource.statvalue.ToString();
    }

    private void handleupdate()
    {
        Text=statresource.statvalue.ToString();
    }

}
