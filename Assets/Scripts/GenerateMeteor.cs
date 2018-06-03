using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMeteor : MonoBehaviour {

    public GameObject meteor;
    public StartConfig config;

    public bool generate;

    public float time;
    private float timer;

    private void Start()
    {
        time = config.time;
        timer = time;
    }

    void Update() {
        if (generate)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                meteor.transform.position = new Vector3(randomRadius(15, 6), randomRadius(15, 6), randomRadius(15, 6));
                Instantiate(meteor);
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
}
