using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Not premade but I will add it to my utils
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class SystemDependenciesAttribute : Attribute
{
    public readonly Type[] Types;

    public SystemDependenciesAttribute(params Type[] types) 
    { 
        this.Types = types;
    }
}
