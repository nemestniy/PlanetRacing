using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public StartConfig config;
    public GameObject player;

    private void OnValidate()
    {
        player = GameObject.Find("Player");       
    }

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.position = config.startPositionPlayer;
            var meteors = GameObject.FindGameObjectsWithTag("Meteor");
            foreach (GameObject meteor in meteors)
                Destroy(meteor);
        }
	}
}
