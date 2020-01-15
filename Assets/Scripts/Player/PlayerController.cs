using System;
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
    private WeaponBehaviour currentWeaponBehaviour;

    private void Start()
    {
        this.PutCameraLevelWithWeaponPosition();
        var initialWeapon = this.Weapons.First();
        this.SetWeapon(initialWeapon);
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
        foreach (var weapon in this.Weapons)
        {
            if (Input.GetKeyDown(weapon.GetComponentInChildren<WeaponBehaviour>().HotKey))
            {
                this.SetWeapon(weapon);
                break;
            }
        }

        if (Input.GetMouseButton(0))
        {
            this.currentWeaponBehaviour.Fire();
        }

        var mouseScrollDelta = Input.mouseScrollDelta.y;
        if (mouseScrollDelta != 0)
        {
            var currentWeaponIndex = Array.FindIndex(this.Weapons, w => w.GetComponentInChildren<WeaponBehaviour>().HotKey == this.currentWeaponBehaviour.HotKey);
            var newWeaponIndex = currentWeaponIndex + Mathf.RoundToInt(Mathf.Clamp(mouseScrollDelta, -1, 1));
            if (newWeaponIndex > this.Weapons.Count() - 1)
            {
                newWeaponIndex = 0;
            }
            else if (newWeaponIndex < 0)
            {
                newWeaponIndex = this.Weapons.Count() - 1;
            }

            this.SetWeapon(this.Weapons[newWeaponIndex]);
        }
    }

    private void SetWeapon(GameObject weapon)
    {
        var weaponPosition = this.GetComponentInChildren<WeaponPosition>().transform;
        var weaponInstance = Instantiate(weapon);
        weaponInstance.transform.SetParent(weaponPosition, false);
        if (this.currentWeapon != null)
        {
            Destroy(this.currentWeapon);
        }

        this.currentWeapon = weaponInstance;
        this.currentWeaponBehaviour = weaponInstance.GetComponentInChildren<WeaponBehaviour>();
    }

    private void MoveCamera()
    {
        var mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;
        var newRotation = Mathf.Clamp(this.cameraAngle - mouseY, -90, 90);
        this.Camera.transform.RotateAround(this.transform.position, this.transform.TransformVector(Vector3.right), newRotation - cameraAngle);
        this.cameraAngle = newRotation;
    }

    private void PutCameraLevelWithWeaponPosition()
    {
        var initialCameraPosition = this.Camera.transform.position;
        var newCameraPosition = new Vector3(this.GetComponentInChildren<WeaponPosition>().transform.position.x, initialCameraPosition.y, initialCameraPosition.z);
        this.Camera.transform.SetPositionAndRotation(newCameraPosition, Quaternion.identity);
    }
}
