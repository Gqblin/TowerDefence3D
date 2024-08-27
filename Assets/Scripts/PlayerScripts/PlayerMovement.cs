using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7;
    [SerializeField] private float verticalSpeed = 4.5f;
    [SerializeField] private float sprintSpeedMulitplier = 1.5f;

    private float currentSpeed;
    private float currentVerticalSpeed;

    private bool sprinting;

    private void Start()
    {
        currentSpeed = speed;
        currentVerticalSpeed = verticalSpeed;
    }

    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.Translate(movement * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = false;
        }
        if (sprinting)
        {
            currentSpeed = speed * sprintSpeedMulitplier;
        }
        else
        {
            currentSpeed = speed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, currentVerticalSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position += new Vector3(0, -currentVerticalSpeed, 0) * Time.deltaTime;
        }
    }
}
