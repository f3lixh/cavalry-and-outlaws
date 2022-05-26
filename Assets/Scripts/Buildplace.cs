using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildplace : MonoBehaviour
{
    public GameObject towerPrefab;
	public enum State { Stateless, Oklahoma, Arkansas, Louisiana, Texas  };
	public State BuildInState; 

	public GameObject selectedTowerPrefab;

	bool isBuild = false;
	//public GameObject tower;




	private void OnMouseDown()
	{
		
		Debug.Log( "Hello There" );
		
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere( transform.position, 8f );
		//Gizmos.DrawWireSphere( transform.position, 5f );
	}

	void Update()
	{
		towerPrefab = GameManager.selectedTower;
	}

	private void OnMouseUpAsButton()
	{

		float defaultTowerPrice = towerPrefab.GetComponent<Tower>().price;

		switch( BuildInState )
		{

			case State.Oklahoma:
				BuildTower( Mathf.Floor( defaultTowerPrice ) );
				break;
			case State.Arkansas:
				BuildTower( Mathf.Floor( defaultTowerPrice * 0.75f ));
				break;
			case State.Louisiana:
				BuildTower( Mathf.Floor( defaultTowerPrice *0.5f) );
				break;
			case State.Texas:
				BuildTower( Mathf.Floor( defaultTowerPrice *2f ));
				break;
			default:
				BuildTower( 0f );
				break;

		}
	}

	public void BuildTower(float price) 
	{


		if( !isBuild )
		{
			if( !GameManager.BuyTower( price ) )
			{

				return;
			}
			GameObject g = Instantiate( towerPrefab );
			g.transform.position = transform.position;// + Vector3.up;
			isBuild = true;
		}
		else
		{
			GameManager.money += 50;
		}
	}

	
}
