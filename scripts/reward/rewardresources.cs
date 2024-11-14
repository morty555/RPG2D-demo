using Godot;
[GlobalClass]
public partial class rewardresources:Resource
{
   [Export] public Texture2D spritetexture{get;private set;}
   [Export]public string description{get;private set;}
   [Export]public stat targetsat{get;private set;}
   [Export(PropertyHint.Range,"1,100,1")]
   public float amount {get;private set;}

}