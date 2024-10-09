using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] Text text;
    int count = 0;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = $"DamageCount:{count}\nTime:{Math.Floor(time)}s";
    }

    public void CountUp() { count++; }
}
