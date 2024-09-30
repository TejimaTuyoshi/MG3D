using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField]int score;
    // Start is called before the first frame update
    void Start()
    {
        text.text = $"スコア:{score}";
    }

    // Update is called once per frame
    void Update()
    {
        if (score <= 200)
        {

        }
    }

    public void Plus()
    {
        score += 5;
        text.text = $"スコア:{score}";
    }
    public void QuickPlus()
    {
        score += 10;
        text.text = $"スコア:{score}";
    }
    public void ShootPlus()
    {
        score += 20;
        text.text = $"スコア:{score}";
    }
    public void Minus()
    {
        score -= 5;
        text.text = $"スコア:{score}";
    }
}
