using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _mouseSens = 250f;
    [SerializeField] private float _minCamView = -70f, _maxCamView = 80f;
    [SerializeField] private float _jumpHeight = 3f;

    private CharacterController _charController;
    private Camera _camera;
    private float xRotation = 0f;
    private Vector3 _playerVel;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _camera = Camera.main;

        if (_charController == null)
            Debug.Log("No Character Controller attached to Player");

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        MouseLook();
        Jump();
        Movement();

        //Ground check/Apply Gravity
        if (_charController.isGrounded)
        {
            _playerVel.y = 0;
        }
        else
        {
            _playerVel.y += -9.18f * Time.deltaTime;
            _charController.Move(_playerVel * Time.deltaTime);
        }
    }
    private void MouseLook()
    {
        //get mouse input
        float mouseX = Input.GetAxis("Mouse X") * _mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSens * Time.deltaTime;

        //Rotate camera based on Y input
        xRotation -= mouseY;
        //Clamp camera
        xRotation = Mathf.Clamp(xRotation, _minCamView, _maxCamView);

        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Rotate player based on X input
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _charController.isGrounded)
        {
            _playerVel.y = Mathf.Sqrt(_jumpHeight * -2f * -9.18f);
        }
    }

    private void Movement()
    {
        //Get WASD input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //Move player based on input
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        _charController.Move(movement * Time.deltaTime * _speed);
    }

   
}
