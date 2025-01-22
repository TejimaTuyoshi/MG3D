using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signboard : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Animator animator;
    WolrdTime wolrdTime;

    void Start()
    {
        wolrdTime = GameObject.FindObjectOfType<WolrdTime>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            wolrdTime.Stop();
            panel.SetActive(true);
            animator.SetBool("Open",true);
            animator.SetBool("Close", false);
        }
    }
}
