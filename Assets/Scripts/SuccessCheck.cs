using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SuccessCheck : MonoBehaviour
{
    public Image wheelImage;
    public float minRotationSpeed = 100f;
    public float maxRotationSpeed = 500f;
    public float rotationDuration = 2.0f;
    private bool isSpinning = false;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space) && !isSpinning)
        {
            StartCoroutine(SpinWheel());
        }
    }

    private IEnumerator SpinWheel()
    {
        isSpinning = true;
        float elapsed = 0f;
        float initialRotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        float currentRotationSpeed = initialRotationSpeed;

        while (elapsed < rotationDuration)
        {
            elapsed += Time.deltaTime;
            currentRotationSpeed = Mathf.Lerp(initialRotationSpeed, 0, elapsed / rotationDuration);
            wheelImage.transform.Rotate(0, 0, -currentRotationSpeed * Time.deltaTime);
            yield return null;
        }

        CheckSuccess(wheelImage.transform.eulerAngles.z);
        isSpinning = false;
    }

    private void CheckSuccess(float finalRotation)
    {
        float normalizedRotation = finalRotation % 360f;
        float minSuccessAngle = 360f * Mathf.Clamp01(1f - wheelImage.fillAmount);

        if (normalizedRotation >= minSuccessAngle && normalizedRotation <= 360f)
        {
            Debug.Log("Success!");
        }
        else
        {
            Debug.Log("Fail!");
        }
    }
}
