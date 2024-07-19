[System.Serializable]
public class Ability
{
    public string name;
    public int points;
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public string playerClass;
    public string occupation;
    public int brutalityPoints;
    public Ability[] brutalitySubAbilities;
    public int reflexesPoints;
    public Ability[] reflexesSubAbilities;
}
