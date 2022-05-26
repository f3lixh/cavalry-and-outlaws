using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public TextMesh textMesh;
   // public GameManager gm;
    

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }

    public void setHealth(float health) 
    {
        textMesh.text = health.ToString();

        if(health <= 50 && health >= 25) 
        {
            textMesh.color = new Color( 254f, 254f, 0f );
		}
        else if ( health <= 25 ) 
        {
            textMesh.color = new Color( 254f, 0f, 0f );
        }

	}
}
