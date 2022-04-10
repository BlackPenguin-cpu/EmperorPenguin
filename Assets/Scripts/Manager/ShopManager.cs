using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class estate
{
    bool isBuy;
    string Name;
}
class JusikData
{
    int Count;
    int Value;
}
public class ShopManager : MonoBehaviour
{
    int leaderPenguinLevel;
    int Penguin1Level;
    int Penguin2Level;
    int Penguin3Level;

    estate roofTop;
    estate halfUnder;
    estate officetell;
    estate multiLiveHouse;
    estate SingleLiveHouse;
    estate apart50;
    estate Buliding10;
    estate Buliding30;
    estate Buliding50;
    estate Hotel;

    JusikData Menity;
    JusikData Youtube;
    JusikData Taslo;
    JusikData Nuntendo;
    JusikData Coin;

    private void Start()
    {
        
    }
    private void OnApplicationQuit()
    {
        
    }
}
