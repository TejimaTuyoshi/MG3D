using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FallRoads : MonoBehaviour
{
    bool isfall = false;
    bool isback = false;
    float falltime = 0;
    float backtime = 0;
    [SerializeField]float limittime = 3.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (isfall){ falltime += Time.deltaTime; }
        if (isback){ backtime += Time.deltaTime; }

        if (falltime >= limittime) 
        {
            this.gameObject.SetActive(false);
            isfall = false;
            isback = true;
            limittime = 0;
        }

        if (backtime >= limittime)
        {
            this.gameObject.SetActive(true);
            isback = false;
            limittime = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) { isfall = true; }
    }
}
