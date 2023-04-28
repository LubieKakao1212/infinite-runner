using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    //Copied from
    //https://www.shadertoy.com/view/Ml3Gz8
    public static float SmoothMin(float a, float b, float k)
    {
        float h = Mathf.Clamp01(0.5f + 0.5f * (a-b)/k);
        return Mathf.Lerp(a, b, h) - k*h*(1f-h);
    }

    public static float SmoothMax(float a, float b, float k)
    {
        return -SmoothMin(-a, -b, k);
    }
}
