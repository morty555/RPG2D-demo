using Godot;
using System;

public partial class uicontainer :Container
{
    [Export] public containertype container{get;private set;}
    [Export] public Button buttonnode {get;private set;}
    [Export]public TextureRect texturenode{get;private set;}
    [Export]public Label labelnode{get;private set;}
}
