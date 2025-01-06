using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    Player player;
    WolrdTime wolrdTime;
    [SerializeField] GameObject _finishPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.Finish();
            wolrdTime.Stop();
            _finishPanel.SetActive(true);
        }
    }
}
