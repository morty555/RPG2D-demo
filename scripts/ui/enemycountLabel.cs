using Godot;
using System;
using System.Threading;

public partial class enemycountLabel : Label
{
    public override void _Ready()
    {
        gameevents.onnewenemycount+=handleenemycount;
    }

    private void handleenemycount(int count)
    {
       Text =count.ToString();
    }

}
