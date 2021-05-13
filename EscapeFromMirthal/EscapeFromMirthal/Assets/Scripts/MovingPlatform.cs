using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float rotspeed = 1.0f;
    public float frequency = 1f;
    public float amplitude = 0.5f;
    Vector3 oldvec;
    public bool xaxis = true;

    // Start is called before the first frame update
    void Start()
    {
        oldvec = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newvec = oldvec;
        if (xaxis) {
        newvec.x += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        }
        else {
            newvec.z += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        }

        transform.position = newvec;
    }
}
