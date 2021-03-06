﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMeteor : MonoBehaviour {

    public GameObject meteor;
    public StartConfig config;
    public List <Transform> placesOfGenerateMeteor;

    private bool generate;

    public float time;
    private float timer;

    private void Start()
    {
        time = config.time;
        timer = time;
        generate = true;
    }

    void Update() {
        if (generate)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                meteor.transform.position = new Vector3(randomRadius(35, 15), randomRadius(35, 15), randomRadius(35, 15));
                Instantiate(meteor);
                foreach (Transform place in placesOfGenerateMeteor)
                {
                    Instantiate(meteor, place.position, Quaternion.identity);
                }
                if (time > 1)
                    time -= 0.0001f;
                timer = time;
            }
        }
    }


    float randomRadius(float radiusOfGenerate, float excludingRadius)
    {
        float result = Random.Range(-radiusOfGenerate, radiusOfGenerate);
        if (Mathf.Abs(result) <= excludingRadius) {
            if (result < 0)
                result -= excludingRadius;
            else
                result += excludingRadius;
        }
        return result;
    }

    public bool getGenerate()
    {
        return generate;
    }

    public void SetGenerate(bool value)
    {
        generate = value;
    }
}
