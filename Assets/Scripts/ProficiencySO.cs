using UnityEngine;

[CreateAssetMenu(fileName = "New Proficiency", menuName = "Abilities/Proficiency")]
public class ProficiencySO : ScriptableObject
{
    public string proficiencyName;
    [Range(1, 6)]
    public int points;
}
