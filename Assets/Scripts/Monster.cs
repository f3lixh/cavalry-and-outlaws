using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
	public float Health;
	public float CurrentHealth;
	public float Speed;
	public int ID;
	public void Init()
	{
		Health = CurrentHealth;
	}
}
