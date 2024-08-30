using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += transform.TransformDirection(Vector3.up) * 0.1f;
        transform.position += transform.TransformDirection(Vector3.forward) * 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
