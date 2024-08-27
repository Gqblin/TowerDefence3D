using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeachTower : TowerBehavior
{
    [SerializeField] private float chargeDamagePerSec = 50;
    [SerializeField] private float damageNeededForFullCharge = 2000;
    [SerializeField] private float chargeDamageDone;
    [SerializeField] private float chargedPercentage;


    //UI shit
    private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image chargeBarFill;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = 100;
        slider.value = chargedPercentage;
        gradient = GetComponent<Gradient>();
    }

    public override void Update()
    {
        Collider[] targets = Physics.OverlapBox(transform.position, new Vector3(range, range, range), Quaternion.Euler(0, 0, 0), entityLayer);
        if (targets.Length > 0)
        {
            if (mainTarget == null)
            {
                mainTarget = targets[0];
            }
            else
            {
                bool isTargetStillInRange = false;
                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] == mainTarget)
                    {
                        isTargetStillInRange = true;
                        break;
                    }
                }
                if (!isTargetStillInRange)
                {
                    mainTarget = null;
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
                ChargeTower(mainTarget);
            }

        }
    }
    private void ChargeTower(Collider target)
    {
        target.GetComponent<EntityBehavior>().ChangeHealth(chargeDamagePerSec * Time.deltaTime);
        chargeDamageDone += chargeDamagePerSec * Time.deltaTime;
        CalculateChargedPercentage();
    }

    private void CalculateChargedPercentage()
    {
        chargedPercentage = chargeDamageDone / damageNeededForFullCharge * 100;
        slider.value = chargedPercentage;
        chargeBarFill.color = gradient.Evaluate(slider.normalizedValue);
        if (chargedPercentage >= 100)
        {
            DisCharge();
        }
    }

    private void DisCharge()
    {
        Collider[] entitiesInRadius = Physics.OverlapSphere(transform.position, 10, entityLayer);
        for (int i = 0; i < entitiesInRadius.Length; i++)
        {
            entitiesInRadius[i].GetComponent<EntityBehavior>().ChangeHealth(damage);
        }
        chargeDamageDone = 0;
        CalculateChargedPercentage();
    }
}


