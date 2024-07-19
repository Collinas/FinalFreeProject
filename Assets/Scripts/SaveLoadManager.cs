using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{

    public static SaveLoadManager Instance { get; private set; }
    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            filePath = Application.persistentDataPath + "/playerData.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public PlayerData LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found!");
            return null;
        }
    }
}
