using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour , ITower
{
    public float _damage;
    public float damage { get { return _damage; } set { _damage = value; } }

    public float _interval;
    public float interval { get { return _interval; } set { _interval = value; } }

    public float _range;
    public float range { get { return _range; } set { _range = value; } }

    public EntityType[] _targets;
    public EntityType[] targets { get { return _targets; } set { _targets = value; } }

    public DamageTypes _damageType;
    public DamageTypes damageType { get { return _damageType; } set { _damageType = value; } }

    protected bool intervalActive;

    public LayerMask entityLayer;

    protected Collider mainTarget;

    public virtual void Update()
    {
        //searches for entities in radius and sets target
        Collider[] targets = Physics.OverlapBox(transform.position, new Vector3(range, range, range), Quaternion.Euler(0, 0, 0), entityLayer);
        if(targets.Length > 0)
        {
            if(mainTarget == null)
            {
                mainTarget = targets[0];
            }
            else
            {
                bool isTargetStillInRange = false;
                for(int i = 0; i < targets.Length; i++)
                {
                    if(targets[i] == mainTarget)
                    {
                        isTargetStillInRange = true;
                        break;
                    }
                }
                if (!isTargetStillInRange)
                {
                    mainTarget = targets[0];
                }
            }
        }
        else
        {
            mainTarget = null;
        }

        if (!intervalActive && mainTarget != null)
        {
            for (int i = 0; i < 1; i++)
            {
                Shoot(mainTarget);
            }

        }
    }

    private void CheckIfCanTarget(EntityType[] towertypes, EntityType[] enemyTypes)
    {
        
    }

    //shoots at target.. how differs per tower
    public virtual void Shoot(Collider target)
    {
        target.GetComponent<EntityBehavior>().ChangeHealth(damage);
        StartCoroutine(ShootInterval());
    }

    protected IEnumerator ShootInterval()
    {
        intervalActive = true;
        yield return new WaitForSeconds(interval);
        intervalActive = false;
    }
}
