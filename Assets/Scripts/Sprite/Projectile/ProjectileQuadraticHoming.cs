using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileQuadraticHoming : ProjectileBase
{

    private Vector2 start, end, point;
    private float duration, t = 0f;
    private Transform target;

    public override void Setup(Transform target, float damage, int maxCount = 1, int index = 0)
    {
        base.Setup(target, damage);

        this.target = target;
        start = transform.position;
        end = this.target.position;

        float distance = Vector3.Distance(start, end);

        duration = distance / movementProjectile2D.MoveSpeed;

        float angle = 45; // for now, can always change

        angle += Utils.GetAngleFromPosition(start, end);

        point = Utils.GetNewPoint(start, angle, distance * 0.3f);
    }

    public override void Process()
    {
        end = target.position;
        t += Time.deltaTime / duration;
        transform.position = Utils.QuadraticCurve(start, end, point, t); 
    }
    
}
