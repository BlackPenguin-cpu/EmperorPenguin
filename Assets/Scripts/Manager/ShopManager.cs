using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;


[System.Serializable]
public class estate
{
    public bool isBuy;
    public long value;
    public string Name;
}
[System.Serializable]
public class JusikData
{
    public int Count;
    public long Value;
    public string Name;
}
[System.Serializable]
public class JasanData
{
    public bool isBuy;
    public string Name;
}
[System.Serializable]
public class SaveData
{
    public long Coin;
    public long ClickCoin;
    public long SecCoin;
    public string dateTime;

    public int leaderPenguinLevel;
    public int[] PenguinLevel = new int[10];

    public List<estate> dataSturctures = new List<estate>();

    public List<JasanData> jasanDatas = new List<JasanData>();

    public List<JusikData> Jusik = new List<JusikData>();

}
public class ShopManager : MonoBehaviour
{
    string fileName = "SaveData";
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("onSave4")) return;
        
        if (!Directory.Exists(Application.persistentDataPath))
            Directory.CreateDirectory(Application.persistentDataPath);

        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        FileInfo file = new FileInfo(path);
        if (file == null) return;
        //string json = File.ReadAllText(path);
        string json = PlayerPrefs.GetString("SaveData");
        if (json == null) return;
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        GameManager.Instance.ClickCoinUp = saveData.ClickCoin;
        GameManager.Instance.Coin = saveData.Coin;
        GameManager.Instance.secCoinup = saveData.SecCoin;
        GameManager.Instance.beforeDateTime = DateTime.ParseExact(saveData.dateTime, "yyyyMMddHHmmss"
            ,System.Globalization.CultureInfo.InvariantCulture);

        FindObjectOfType<LeaderPenguin>().level = saveData.leaderPenguinLevel;

        Jobbutton[] penguins = FindObjectsOfType<Jobbutton>();
        foreach (var penguin in penguins)
        {
            if (penguin.penguinidx < saveData.PenguinLevel.Length)
                penguin.level = saveData.PenguinLevel[penguin.penguinidx];
            if (penguin.level > 0)
                penguin.isBuy = true;
        }

        var Structures = FindObjectsOfType<Realestate>();
        foreach (var Structure in Structures)
        {
            estate obj = saveData.dataSturctures.Find(x => x.Name == Structure.itemName);
            Structure.itemName = obj.Name;
            Structure.realMoney = obj.value;
            Structure.Buy = obj.isBuy;
        }
        var Jasans = FindObjectsOfType<JasanText>();
        foreach (JasanText jasan in Jasans)
        {
            JasanData jasanData = saveData.jasanDatas.Find(x => x.Name == jasan.itemName);
            jasan.itemName = jasanData.Name;
            jasan.Buy = jasanData.isBuy;
        }

        var Jusiks = FindObjectsOfType<Jusik>();
        foreach (var juiisk in Jusiks)
        {
            JusikData jusikdata = saveData.Jusik.Find(x => x.Name == juiisk.ItemName);
            juiisk.ItemName = jusikdata.Name;
            juiisk.nowValue = jusikdata.Value;
            juiisk.Count = jusikdata.Count;
        }
    }
    private void Update()
    {
        SaveData saveData = new SaveData();

        saveData.ClickCoin = GameManager.Instance.ClickCoinUp;
        saveData.Coin = GameManager.Instance.Coin;
        saveData.SecCoin = GameManager.Instance.secCoinup;
        saveData.dateTime = GameManager.Instance.dateTime.ToString("yyyyMMddHHmmss");

        saveData.leaderPenguinLevel = FindObjectOfType<LeaderPenguin>().level;

        var penguins = FindObjectsOfType<Jobbutton>();
        foreach (var penguin in penguins)
            saveData.PenguinLevel[penguin.penguinidx] = penguin.level;

        var Structures = FindObjectsOfType<Realestate>();
        foreach (var Structure in Structures)
        {
            estate estate = new estate();
            estate.value = Structure.realMoney;
            estate.Name = Structure.itemName;
            estate.isBuy = Structure.Buy;
            saveData.dataSturctures.Add(estate);
        }

        var Jasans = FindObjectsOfType<JasanText>();
        foreach (JasanText jasan in Jasans)
        {
            JasanData jasann = new JasanData();
            jasann.Name = jasan.itemName;
            jasann.isBuy = jasan.Buy;

            saveData.jasanDatas.Add(jasann);
        }

        var Jusiks = FindObjectsOfType<Jusik>();
        foreach (var juiisk in Jusiks)
        {
            JusikData data = new JusikData();
            data.Name = juiisk.ItemName;
            data.Value = juiisk.nowValue;
            data.Count = juiisk.Count;

            saveData.Jusik.Add(data);
        }

        if (!Directory.Exists(Application.persistentDataPath + "/Save"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Save");


        string json = JsonUtility.ToJson(saveData);
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        //File.WriteAllText(path, json);

        PlayerPrefs.SetString("SaveData", json);
        PlayerPrefs.SetInt("onSave4", 1);
        PlayerPrefs.Save();
    }
}
