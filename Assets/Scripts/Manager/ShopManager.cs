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
    public int[] PenguinLevel = new int[3];

    public estate[] dataSturctures = new estate[10];

    //public estate roofTop;
    //public estate halfUnder;
    //public estate officetell;
    //public estate multiLiveHouse;
    //public estate SingleLiveHouse;
    //public estate apart50;
    //public estate Buliding10;
    //public estate Buliding30;
    //public estate Buliding50;
    //public estate Hotel;

    public JusikData[] Jusik = new JusikData[5];

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

        var penguins = FindObjectsOfType<Jobbutton>();
        foreach (var penguin in penguins)
            saveData.PenguinLevel[penguin.Penguinidx] = penguin.Level;

        var Structures = FindObjectsOfType<Realestate>();
        int count = 0;
        foreach (var Structure in Structures)
        {
            saveData.dataSturctures[count].Name = Structure.ItemName;
            saveData.dataSturctures[count].isBuy = Structure.Buy;
            count++;
        }

    }
    private void OnApplicationQuit()
    {

    }
}
