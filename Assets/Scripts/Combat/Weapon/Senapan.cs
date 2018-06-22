using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senapan : Shooter {

    public override void Shoot()
    {
        base.Shoot();
        if (canFire)
        {
            print("shoot");
        }
    }

    void Update()
    {
        if (GamesManager.Instance.InputController.reload)
        {
            Reload();
        }
    }
}
