using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Outlaw : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;

    void Start()
    {

        GameObject castle = GameObject.FindGameObjectWithTag( "Destination" );
        if( castle )
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
    }

	private void OnMouseOver()
	{
        Debug.Log(health );
	}

	void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Destination") )
        {
            Fort fort = other.GetComponentInChildren<Fort>();
            fort.takeDamage( 2f );

            Health health = other.GetComponentInChildren<Health>();
            if( health )
            {
                health.setHealth( fort.health );
                Destroy( gameObject );
            }

        }
    }

    public void takeDamage(float damage) 
    {
        if(health <= damage) 
        {
            Destroy( gameObject );
            GameManager.money += 50f;
		} 
        else 
        {
            health -= damage;
        }
	}
   

}
