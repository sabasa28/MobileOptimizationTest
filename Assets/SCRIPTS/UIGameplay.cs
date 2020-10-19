using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    public Text moneyP1;
    public Text moneyP2;
    public GameObject[] inventoryP1; 
    public GameObject[] inventoryP2;

    private void Start()
    {
        Player[] players = FindObjectsOfType<Player>();
        for (int i = 0; i < players.Length; i++)
        {
            players[i].UpdateUI = UpdateInventory;
        }
    }

    public void UpdateInventory(int playerID, int money, int bolsasAmount)
    {
        UpdateBolsas(bolsasAmount, playerID);
        UpdateMoney(money, playerID);
    }
    void UpdateBolsas(int bolsasAmount, int playerID)
    {
        GameObject[] inv;
        
        if (playerID == 0) inv = inventoryP1;
        else inv = inventoryP2;
        
        for (int i=0; i < inv.Length;i++)
        {
            if (i+1 <= bolsasAmount) inv[i].SetActive(true);
            else inv[i].SetActive(false);
        }
    }
    void UpdateMoney(int money,int playerID)
    {
        if (playerID == 0)
            moneyP1.text = "$" + money.ToString();
        else
            moneyP2.text = "$" + money.ToString();
    }
}
