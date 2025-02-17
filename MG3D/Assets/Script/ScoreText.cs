using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] int score;
    [SerializeField] float clearTime;
    [SerializeField] int damageCount;
    bool damage = false;

    public int field;
    public float ct;
    public int dc;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (damage)
        {
            damageCount++;
            damage = false;
        }
        clearTime += Time.deltaTime;
        text.text = $"ÉXÉRÉA:{score}";
        field = score;
        ct = clearTime;
        dc = damageCount;
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
    public void DamagePlus(){ damage = true; }
}
