using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    public int leaderPenguinLevel;
    public int[] PenguinLevel = new int[5];

    public List<estate> dataSturctures = new List<estate>();

    public List<JasanData> jasanDatas = new List<JasanData>();

    public List<JusikData> Jusik = new List<JusikData>();

}
public class ShopManager : MonoBehaviour
{
    private void Awake()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Save"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Save");

        string fileName = "SaveData";
        string Path = Application.persistentDataPath + "/Save/" + fileName + ".Json";
        FileInfo file = new FileInfo(Path);
        if (file == null) return;
        string json = File.ReadAllText(Path);

        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        GameManager.Instance.Coin = saveData.Coin;
        GameManager.Instance.secCoinup = saveData.SecCoin;
        //GameManager.Instance.ClickCoinUp = saveData.ClickCoin;

        FindObjectOfType<LeaderPenguin>().Level = saveData.leaderPenguinLevel;

        var penguins = FindObjectsOfType<Jobbutton>();
        foreach (var penguin in penguins)
        {
            penguin.Level = saveData.PenguinLevel[penguin.Penguinidx];
            if (penguin.Level > 0)
                penguin.Buy = true;
        }

        var Structures = FindObjectsOfType<Realestate>();
        foreach (var Structure in Structures)
        {
            estate obj = saveData.dataSturctures.Find(x => x.Name == Structure.ItemName);
            Structure.ItemName = obj.Name;
            Structure.realMoney = obj.value;
            Structure.Buy = obj.isBuy;
        }
        var Jasans = FindObjectsOfType<JasanText>();
        foreach (JasanText jasan in Jasans)
        {
            JasanData jasanData = saveData.jasanDatas.Find(x => x.Name == jasan.ItemName);
            jasan.ItemName = jasanData.Name;
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
            estate.value = Structure.realMoney;
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

        if (!Directory.Exists(Application.persistentDataPath + "/Save"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Save");


        string json = JsonUtility.ToJson(saveData);
        string fileName = "SaveData";
        FileStream fs = new FileStream(Application.persistentDataPath + "/Save" + fileName + ".Json", FileMode.Create, FileAccess.Write);
        fs.Close();
        string Path = Application.dataPath + "/Save/" + fileName + ".Json";
        File.WriteAllText(Path, fs.ToString());
    }
}
