using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float timeToLive;
    [SerializeField] float damage;
    // Use this for initialization
    void Start () {
        Destroy(gameObject,timeToLive);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        var destructable = other.transform.GetComponent<Destructable>();
        if(destructable == null)
        {
            return;
        }
        destructable.TakeDamage(damage);
    }
}
