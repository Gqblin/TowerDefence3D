using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    float damage { get; }
    float interval { get; }
    float range { get; }
    EntityType[] targets { get; }
    DamageTypes damageType { get; }

    void Shoot(Collider target);
}
