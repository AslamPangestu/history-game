using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float vertical;
    public float horizontal;
    public Vector2 mouseInput;
    public bool fire;
    public bool reload;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X")
            , Input.GetAxisRaw("Mouse Y"));
        fire = Input.GetButton("Fire1");
        reload = Input.GetKey(KeyCode.R);
    }
}
