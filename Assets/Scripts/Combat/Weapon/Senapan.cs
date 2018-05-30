using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senapan : Shooter {

    public override void Fire()
    {
        base.Fire();
        if (canFire)
        {
            print("shoot");
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GamesManager.Instance.InputController.reload)
        {
            Reload();
        }
	}
}
