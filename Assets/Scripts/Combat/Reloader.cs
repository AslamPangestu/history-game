using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloader : MonoBehaviour {

    [SerializeField] int maxAmmo;
    [SerializeField] float reloadeTime;
    [SerializeField] int clipSize;

    int ammo;
    public int shootFiredInClip;
    bool isReloading;

    public int BulletRemainingInClip
    {
        get
        {
            return clipSize - shootFiredInClip;
        }
    }

    public bool IsReloading
    {
        get
        {
            return isReloading;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reload()
    {
        if (isReloading)
        {
            return;
        }
        isReloading = true;
        print("Start Reload");
        GamesManager.Instance.Timer.Add(ExecuteReload, reloadeTime);
    }

    private void ExecuteReload()
    {
        print("Reloading");
        isReloading = false;
        ammo -= shootFiredInClip;
        shootFiredInClip = 0;

        if (ammo < 0)
        {
            ammo = 0;
            shootFiredInClip += -ammo;
        }
    }

    public void TakeFromClip(int amount)
    {
        shootFiredInClip += amount;
    }
}
