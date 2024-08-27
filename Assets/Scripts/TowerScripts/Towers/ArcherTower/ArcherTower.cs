using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : TowerBehavior
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float arrowVelocity;
    public override void Shoot(Collider target)
    {
        Arrow shootedArrow = Instantiate(arrow, transform.position, transform.rotation).GetComponent<Arrow>();
        shootedArrow.damage = damage;
        shootedArrow.GetComponent<Rigidbody>().AddForce((target.transform.position - this.transform.position).normalized * arrowVelocity);
        StartCoroutine(ShootInterval());
    }
}
