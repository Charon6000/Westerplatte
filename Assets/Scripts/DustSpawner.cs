using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSpawner : MonoBehaviour
{
    public GameObject pocisk;
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    float timebtw;
    float time;
    private void Start() {
        timebtw = Random.Range(1,5);
        time = timebtw;
    }
    void Update()
    {
        timebtw = Random.Range(1,5);
        if(time <= 0)
        {
        Instantiate(pocisk, new Vector3(Random.Range(xMin, xMax), 1f,Random.Range(yMin, yMax)), Quaternion.identity);
        time = timebtw;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
