using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{

    public static SpriteRenderer GetSprite(GameObject sprite)
    {
        return sprite.GetComponent<SpriteRenderer>();
    }
    public static Bounds GetBounds(GameObject sprite)
    {
        return GetSprite(sprite).bounds;
    }
    public static Vector3 Minimum(GameObject sprite)
    {
        return GetBounds(sprite).min;
    }
    public static Vector3 Maximum(GameObject sprite)
    {
        return GetBounds(sprite).max;
    }
    public static Vector3 GetCenter(GameObject sprite)
    {
        return GetBounds(sprite).center;
    }
    public static float GetDistance(GameObject a, GameObject b)
    {
        return (GetCenter(b) - GetCenter(a)).magnitude; 
    }
    public static float GetRadius(GameObject sprite)
    {
        return GetBounds(sprite).extents.magnitude;
    }
    
}
