using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void front()
    {
        transform.position += transform.TransformDirection(Vector3.up) * 0.5f;
        transform.position += transform.TransformDirection(Vector3.forward) * 0.5f;
    }
    public void back()
    {
        transform.position += transform.TransformDirection(Vector3.up) * 0.5f;
        transform.position += transform.TransformDirection(Vector3.back) * 0.5f;
    }
    public void Right()
    {
        transform.position += transform.TransformDirection(Vector3.up) * 0.5f;
        transform.position += transform.TransformDirection(Vector3.right) * 0.5f;
    }
    public void Left()
    {
        transform.position += transform.TransformDirection(Vector3.up) * 0.5f;
        transform.position += transform.TransformDirection(Vector3.left) * 0.5f;
    }
}
