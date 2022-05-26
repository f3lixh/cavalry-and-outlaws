using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Transform target;
    public float damage = 1f;
   
    void FixedUpdate()
    {
        if( target )
        {
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        }
        else
        {
            Debug.Log( "Hit" );
            Destroy( gameObject );
            return;
        }


    }

    void OnTriggerEnter(Collider other)   
    {
        Outlaw targetHit = other.GetComponentInChildren<Outlaw>();
        if( targetHit )
        {
            targetHit.takeDamage( damage );

            HealthBar health = other.GetComponentInChildren<HealthBar>();
            if( health )
            {
                health.setHealth(targetHit.health);
                Destroy( gameObject );
            }

        }

        
    }
}
