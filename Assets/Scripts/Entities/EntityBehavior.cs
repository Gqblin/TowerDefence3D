using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EntityBehavior : MonoBehaviour , IEntity
{
    public float _maxHealth;
    public float health { get { return _maxHealth; } set { _maxHealth = value; } }

    public float _speed;
    public float speed { get { return _speed; } set { _speed = value; } }

    public float _damage;
    public float damage { get { return _damage; } set { _damage = value; } }

    public EntityType[] _entityType;
    public EntityType[] entityType { get { return _entityType; } set { _entityType = value; } }

    public DamageTypes[] _immuneDamageTypes;
    public DamageTypes[] immuneDamageTypes { get { return _immuneDamageTypes; } set { _immuneDamageTypes = value; } }

    public DamageTypes[] _ineffectiveDamageTypes;
    public DamageTypes[] ineffectiveDamageTypes { get { return _ineffectiveDamageTypes; } set { _ineffectiveDamageTypes = value; } }

    public DamageTypes[] _superEffectiveDamageTypes;
    public DamageTypes[] superEffectiveDamageTypes { get { return superEffectiveDamageTypes; } set { superEffectiveDamageTypes = value; } }

    private Slider slider;
    public Gradient gradient;
    public Image healthBarFill;
    private Transform target;

    private void Start()
    {
        //target = FindObjectOfType<Tower>().transform;

        slider = GetComponentInChildren<Slider>();
        slider.maxValue = _maxHealth;
        slider.value = health;
        healthBarFill.color = gradient.Evaluate(1f);
    }

    public void Attack()
    {

    }

    public void ChangeHealth(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        if(health > _maxHealth)
        {
            health = _maxHealth;
        }
        slider.value = health;
        healthBarFill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
