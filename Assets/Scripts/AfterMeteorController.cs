using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterMeteorController : MonoBehaviour {

    public float timer;
    private float time;

    // Use this for initialization
    void Start () {
        time = timer;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Destroy(gameObject);
            time = timer;
        }
	}
}
