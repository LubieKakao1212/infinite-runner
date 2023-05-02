using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Not premade but I will add it to my utils
public class GameSystem : MonoBehaviour
{
    public SystemManager SystemManager => systemManager;

    private SystemManager systemManager;

    public void Init(SystemManager manager) 
    {
        if(systemManager != null)
        {
            throw new System.ArgumentException("System initialized twice");
        }

        systemManager = manager;

        Init();
    }

    protected virtual void Init() { }

    public virtual void Deinit() { }
}
