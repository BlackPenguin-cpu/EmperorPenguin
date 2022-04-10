using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class estate
{
    public bool isBuy;
    public string Name;
}
public class JusikData
{
    public int Count;
    public int Value;
}

public class SaveData
{
    public long Coin;
    public long ClickCoin;
    public long SecCoin;

    public int leaderPenguinLevel;
    public int Penguin1Level;
    public int Penguin2Level;
    public int Penguin3Level;

    public estate roofTop;
    public estate halfUnder;
    public estate officetell;
    public estate multiLiveHouse;
    public estate SingleLiveHouse;
    public estate apart50;
    public estate Buliding10;
    public estate Buliding30;
    public estate Buliding50;
    public estate Hotel;

    public JusikData Menity;
    public JusikData Youtube;
    public JusikData Taslo;
    public JusikData Nuntendo;
    public JusikData bitCoin;
}
public class ShopManager : MonoBehaviour
{

    private void Start()
    {
        SaveData saveData = new SaveData();

        saveData.leaderPenguinLevel = FindObjectOfType<LeaderPenguin>().Level;
        saveData.
    }
    private void OnApplicationQuit()
    {
        
    }
}
