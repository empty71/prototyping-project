using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Damageable))]
public class VelocityDamager : Damager
{
    
    [Range(0, 1)] public float velocityThreshold;
    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        damageable = GetComponent<Damageable>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collsion: " + collision.gameObject.name);
        float damageFactor = rigidbody.velocity.magnitude / minDamageVelocity;
        if(damageFactor> velocityThreshold)
        {
         damageable.Damage(damage * damageFactor);
        }      
    }
}
