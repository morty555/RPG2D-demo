    using Godot;
using System;

public partial class Enemies : Node3D
{
    public override void _Ready()
    {
        int totalenemies = GetChildCount();
        gameevents.raisenewenemycount(totalenemies);
        ChildExitingTree +=handlechileexitingtree;
    }

    private void handlechileexitingtree(Node node)
    {
        int totalenemies = GetChildCount()-1;
        gameevents.raisenewenemycount(totalenemies);
        if(totalenemies==0)
        {
gameevents.raisevictory();
        }
    }

}
