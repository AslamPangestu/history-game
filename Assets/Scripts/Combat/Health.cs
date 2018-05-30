using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable {

    [SerializeField] float inSec;
    public override void Die()
    {
        base.Die();
        GamesManager.Instance.Respawner.Despawn(gameObject, inSec);
    }

    public override void TakeDamage(float amount)
    {
        print("Remaining : " + HitPointsRemaining);
        base.TakeDamage(amount);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable(){
        Reset();
    }
}
