using System;
using UnityEngine;



public class DamageableBehaviour : MonoBehaviour
{

    public Damageable configuration;

    public bool isDead
    {
        get { return configuration.isDead; }
    }


   

    protected virtual void Awake()
    {
        configuration.Init();
    }


    protected virtual void Kill()
    {
        configuration.TakeDamage(configuration.currentHealth);
    }

    public virtual void Remove()
    {
        configuration.SetHealth(0);
        
    }




}
