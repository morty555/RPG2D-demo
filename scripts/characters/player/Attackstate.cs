using Godot;
using System;

public partial class Attackstate : playerstate
{
    [Export] private PackedScene lightningscene;
    [Export]private Timer combotimernode;
    private int combocounter= 1;
    private int maxcombocount = 2;
    public override void _Ready()
    {
        base._Ready();
        combotimernode.Timeout+=()=>combocounter =1;
    }
    protected override void enterstate()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_ATTACK+combocounter,-1,1.5f);
        characternode.animplayernode.AnimationFinished+=handleanimationfinished;
        characternode.hitboxnode.BodyEntered += handlebodyentered;

    }

    private void handlebodyentered(Node3D body)
    {
       if(combocounter!=maxcombocount)
       {
         return;
       }
       Node3D lightning = lightningscene.Instantiate<Node3D>();
       GetTree().CurrentScene.AddChild(lightning);
       lightning.GlobalPosition = body.GlobalPosition;
    }


    protected override void exitstate()
    {
        characternode.animplayernode.AnimationFinished -= handleanimationfinished;
        characternode.hitboxnode.BodyEntered -= handlebodyentered;
        combotimernode.Start();
    }
    private void handleanimationfinished(StringName animName)
    {
        combocounter++;
        combocounter = Mathf.Wrap(combocounter,1,maxcombocount+1);
        characternode.togglehitbox(true);
        characternode.statemachinenode.switchstate<playeridlestate>();
    }

   private void performhit()
   {
    Vector3 left = new Vector3(0, 0, 1);
        Vector3 right = new Vector3(0, 0, -1);
        Vector3 newposition = characternode.spritenode.FlipH?left:right;
    float distancemultiplier = 0.75f;
    newposition *=distancemultiplier;
    characternode.hitboxnode.Position = newposition;
    characternode.togglehitbox(false);
   }
}
