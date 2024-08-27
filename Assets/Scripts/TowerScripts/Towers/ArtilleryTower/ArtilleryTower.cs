using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryTower : TowerBehavior
{
    [SerializeField] private GameObject rocket;
    [SerializeField] private float RocketVelocity;
    public override void Shoot(Collider target)
    {

    }
}
