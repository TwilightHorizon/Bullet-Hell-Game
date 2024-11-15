using System;
using UnityEngine;

public class Utils  
{
    public static float Percent(float current, float max)
    {
        return current!=0 && max !=0 ? current / max : 0;
    }

    /// <summary>
    /// Use polar coordinates to find the position using the distance
    /// from the origin and the angle from the horizontal axis
    /// 
    /// angle = arctan(y/x)
    /// Find x, y displacement values as dx, dy
    /// 
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="target"></param>
    /// <returns> THE DEGREE </returns>
    public static float GetAngleFromPosition(Vector2 owner, Vector2 target)
    {
        float dx = target.x - owner.x;
        float dy = target.y - owner.y;

        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        return degree;
    }

    /// <summary>
    /// Changes Degree value into Radian value
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static float DegreeToRadian(float angle)
    {
        return Mathf.PI * angle / 180;
    }

    public static Vector2 GetNewPoint(Vector3 start, float angle, float r)
    {
        angle = DegreeToRadian(angle);

        Vector2 position = Vector2.zero;
        position.x = Mathf.Cos(angle) * r + start.x;
        position.y = Mathf.Sin(angle) * r + start.y;

        return position;
    }

    public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }

    public static Vector2 QuadraticCurve(Vector2 a, Vector2 b, Vector2 c, float t)
    {
        Vector2 p1 = Lerp(a, b, t);
        Vector2 p2 = Lerp(b, c, t);

        return Lerp(p1, p2, t);
    }

    public static Vector2 CubicCurve(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
    {
        Vector2 p1 = QuadraticCurve(a, b, c, t);
        Vector2 p2 = QuadraticCurve(b, c, d, t);

        return Lerp(p1, p2, t);
    }
    
}
