using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [Header("Player Info")]
    public string playerName;
    public PlayerClass playerClass;
    public PlayerOccupation occupation;

    [Header("Abilities")]
    public List<AbilitySO> abilities;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //LoadPlayerData();
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetString("PlayerClass", playerClass.ToString());
        PlayerPrefs.SetString("Occupation", occupation.ToString());

        foreach (var ability in abilities)
        {
            PlayerPrefs.SetInt(ability.abilityName, ability.points);

            foreach (var proficiency in ability.proficiencies)
            {
                PlayerPrefs.SetInt(ability.abilityName + "_" + proficiency.proficiencyName, proficiency.points);
            }
        }

        PlayerPrefs.Save();
    }

    public void LoadPlayerData()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "DefaultName");
        playerClass = (PlayerClass)System.Enum.Parse(typeof(PlayerClass), PlayerPrefs.GetString("PlayerClass", "GUNNER"));
        occupation = (PlayerOccupation)System.Enum.Parse(typeof(PlayerOccupation), PlayerPrefs.GetString("Occupation", "Adventurer"));

        foreach (var ability in abilities)
        {
            ability.points = PlayerPrefs.GetInt(ability.abilityName, 0);

            foreach (var proficiency in ability.proficiencies)
            {
                proficiency.points = PlayerPrefs.GetInt(ability.abilityName + "_" + proficiency.proficiencyName, 0);
            }
        }
    }
}
