using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InteractableTrigger))]
public class AbilityProficiencyDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InteractableTrigger interactableTrigger = (InteractableTrigger)target;

        if (interactableTrigger.allAbilities == null || interactableTrigger.allAbilities.Count == 0)
        {
            EditorGUILayout.HelpBox("No abilities found. Please assign the 'allAbilities' field.", MessageType.Warning);
            return;
        }

        // Ability Selection
        string[] abilityNames = new string[interactableTrigger.allAbilities.Count];
        for (int i = 0; i < interactableTrigger.allAbilities.Count; i++)
        {
            abilityNames[i] = interactableTrigger.allAbilities[i].abilityName;
        }

        int selectedAbilityIndex = -1;
        if (interactableTrigger.selectedAbility != null)
        {
            selectedAbilityIndex = interactableTrigger.allAbilities.IndexOf(interactableTrigger.selectedAbility);
        }

        selectedAbilityIndex = EditorGUILayout.Popup("Selected Ability", selectedAbilityIndex, abilityNames);
        if (selectedAbilityIndex >= 0)
        {
            interactableTrigger.selectedAbility = interactableTrigger.allAbilities[selectedAbilityIndex];
        }

        // Proficiency Selection
        if (interactableTrigger.selectedAbility != null)
        {
            string[] proficiencyNames = new string[interactableTrigger.selectedAbility.proficiencies.Count];
            for (int i = 0; i < interactableTrigger.selectedAbility.proficiencies.Count; i++)
            {
                proficiencyNames[i] = interactableTrigger.selectedAbility.proficiencies[i].proficiencyName;
            }

            int selectedProficiencyIndex = -1;
            if (interactableTrigger.selectedProficiency != null)
            {
                selectedProficiencyIndex = interactableTrigger.selectedAbility.proficiencies.IndexOf(interactableTrigger.selectedProficiency);
            }

            selectedProficiencyIndex = EditorGUILayout.Popup("Selected Proficiency", selectedProficiencyIndex, proficiencyNames);
            if (selectedProficiencyIndex >= 0)
            {
                interactableTrigger.selectedProficiency = interactableTrigger.selectedAbility.proficiencies[selectedProficiencyIndex];
            }
        }

        serializedObject.ApplyModifiedProperties();

        // Ensure proficiency points are updated when selection changes
        if (GUI.changed)
        {
            interactableTrigger.UpdateProficiencyPoints();
        }
    }
}
