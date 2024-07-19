using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Ability", menuName = "Abilities/Ability")]
public class AbilitySO : ScriptableObject
{
    public string abilityName;
    [Range(1, 6)]
    public int points;
    public List<ProficiencySO> proficiencies;
}
