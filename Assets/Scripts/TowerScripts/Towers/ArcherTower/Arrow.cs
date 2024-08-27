using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        //checks if collision is an entity. if so, deals damage to entity
        if (collision.gameObject.GetComponent<IEntity>() != null)
        {
            collision.gameObject.GetComponent<EntityBehavior>().ChangeHealth(damage);
        }
        Destroy(gameObject);
    }
}
