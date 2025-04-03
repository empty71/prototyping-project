using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public float maxHealth;

    public UnityEvent OnDie;

    private float currentHealth;
    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float Damage)
    {
        currentHealth -= Damage;

        if(currentHealth<= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDie.Invoke();
    }
   
}
