using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float damage;
    [SerializeField] LayerMask entityLayer;


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IEntity>() != null)
        {
            //get all entities in radius and deals damage
            Collider[] entitiesInRadius = Physics.OverlapSphere(transform.position, radius, entityLayer);
            for(int i = 0; i < entitiesInRadius.Length; i++)
            {
                entitiesInRadius[i].GetComponent<EntityBehavior>().ChangeHealth(damage);
                print("dfgdfrg");
            }
            Destroy(gameObject);
        }
    }
}
