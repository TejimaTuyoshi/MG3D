using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField]int score;
    int damageCount = 0;
    float clearTime = 0f;
    bool ischange = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ischange) { text.text = $"スコア:{score},DamageCount:{damageCount}\nTime:{Math.Floor(clearTime)}s"; }
        else
        {
            clearTime += Time.deltaTime;
            text.text = $"スコア:{score}"; 
        }   
    }

    public void Plus()
    {
        score += 5;
    }
    public void QuickPlus()
    {
        score += 10;
    }
    public void ShootPlus()
    {
        score += 20;
    }
    public void damagePlus()
    {
        score -= 5;
        damageCount++;
    }
}
