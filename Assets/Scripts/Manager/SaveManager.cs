using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    class PlayerData
    {
        public long Coin;
        public long ClickCoin;
        public long SecCoin;
    }
    private void OnApplicationQuit()
    {
        PlayerData playerData = new PlayerData();
        playerData.Coin = GameManager.Instance.Coin;
        playerData.ClickCoin = GameManager.Instance.ClickCoinUp;
        playerData.SecCoin = GameManager.Instance.secCoinup;

        string json = JsonUtility.ToJson(playerData);
        string fileName = "PlayerData";
        string Path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(Path, json);
    }
    private void Start()
    {
        string fileName = "PlayerData";
        string Path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json = File.ReadAllText(Path);

        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

        GameManager.Instance.Coin = playerData.Coin;
        GameManager.Instance.ClickCoinUp = GameManager.Instance.ClickCoinUp;
        GameManager.Instance.secCoinup = GameManager.Instance.secCoinup;
    }

}
