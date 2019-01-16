using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSystem
{
    public BaseSystem()
    {
        //ClientMain.Instance.AddSystem(this);
    }

    public virtual void Initialize() { }
    public virtual void Release() { }
    public virtual void Update() { }
}
