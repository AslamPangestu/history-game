using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour {

    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;//kecepatan kamera mengikuti player

    Transform cameraTarget;
    Player localPlayer;

    private void Awake()
    {
        GamesManager.Instance.OnLocalPlayerJoined 
            += Instance_OnLocalPlayerJoined;
    }

    private void Instance_OnLocalPlayerJoined(Player obj)
    {
        localPlayer = obj;
        cameraTarget = localPlayer.transform.Find("CameraTarget");

        if(cameraTarget == null)
        {
            cameraTarget = localPlayer.transform;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = cameraTarget.position +
            localPlayer.transform.forward * cameraOffset.z +
            localPlayer.transform.up * cameraOffset.y +
            localPlayer.transform.right * cameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(
            cameraTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position,
            targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation,
            targetRotation, damping * Time.deltaTime);
	}
}
