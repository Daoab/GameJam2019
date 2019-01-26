using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class martin_PlayerMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    public Camera camera;

    public float movementSpeed = 10.0f;
    float xThrow, yThrow;

    float mouseX, mouseY;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        movePlayer();
        rotatePlayer();
    }

    void movePlayer()
    {
        rigidBody.velocity = new Vector3(0, 0, 0);

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        Vector3 forwardMovement = Vector3.ProjectOnPlane((yThrow * transform.forward), Vector3.up);

        rigidBody.velocity = ((xThrow * transform.right).normalized + forwardMovement.normalized) * movementSpeed;
    }

    void rotatePlayer()
    {
        mouseX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        mouseY = Camera.main.ScreenToViewportPoint(Input.mousePosition).y;

        float angleX = Mathf.Lerp(-360, 360, mouseX);
        float angleY = Mathf.Lerp(-75, 75, mouseY);

        rigidBody.rotation = Quaternion.Euler(0, angleX, 0);

        camera.transform.rotation = Quaternion.Euler(-angleY, angleX, 0);
    }
}