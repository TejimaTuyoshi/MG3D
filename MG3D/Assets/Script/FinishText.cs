using System;
using UnityEngine;
using UnityEngine.UI;


public class FinishText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField]ScoreText scoreText;
    void Update()
    { 
        text.text = $"DamageCount:{scoreText.dc}\r\ntime:{scoreText.ct}";
    }

}
