using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class estate
{
    public bool isBuy;
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

    public int leaderPenguinLevel;
    public int[] PenguinLevel = new int[5];

    public List<estate> dataSturctures = new List<estate>();

    public List<JasanData> jasanDatas = new List<JasanData>();

    public List<JusikData> Jusik = new List<JusikData>();

}
public class ShopManager : MonoBehaviour
{
    private void Start()
    {
        string fileName = "SaveData";
        string Path = Application.persistentDataPath + "/" + fileName + ".Json";
        FileInfo file = new FileInfo(Path);
        if (file == null) return;
        string json = File.ReadAllText(Path);

        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        GameManager.Instance.Coin = saveData.Coin;
        //GameManager.Instance.ClickCoinUp = saveData.ClickCoin;
        //GameManager.Instance.secCoinup = saveData.SecCoin;

        FindObjectOfType<LeaderPenguin>().Level = saveData.leaderPenguinLevel;

        var penguins = FindObjectsOfType<Jobbutton>();
        foreach (var penguin in penguins)
        {
            penguin.Level = saveData.PenguinLevel[penguin.Penguinidx];
            if (penguin.Level > 0)
            {
                penguin.Buy = true;
            }
        }

        var Structures = FindObjectsOfType<Realestate>();
        int count = 0;
        foreach (var Structure in Structures)
        {
            estate obj = saveData.dataSturctures.Find(x => x.Name == Structure.ItemName);
            Structure.ItemName = obj.Name;
            Structure.Buy = obj.isBuy;
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

        saveData.ClickCoin = GameManager.Instance.ClickCoinUp;
        saveData.Coin = GameManager.Instance.Coin;
        saveData.SecCoin = GameManager.Instance.secCoinup;

        saveData.leaderPenguinLevel = FindObjectOfType<LeaderPenguin>().Level;

        var penguins = FindObjectsOfType<Jobbutton>();
        foreach (var penguin in penguins)
            saveData.PenguinLevel[penguin.Penguinidx] = penguin.Level;

        var Structures = FindObjectsOfType<Realestate>();
        foreach (var Structure in Structures)
        {
            estate estate = new estate();
            estate.Name = Structure.ItemName;
            estate.isBuy = Structure.Buy;
            saveData.dataSturctures.Add(estate);
        }

        var Jasans = FindObjectsOfType<JasanText>();
        foreach (JasanText jasan in Jasans)
        {
            JasanData jasann = new JasanData();
            jasann.Name = jasan.ItemName;
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

        string json = JsonUtility.ToJson(saveData);
        string fileName = "SaveData";
        string Path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(Path, json);
    }
}
