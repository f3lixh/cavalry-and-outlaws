using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public TMP_Text money;
    
    public GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "$" + GameManager.money;
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
