using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UIElements;

//Coppied from https://www.codeproject.com/Articles/869059/Topological-Sorting-in-Csharp
public static class TopoSort
{
    public static List<T> Sort<T>(IEnumerable<T> elements, Func<T, IEnumerable<T>> depsFunc)
    {
        var visited = new Dictionary<T, bool>();
        var sorted = new List<T>();

        foreach (var system in elements)
        {
            Visit(system, sorted, visited, depsFunc);
        }
        return sorted;
    }

    private static void Visit<T>(T node, List<T> sorted, Dictionary<T, bool> visited, Func<T, IEnumerable<T>> depsFunc)
    {
        bool alreadyVisited = visited.TryGetValue(node, out var currentlyVisiting);

        if (alreadyVisited)
        {
            if (currentlyVisiting)
            {
                throw new System.InvalidOperationException("Cicular dependency detected.");
            }
        }
        else
        {
            visited.Add(node, true);

            foreach(var dep in depsFunc(node))
            {
                Visit(dep, sorted, visited, depsFunc);
            }

            visited[node] = false;
            sorted.Add(node);
        }
    }
}
