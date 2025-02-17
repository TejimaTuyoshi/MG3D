using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    WolrdTime wolrdTime;
    [SerializeField] GameObject _finishPanel;
    // Start is called before the first frame update
    void Start()
    {
        wolrdTime = GameObject.FindObjectOfType<WolrdTime>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            wolrdTime.Stop();
            _finishPanel.SetActive(true);
        }
    }
}
