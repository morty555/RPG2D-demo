using System;
using System.Security.Cryptography.X509Certificates;
using Godot;


[GlobalClass]
public partial class statresource:Resource
{
       public event Action onzero;
       public event Action onupdate;
   [Export] public stat stattype {get;private set;}
   private float _statvalue;
  [Export] public float statvalue{
    get=> _statvalue;
     set
     {
            _statvalue=Mathf.Clamp(value,0,Mathf.Inf);
            onupdate?.Invoke();
            if(_statvalue==0)
            {
              onzero?.Invoke();
            }
     }
     }
}