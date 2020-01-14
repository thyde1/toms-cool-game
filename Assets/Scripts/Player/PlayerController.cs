using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera Camera;
    public float MoveSpeed = 5;
    public float JumpStrength = 5;
    public float Gravity = 9.81f;
    public float MouseSensitivity = 1;
    public GameObject[] Weapons;

    private float yVelocity = 0;
    private float cameraAngle = 0;
    private GameObject currentWeapon;

    private void Start()
    {
        var weaponPosition = this.GetComponentInChildren<WeaponPosition>().transform;
        var initialWeapon = Instantiate(this.Weapons.First());
        initialWeapon.transform.SetParent(weaponPosition, false);
        var weaponCameraPosition = initialWeapon.GetComponentInChildren<WeaponCameraPosition>().transform;
        this.Camera.transform.SetParent(weaponCameraPosition, false);
        this.currentWeapon = initialWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        this.MovePlayer();
        this.HandleWeaponInput();
        this.MoveCamera();
    }

    private void MovePlayer()
    {
        var mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        this.transform.Rotate(Vector3.up, mouseX);
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        var characterController = this.gameObject.GetComponent<CharacterController>();
        var jumpPressed = Input.GetButtonDown("Jump");
        var jumping = jumpPressed && characterController.isGrounded;
        if (jumping)
        {
            this.yVelocity = JumpStrength;
        }
        else
        {
            this.yVelocity -= Gravity * Time.deltaTime;
        }
        var horizontalPlaneMovement = this.gameObject.transform.TransformDirection(horizontalInput * MoveSpeed * Time.deltaTime, 0, verticalInput * MoveSpeed * Time.deltaTime);
        characterController.Move(horizontalPlaneMovement + new Vector3(0, this.yVelocity, 0) * Time.deltaTime);
    }

    private void HandleWeaponInput()
    {
        if (Input.GetMouseButton(0))
        {
            this.currentWeapon.GetComponentInChildren<WeaponBehaviour>().Fire();
        }
    }

    private void MoveCamera()
    {
        var mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;
        var newRotation = Mathf.Clamp(this.cameraAngle - mouseY, -90, 90);
        this.Camera.transform.RotateAround(this.transform.position, this.transform.TransformVector(Vector3.right), newRotation - cameraAngle);
        this.cameraAngle = newRotation;
    }
}
