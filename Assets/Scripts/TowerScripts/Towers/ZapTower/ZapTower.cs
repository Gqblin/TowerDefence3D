using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapTower : TowerBehavior
{
    [SerializeField] private float chanceToStun;
    [SerializeField] private float stunDuration;
    public override void Shoot(Collider target)
    {
        base.Shoot(target);
        if(Random.Range(1f,100f) <= chanceToStun)
        {
            StartCoroutine(stunEntity(target, stunDuration));
        }
    }

    IEnumerator stunEntity(Collider target, float duration)
    {
        print("stunned");
        yield return new WaitForSeconds(duration);
    }
}
