using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

    public float MinDistance = 1.0f, MaxDistance = 4.0f;

    public float Smooth = 10.0f;

    Vector3 DollyDirection;

    public Vector3 DollyDirectionAdjusted;

    public float Distance;

    private void Awake()
    {
        DollyDirection = transform.localPosition.normalized;
        Distance = transform.localPosition.magnitude;
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 DesiredCameraPosition = transform.parent.
            TransformPoint(DollyDirection * MaxDistance);
        RaycastHit Hit;
        if(Physics.Linecast(transform.parent.position,DesiredCameraPosition,out Hit))
        {
            Distance = Mathf.Clamp(Hit.distance*0.85f, MinDistance, MaxDistance);
        }
        else
        {
            Distance = MaxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, 
            DollyDirection * Distance, 
            Time.deltaTime * Smooth);
	}
}
