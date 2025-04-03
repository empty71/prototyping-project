using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damager : MonoBehaviour
{

    public Rigidbody rigidbody;
    public Damageable damageable;
    public float minDamageVelocity;

    public float damage;
    public void Damage(Damageable damageable) => damageable.Damage(damage);
}
