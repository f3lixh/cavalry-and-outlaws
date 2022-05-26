using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public TMP_Text money;
    public TMP_Text outlawInfo;
    public GameObject Credits;
    public bool isCreditsActive = false;
    
    public GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        outlawInfo.text = OutlawSpawner.outlawsAlive + " Outlaws Alive!" + "\n" + "Current Wave: " + OutlawSpawner.currentWave + "/" + OutlawSpawner.maxWave;
        money.text = "$" + GameManager.money;
        if( OutlawSpawner.isWon ) money.text = "YOU WON";
    }

    public void ToggleCredits()
    {
        Credits.SetActive( !isCreditsActive );
        isCreditsActive = !isCreditsActive;
    }

    public static void ShowBankInfo(bool canAfford) 
    {
        
        if(canAfford) {
            GameObject.Find( "BankInfo" ).GetComponent<TMP_Text>().text = "";
		} else {
            GameObject.Find( "BankInfo" ).GetComponent<TMP_Text>().text = "not enough money";
        }
	}
}
