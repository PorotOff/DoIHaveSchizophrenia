using UnityEngine;

public class DebugRayDrawerModel
{
    public void DebugDrawRay(Ray ray, float length, Color color)
    {
        Debug.DrawRay(ray.origin, ray.direction * length, color);
    }
}