using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform target;
    public Transform muzzle;
  
    public enum TowerType { Cannon, Sniper};
    public TowerType towerType;
    public float price = 50f;

    public float reloadLeft = 0f;

    float reloadTime = 2f;
    public float shootingRange = 10f;

	private void Start()
	{
        //muzzle = GameObject.Find( "Muzzle" ).transform;
	}

	void Update()
    {

        Outlaw[] outlaws = GameObject.FindObjectsOfType<Outlaw>();
        float distance = Mathf.Infinity;

        foreach( Outlaw outlaw in outlaws ) {
            float d = Vector3.Distance( transform.position, outlaw.transform.position );
            if( target == null || d < distance ) {
                target = outlaw.transform;
                distance = d;
            }
        }

        if( target == null )
            return;

        if( towerType == TowerType.Cannon ) {
            Vector3 dir = target.position - transform.position;
            Quaternion aimRotation = Quaternion.LookRotation( dir );
            Vector3 rotation = Quaternion.Lerp( transform.rotation, aimRotation, Time.deltaTime * 10f ).eulerAngles;

            transform.rotation = Quaternion.Euler( 0f, rotation.y, 0f );
        }


        reloadLeft -= Time.deltaTime;

        if( reloadLeft <= 0f ) {
            reloadLeft = reloadTime;
            ShootProjectile();
        } 

    

    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate( projectilePrefab, muzzle.position, muzzle.rotation );
        projectile.GetComponent<Projectile>().target = target;
    }



    void OnTriggerEnter(Collider collider)
    {
    
    
       // target = collider.transform;
        
            
    }

    IEnumerator Shoot(Transform transform) 
    {

       
            while( transform != null )
            {
                GameObject projectile = Instantiate( projectilePrefab, transform.position, transform.rotation );
                projectile.GetComponent<Projectile>().target = target;
                yield return new WaitForSeconds( 20f );
            }
        
	}
        
    

    void OnTriggerExit(Collider collider)
    {
        //target = null;
    }
}
