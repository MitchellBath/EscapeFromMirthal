using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Goal : MonoBehaviour
{

    public float rotspeed = 1.0f;
    public float frequency = 1f;
    public float amplitude = 0.5f;
    Vector3 oldvec;

    // Start is called before the first frame update
    void Start()
    {
        oldvec = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newvec = oldvec;
        newvec.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = newvec;
    }
}
