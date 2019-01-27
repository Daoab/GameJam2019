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
    float lastMouseX, lastMouseY;
    public float sensitivity = 15.0f;
    float rotationX = 0;
    float rotationY = 0;

    void Start()
    {
        Cursor.visible = false;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        lastMouseX = 0;
        lastMouseY = 0;
        movePlayer();
        rotatePlayer();
    }

    void movePlayer()
    {
        xThrow = Input.GetAxisRaw("Horizontal");
        yThrow = Input.GetAxisRaw("Vertical");

        Vector3 forwardMovement = calculateForwardMovement();
        float auxY = rigidBody.velocity.y;
        rigidBody.velocity = ((xThrow * transform.right).normalized + forwardMovement.normalized) * movementSpeed;
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, auxY, rigidBody.velocity.z);
    }

    Vector3 calculateForwardMovement()
    {
        RaycastHit hit;
        Vector3 planeNormal = Vector3.zero;

        int mask = LayerMask.GetMask("Default");

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1, mask))
        {
            planeNormal = hit.normal;
        }

        Vector3 forwardMovement = Vector3.ProjectOnPlane((yThrow * transform.forward), planeNormal);
        return forwardMovement;
    }

    void rotatePlayer()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX += mouseX - lastMouseX;
        rotationY -= mouseY - lastMouseY;
        rotationY = Mathf.Clamp(rotationY, -75, 75);

        rigidBody.rotation = Quaternion.Euler(0, rotationX, 0);

        camera.transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);

        lastMouseX = mouseX;
        lastMouseY = mouseY;
    }
}