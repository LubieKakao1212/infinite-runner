using Mono.CompilerServices.SymbolWriter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;


//Not premade but I will add it to my utils
public class SystemManager : MonoBehaviour
{
    [SerializeField]
    private List<GameSystem> systems;

    private Dictionary<Type, GameSystem> typeToSystem;

    public T GetSystem<T>() where T : GameSystem
    {
        typeToSystem.TryGetValue(typeof(T), out var sys);
        return (T)sys;
    }

    private void Awake()
    {
        SetupTypeToSystem();
        SortSystems();

        foreach (var system in systems)
        {
            system.Init(this);
        }
    }

    private void OnDestroy()
    {
        foreach (var system in Enumerable.Reverse(systems))
        {
            system.Deinit();
        }
    }

    private void SortSystems()
    {
        systems = TopoSort.Sort(systems, (s) => GetSystemDependencies(s, typeToSystem));
    }

    private void SetupTypeToSystem()
    {
        typeToSystem = new Dictionary<Type, GameSystem>();

        //Should throw if there exist two systems of the same type
        foreach (var sys in systems)
        {
            typeToSystem.Add(sys.GetType(), sys);
        }
    }

    private static IEnumerable<GameSystem> GetSystemDependencies(GameSystem system, Dictionary<Type, GameSystem> typeToSystem)
    {
        var type = system.GetType();
        var attr = type.GetAttribute<SystemDependenciesAttribute>();

        if (attr != null)
        {
            foreach (var depType in attr.Types)
            {
                if (!typeToSystem.TryGetValue(depType, out var dep))
                {
                    throw new ArgumentException($"System {dep} is required by {system} but is not present.");
                }

                yield return dep;
            }
        }
    }
}
