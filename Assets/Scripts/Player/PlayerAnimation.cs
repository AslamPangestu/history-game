using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Vertical", GamesManager.Instance.InputController.vertical);
	}
}
