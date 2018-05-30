using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] float rateOfFire;
    [SerializeField] Transform bullet;

    [HideInInspector]
    public Transform muzzle;

    float nextFireAllowed;//maksimal player bisa menembak lagi
    public bool canFire;

    private Reloader reloader;

    private void Awake()
    {
        muzzle = transform.Find("Muzzle");
        reloader = GetComponent<Reloader>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Fire()
    {
        canFire = false;

        if(Time.time < nextFireAllowed)
        {
            return;
        }

        if(reloader != null)
        {
            if (reloader.IsReloading)
            {
                return;
            }
            if(reloader.BulletRemainingInClip == 0)
            {
                return;
            }
            reloader.TakeFromClip(1);
        }

        nextFireAllowed = Time.time + rateOfFire;
        //instaniante the bullet
        Instantiate(bullet, muzzle.position, muzzle.rotation);
        canFire = true;
    }

    public void Reload()
    {
        if(reloader == null)
        {
            return;
        }
        reloader.Reload();
    }
}
