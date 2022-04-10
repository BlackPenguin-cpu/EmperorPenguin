using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class estate
{
    public bool isBuy;
    public string Name;
}
public class JusikData
{
    public int Count;
    public long Value;
    public string Name;
}
public class JasanData
{
    public bool isBuy;
    public string Name;
}
public class SaveData
{
    public long Coin;
    public long ClickCoin;
    public long SecCoin;

    public int leaderPenguinLevel;
    public int[] PenguinLevel = new int[3];

    public estate[] dataSturctures = new estate[10];

    public JasanData[] jasanDatas = new JasanData[5];

    public JusikData[] Jusik = new JusikData[5];

}
public class ShopManager : MonoBehaviour
{

    private void Start()
    {
        string fileName = "SaveData";
        string Path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json = File.ReadAllText(Path);

        SaveData saveData = JsonUtility.FromJson<SaveData>(Path);
        if (saveData == null) return;
        GameManager.Instance.Coin = saveData.Coin;
        GameManager.Instance.ClickCoinUp = saveData.ClickCoin;
        GameManager.Instance.secCoinup = saveData.SecCoin;

        FindObjectOfType<LeaderPenguin>().Level = saveData.leaderPenguinLevel;

        var penguins = FindObjectsOfType<Jobbutton>();
        foreach (var penguin in penguins)
            penguin.Level = saveData.PenguinLevel[penguin.Penguinidx];

        var Structures = FindObjectsOfType<Realestate>();
        int count = 0;
        foreach (var Structure in Structures)
        {
            Structure.ItemName = saveData.dataSturctures[count].Name;
            Structure.Buy = saveData.dataSturctures[count].isBuy;
            count++;
        }

        count = 0;
        var Jasans = FindObjectsOfType<JasanText>();
        foreach (JasanText jasan in Jasans)
        {
            jasan.ItemName = saveData.jasanDatas[count].Name;
            jasan.Buy = saveData.jasanDatas[count].isBuy;
            count++;
        }

        var Jusiks = FindObjectsOfType<Jusik>();
        count = 0;
        foreach (var juiisk in Jusiks)
        {
            juiisk.ItemName = saveData.Jusik[count].Name;
            juiisk.nowValue = saveData.Jusik[count].Value;
            juiisk.Count = saveData.Jusik[count].Count;
            count++;
        }
    }
    private void OnApplicationQuit()
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

        count = 0;
        var Jasans = FindObjectsOfType<JasanText>();
        foreach (JasanText jasan in Jasans)
        {
            saveData.jasanDatas[count].Name = jasan.ItemName;
            saveData.jasanDatas[count].isBuy = jasan.Buy;
            count++;
        }

        var Jusiks = FindObjectsOfType<Jusik>();
        count = 0;
        foreach (var juiisk in Jusiks)
        {
            saveData.Jusik[count].Name = juiisk.ItemName;
            saveData.Jusik[count].Value = juiisk.nowValue;
            saveData.Jusik[count].Count = juiisk.Count;
            count++;
        }

        string json = JsonUtility.ToJson(saveData);
        string fileName = "SaveData";
        string Path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(Path, json);
    }
}
