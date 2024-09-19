using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField]int score;
    // Start is called before the first frame update
    void Start()
    {
        text.text = $"�X�R�A:{score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plus()
    {
        score += 10;
        text.text = $"�X�R�A:{score}";
    }
}
