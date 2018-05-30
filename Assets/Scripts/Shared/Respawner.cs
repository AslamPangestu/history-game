using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Despawn(GameObject obj, float inSec)
    {
        obj.SetActive(false);
        GamesManager.Instance.Timer.Add(() =>
        {
            obj.SetActive(true);
        }, inSec);
    }
}
