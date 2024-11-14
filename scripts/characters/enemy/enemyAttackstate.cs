using Godot;
using System;
using System.Linq;

public partial class enemyAttackstate : enemystate
{
    private Vector3 targetposition;
    protected override void enterstate()
    {
        characternode.animplayernode.Play(gameconstants.ANIM_ATTACK);
        Node3D target = characternode.attackareanode.GetOverlappingBodies().First();
        targetposition = target.GlobalPosition;
        characternode.animplayernode.AnimationFinished+= handleanimationfinished;
        
    }

    protected override void exitstate()
    {
        characternode.animplayernode.AnimationFinished -= handleanimationfinished;
    
    }
    private void handleanimationfinished(StringName animName)
    {
        characternode.togglehitbox(true);
        Node3D target = characternode.attackareanode.GetOverlappingBodies().FirstOrDefault();
        if(target == null)
        {
            Node3D chasetarget = characternode.chaseareanode.GetOverlappingBodies().FirstOrDefault();
            if(chasetarget == null)
            {
                characternode.statemachinenode.switchstate<enemyReturnstate>();
                return ;
            }
           characternode.statemachinenode.switchstate<Chasestate>();
           return;
        }
        characternode.animplayernode.Play(gameconstants.ANIM_ATTACK);
        targetposition = target.GlobalPosition;
        Vector3 direction = characternode.GlobalPosition.DirectionTo(targetposition);
        characternode.spritenode.FlipH = direction.X<0;
    }

    private void performhit()
 {
    characternode.togglehitbox(false);
    characternode.hitboxnode.GlobalPosition = targetposition;
 }


}
