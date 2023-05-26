using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCanon : MonoBehaviour
{
    FireCanon fireCanon;
    public GameObject Barrel;
    public Vector3 canonRotation;

    [Header("Aiming")]
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    [Header("Aim Parameters")]
    public float rotationSpeed;
    public float maxZRotate;
    public float maxYRotate;

    void Awake() 
    {
        fireCanon = GetComponent<FireCanon>();
    }
    void Update()
    {
        if (fireCanon.playerByCanon)
        {
            getAimInput();
            rotateBarrel();
        }
    }

    void rotateBarrel()
{
    // Calculate rotation amounts based on input

    float yRotation = 0f;
    if (left) {yRotation -= rotationSpeed * Time.deltaTime;}
    if (right) {yRotation += rotationSpeed * Time.deltaTime;}

    float zRotation = 0f;
    if (up) {zRotation += rotationSpeed * Time.deltaTime;}
    if (down) {zRotation -= rotationSpeed * Time.deltaTime;}

    canonRotation.x = Barrel.transform.eulerAngles.x;
    if (canonRotation.x > 180) {canonRotation.x -= 360;}
    canonRotation.y = Barrel.transform.eulerAngles.y;
    if (canonRotation.y > 180) {canonRotation.y -= 360;}
    canonRotation.z = Barrel.transform.eulerAngles.z;
    if (canonRotation.z > 180) {canonRotation.z -= 360;}

    /*
    if (canonRotation.z < maxZRotate && canonRotation.z > -maxZRotate)
    {
        Barrel.transform.Rotate(Vector3.up, yRotation);
    }
    if (!(canonRotation.y >= maxYRotate) && (canonRotation.y <= -maxYRotate))
    {
        Barrel.transform.Rotate(Vector3.forward, zRotation);
    }
    */

    Barrel.transform.Rotate(Vector3.up, yRotation);
    Barrel.transform.Rotate(Vector3.forward, zRotation);
}

    void getAimInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {up = true;}
        if (Input.GetKeyDown(KeyCode.DownArrow)) {down = true;}
        if (Input.GetKeyUp(KeyCode.UpArrow)) {up = false;}
        if (Input.GetKeyUp(KeyCode.DownArrow)) {down = false;}
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {left = true;}
        if (Input.GetKeyDown(KeyCode.RightArrow)) {right = true;}
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {left = false;}
        if (Input.GetKeyUp(KeyCode.RightArrow)) {right = false;}
    }
}