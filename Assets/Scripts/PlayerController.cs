using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 movement = GetInputDirection();
        MovePlayer(movement);
    }

    private Vector3 GetInputDirection()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.forward;
        }

        return direction.normalized;
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * playerSpeed * Time.deltaTime);
    }
}
