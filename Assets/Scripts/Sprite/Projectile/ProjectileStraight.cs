using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// projectile for types that move in straight traj
/// one of the samples that i provide wizdid
/// </summary>
public class ProjectileStraight : ProjectileBase
{

    public override void Setup(Transform target, float damage, int maxCount = 1, int index = 0)
    {
        Setup(target, damage, maxCount, index);

        movementProjectile2D.MoveTo((target.position - transform.position).normalized);
    }

    public override void Process()
    {
        
    }
}
