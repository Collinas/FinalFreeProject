using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelController : MonoBehaviour
{
    [SerializeField] private GameObject exitUi;

    private CameraController cameraController;

    private void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    private void Start()
    {
        HideExitUi();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && cameraController.rightSide == true)
        {
            ShowExitUi();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
        else if(cameraController.rightSide == false)
        {
            HideExitUi();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HideExitUi();
    }

    private void ShowExitUi()
    {
        exitUi.SetActive(true);
    }

    private void HideExitUi()
    {
        exitUi.SetActive(false);
    }
}
