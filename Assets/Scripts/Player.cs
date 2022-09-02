using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward, strafe, vertical;
    public float forwardSpeed, strafeSpeed, forwardRunSpeed;
    float gravity, jumpSpeed;
    public float timeToMaxHeight = 0.5f;
    public float distanceInteraction = 3;

    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        gravity = (-2) / (timeToMaxHeight * timeToMaxHeight);
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
        RayCastInteraction();
    }
    void RayCastInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanceInteraction))
        {
            if (hit.collider.CompareTag("Interact") && Input.GetButtonDown("Fire1"))
            {
                hit.collider.SendMessage("Interaction", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    void Controls()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Fire3"))
        {
            forward = forwardInput * forwardRunSpeed * transform.forward;
        } else
        {
            forward = forwardInput * forwardSpeed * transform.forward;
        }
        
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }


        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }
}
