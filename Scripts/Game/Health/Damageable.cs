﻿using System;
using UnityEngine;


[Serializable]
public class Damageable
{

    public float maxHealth;
    public float currentHealth { protected set; get; }
    [Range(0,1)]
    public float armor;
    public float goldForDeath;
    public float xpForDeath;
    
    public bool isDead
    {
        get { return currentHealth <= 0f; }
    }

    public virtual void Init()
    {
        currentHealth = maxHealth;
    }


    public void SetMaxHealth(float health)
    {
        if (health <= 0)
        {
            return;
        }
        maxHealth = health;
    }


    public void SetHealth(float health)
    {
        if (health <= 0)
        {
            return;
        }
        currentHealth = health;
    }


    public void TakeDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }
        currentHealth -= damage;
    }


    protected void ChangeHealth(float healthIncrement)
    {
        if (healthIncrement <= 0 || currentHealth + healthIncrement > maxHealth)
        {
            return;
        }
        currentHealth += healthIncrement;
    }


}
