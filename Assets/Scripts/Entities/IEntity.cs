using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    float health { get; }
    float speed { get; }
    float damage { get; }
    EntityType[] entityType { get; }
    DamageTypes[] immuneDamageTypes { get; }
    DamageTypes[] ineffectiveDamageTypes { get; }
    DamageTypes[] superEffectiveDamageTypes { get; }

    void Attack();
}
