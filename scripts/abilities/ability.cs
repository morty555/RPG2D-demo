using Godot;
public abstract partial class ability:Node3D
{
    [Export] public float damage { get; private set; } = 10;
    [Export] protected AnimationPlayer playernode;
}