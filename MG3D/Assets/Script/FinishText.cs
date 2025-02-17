using System;
using UnityEngine;
using UnityEngine.UI;


public class FinishText : MonoBehaviour
{
    [SerializeField] Text text;
    ScoreText scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindObjectOfType<ScoreText>();
    }

    // Update is called once per frame
    void Update()
    { 
        text.text = $"DamageCount:{scoreText.dc}\r\ntime:{scoreText.ct}";
    }

}
