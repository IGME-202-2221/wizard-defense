using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public static bool AABBCollision(GameObject a, GameObject b)
    {
        Vector3 minA = SpriteInfo.Minimum(a);
        Vector3 maxA = SpriteInfo.Maximum(a);
        Vector3 minB = SpriteInfo.Minimum(b);
        Vector3 maxB = SpriteInfo.Maximum(b);

        return minB.x < maxA.x && maxB.x > minA.x && maxB.y > minA.y && minB.y < maxA.y;
    }
    public static bool CircleCollision(GameObject a, GameObject b)
    {
        return SpriteInfo.GetDistance(a, b) < SpriteInfo.GetRadius(a) + SpriteInfo.GetRadius(b);
    }
    public static bool PointBoxCollision(GameObject point, GameObject box)
    {
        return SpriteInfo.GetBounds(box).Contains(SpriteInfo.GetCenter(point));
    }
    public static bool PointCircleCollision(GameObject point, GameObject circ)
    {
        return SpriteInfo.GetDistance(point, circ) < SpriteInfo.GetRadius(circ);
    }
}
