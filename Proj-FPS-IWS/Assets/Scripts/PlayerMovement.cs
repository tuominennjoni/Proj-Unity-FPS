using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public Camera camerah;
    public float runSpeed;

    public float mouseSensitivity;
    private bool _running;
    private Vector3 eulers;



    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _running = true;
    }

    
    // Update is called once per frame
    
    
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        Mouse mouse = Mouse.current;

        _running = keyboard.shiftKey.isPressed;
        float speed = walkSpeed;
        if(_running) 
        {
            speed = runSpeed;
        }

        float forwardsAmount = 0;
        if (keyboard.wKey.isPressed) 
        {
            forwardsAmount = 1;
        }
        if (keyboard.sKey.isPressed) 
        {
            forwardsAmount = -1;
        }

        float rightAmount = 0;

        if (keyboard.aKey.isPressed) 
        {
            rightAmount = -1;
        }
        if (keyboard.dKey.isPressed) 
        {
            rightAmount = 1;
        }
        

        Vector3 movement = transform.forward * forwardsAmount + transform.right * rightAmount;


        controller.Move(movement * speed * Time.smoothDeltaTime);

        Vector2 dPos = mouse.delta.ReadValue() * mouseSensitivity * Time.smoothDeltaTime;
        float dX = dPos.x;
        float dY = dPos.y;

        eulers[0] = Mathf.Clamp(eulers[0] - dY, -89, 89);
        eulers[1] = (eulers[1] + dX) % 360;

        GetComponent<Camera>().transform.localRotation = Quaternion.Euler(eulers[0], 0, 0);
        transform.rotation = Quaternion.Euler(0, eulers[1], 0);
    }
}
