using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolrdTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Go()
    {
        Time.timeScale = 1.0f;
    }

    public void Stop()
    {
        Time.timeScale = 0.0f;
    }
}
