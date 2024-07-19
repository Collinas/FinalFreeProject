using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [Header("Cameras objects")]
    [SerializeField] private CinemachineVirtualCamera rightSideView;
    [SerializeField] private CinemachineVirtualCamera leftSideView;

    [Header("Walls objects")]
    [SerializeField] private GameObject rightSideWalls;
    [SerializeField] private GameObject leftSideWalls;

    [Header("Transition Settings")]
    [SerializeField] private float transitionDuration = 1.0f;

    private bool inTransition;
    [HideInInspector] public bool rightSide = false;
    [HideInInspector] public bool leftSide = true;

    private void Start()
    {
        LeftSideWalls();
        LeftSideCameras();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !inTransition)
        {
            if (rightSideView.gameObject.activeInHierarchy)
            {
                StartCoroutine(TransitionToLeftSide());
            }
            else
            {
                StartCoroutine(TransitionToRightSide());
            }
        }
    }

    private void RightSideCameras()
    {
        rightSideView.gameObject.SetActive(true);
        leftSideView.gameObject.SetActive(false);
    }

    private void LeftSideCameras()
    {
        rightSideView.gameObject.SetActive(false);
        leftSideView.gameObject.SetActive(true);
    }

    private void RightSideWalls()
    {
        rightSideWalls.SetActive(true);
        leftSideWalls.SetActive(false);
    }

    private void LeftSideWalls()
    {
        rightSideWalls.SetActive(false);
        leftSideWalls.SetActive(true);
    }

    private IEnumerator TransitionToRightSide()
    {
        inTransition = true;
        gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        RightSideCameras();
        yield return new WaitForSeconds(transitionDuration);
        RightSideWalls();
        inTransition = false;
        leftSide = false;
        rightSide = true;

    }

    private IEnumerator TransitionToLeftSide()
    {
        inTransition = true;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        LeftSideCameras();
        yield return new WaitForSeconds(transitionDuration);
        LeftSideWalls();
        inTransition = false;
        leftSide = true;
        rightSide = false;
    }
}
