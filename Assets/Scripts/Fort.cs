using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour
{
    public float health = 100f;
    
    public void takeDamage(float damage)
    {
        if( health <= damage )
        {
            Destroy( gameObject );
        }
        else
        {
            health -= damage;
        }
    }

    public float getHealth() {
        return health;
	}

}
