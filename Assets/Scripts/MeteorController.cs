using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

    public float time;

    private float timer;
    public bool destroy;

	// Use this for initialization
	void Start () {
        timer = time;
	}
	
	// Update is called once per frame
	void Update () {
        if (destroy)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.name == "Planet")
        {
            destroy = true;
        }
    }
}
