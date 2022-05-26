using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public Transform target;
   
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
            targetHit.takeDamage( 10f );

            HealthBar health = other.GetComponentInChildren<HealthBar>();
            if( health )
            {
                health.setHealth(targetHit.health);
                Destroy( gameObject );
            }

        }

        
    }
}
