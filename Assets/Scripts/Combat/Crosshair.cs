using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField] Texture2D crosshairImage;
    [SerializeField] int size;
    [SerializeField] float maxAngel;
    [SerializeField] float minAngel;

    float lookHeight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LookHeight(float value)
    {
        lookHeight += value;

        if (lookHeight > maxAngel || lookHeight < minAngel)
        {
            lookHeight -= value;
        }
    }

    void OnGUI()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
        GUI.DrawTexture(new Rect(screenPosition.x,
            screenPosition.y - lookHeight,
            size, size), crosshairImage);
    }
}
