using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject ccsUi;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text proficiencyName;

    [Header("Selection")]
    [SerializeField]public List<AbilitySO> allAbilities;
    [HideInInspector]public AbilitySO selectedAbility;
    [HideInInspector]public ProficiencySO selectedProficiency;


    [Header("Values")]
    [SerializeField, Range(1, 3)] private int difficultyLevelValue;

    private SuccessCheck successCheck;

    private void Awake()
    {
        successCheck = FindObjectOfType<SuccessCheck>();
        SetActive(ccsUi, false);
        UpdateProficiencyPoints();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            ShowCcsUi();
            ToggleSuccessCanvas(other.transform, true);
            UpdateWheelImageFill();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
        {
            HideCcsUi();
            ToggleSuccessCanvas(other.transform, false);
        }
    }

    private void ShowCcsUi()
    {
        SetActive(ccsUi, true);
        UpdateTitleColor();
        UpdateProficiencyPoints();
    }

    private void HideCcsUi()
    {
        SetActive(ccsUi, false);
    }

    private void ToggleSuccessCanvas(Transform playerTransform, bool isActive)
    {
        var successCanvas = playerTransform.Find("SUCCESS_CANVAS");
        if (successCanvas != null)
        {
            successCanvas.gameObject.SetActive(isActive);
        }
    }

    private void UpdateTitleColor()
    {
        title.color = difficultyLevelValue switch
        {
            1 => new Color(0, 0.4f, 0.8f),
            2 => new Color(0.8f, 0.53f, 0),
            3 => new Color(0.8f, 0, 0),
            _ => Color.white
        };
    }

    public void UpdateProficiencyPoints()
    {
        proficiencyName.text = selectedProficiency != null 
            ? selectedProficiency.proficiencyName 
            : "No Proficiency Selected";
    }

    private void SetActive(GameObject obj, bool isActive)
    {
        if (obj != null && obj.activeSelf != isActive)
        {
            obj.SetActive(isActive);
        }
    }

    private bool IsPlayer(Collider other)
    {
        return other.CompareTag("Player");
    }

    private void UpdateWheelImageFill()
    {
        if (successCheck != null && selectedProficiency != null)
        {
            successCheck.wheelImage.fillAmount = selectedProficiency.points / 10f;
        }
    }
}
