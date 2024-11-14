using System;
using Godot;
using System.Linq;

public abstract partial class character : CharacterBody3D
{
    [Export] private statresource[] stats;

    [ExportGroup("required nodes")]
    [Export] public AnimationPlayer animplayernode { get; private set; }
    [Export] public Sprite3D spritenode { get; private set; }
    [Export] public Statemachine statemachinenode { get; private set; }
    [Export] public Area3D hurtboxnode{get;private set;}
    [Export] public Area3D hitboxnode{get;private set;}
    [Export] public CollisionShape3D hitboxshapenode  {get;private set;}
    [Export] public Timer shadertimernode{get;private set;}
    
    [ExportGroup("ainodes")]
    [Export] public Path3D pathnode{get;private set;}
    [Export] public NavigationAgent3D agentnode{get;private set;}
    [Export] public Area3D chaseareanode {get;private set; }
    [Export] public Area3D attackareanode {get;private set;}
    public Vector2 direction = new();
    public ShaderMaterial shader;

    public override void _Ready()
    {
        shader = (ShaderMaterial)spritenode.MaterialOverlay;
        hurtboxnode.AreaEntered+=handlehurtboxentered;
        spritenode.TextureChanged+=handletexturechanged;
        shadertimernode.Timeout+=handleshadertimeout;
    }

    private void handleshadertimeout()
    {
        shader.SetShaderParameter("active",false);

    }

    private void handletexturechanged()
    {
       shader.SetShaderParameter("tex",spritenode.Texture);
    }

    private void handlehurtboxentered(Area3D area)
    {
     if(area is not ihitbox hitbox)
     {
          return;
     }
        statresource health= GetStatresource(stat.health);
        float damage = hitbox.Getdamage();
        health.statvalue -= damage;
        shader.SetShaderParameter("active",true);
        shadertimernode.Start();
    }
public statresource GetStatresource(stat stat)
{
   return stats.Where((element)=> element.stattype == stat).FirstOrDefault();
 
 
}
    public void flip()
    {
        bool isnotmovinghorizontally = Velocity.X == 0;
        if (isnotmovinghorizontally == true) { return; }
        bool ismovingleft = Velocity.X < 0;
        spritenode.FlipH = ismovingleft;
    }

   public void togglehitbox(bool flag)
   {
       hitboxshapenode.Disabled= flag;
   }
}