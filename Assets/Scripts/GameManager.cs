using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static float money = 500;
    // Start is called before the first frame update
    public static GameManager instance;
    public UiManager uiManager;

    public GameObject[] TowerPrefabs;
    public static GameObject selectedTower;

    public enum TowerType { Cannon, Sniper };

    private void Awake()
	{
        instance = this;
	}
	void Start()
    {
        selectedTower = TowerPrefabs[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSniperTower() {
        selectedTower = TowerPrefabs[1];
    }

    public void SetCannonTower()
    {
        selectedTower = TowerPrefabs[0];
    }

    public static bool BuyTower(float price) {
    if(money-price >= 0) {
            money -= price;
            UiManager.ShowBankInfo(true);
            return true;
	} else {
            UiManager.ShowBankInfo( false );
            return false;
	}
	}
}
