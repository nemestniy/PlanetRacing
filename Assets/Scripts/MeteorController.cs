using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

    public float time;
    public StartConfig config;
    public GameObject AfterCollision;

    private float timer;
    public bool destroy;

	// Use this for initialization
	void Start () {
        time = config.timeToDestroy;
        timer = time;
	}
	
	// Update is called once per frame

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.name == "Planet")
        {
            var inst = Instantiate(AfterCollision, transform.position, Quaternion.identity) as GameObject;
            inst.transform.LookAt(GameObject.Find("Planet").transform);
            Destroy(gameObject);
        }
    }
}
