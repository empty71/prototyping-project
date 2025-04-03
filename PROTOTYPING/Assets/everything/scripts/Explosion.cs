using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Damager
{
    public float radius;


    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
       for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].TryGetComponent(out Damageable damageable))
            {
                Damage(damageable);
            }
        }
    } 


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
