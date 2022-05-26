using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public bool Endgame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   IEnumerable GameLoop() 
   {
        while(Endgame == false) 
        {
            yield return null;
        }
   }
}
