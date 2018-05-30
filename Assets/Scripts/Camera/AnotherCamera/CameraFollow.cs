using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float CameraSpeed = 120.0f;//speed camera
    public GameObject CameraFollowObj;//obj yg akan diikuti kamera
    Vector3 FollowPosition;
    public float AngelPoint = 80.0f;//posisi camera
    public float InputSensivity = 150.0f;

    public GameObject CameraObj, PlayerObject;

    public float DisCamXToPlayer, DisCamYToPlayer, DisCamZToPlayer;

    public float MouseX, MouseY;

    //public float FinalInputX, FinalInputZ;

    public float SmoothX, SmoothY;

    private float RotationX = 0.0f, RotationY = 0.0f;
    // Use this for initialization
    void Start () {
        Vector3 Rotation = transform.localRotation.eulerAngles;
        RotationY = Rotation.y;
        RotationX = Rotation.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        //set up rotation
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        RotationY += MouseX * InputSensivity * Time.deltaTime;
        RotationX += MouseY * InputSensivity * Time.deltaTime;

        RotationX = Mathf.Clamp(RotationX, -AngelPoint, AngelPoint);

        Quaternion LocalRotation = Quaternion.Euler(RotationX, RotationY, 0.0f);
        transform.rotation = LocalRotation;
    }

    private void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        //set target
        Transform Target = CameraFollowObj.transform;

        float Step = CameraSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Step);
    }
}
