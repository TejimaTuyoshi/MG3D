using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Player player;

    [SerializeField] Text text;
    [SerializeField] int score;
    [SerializeField] float clearTime;
    [SerializeField] int damageCount;
    bool damage = false;
    bool isjumpBuy = false;
    bool isjumproop = false;

    public int field;
    public float ct;
    public int dc;
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        if (damage)
        {
            damageCount++;
            damage = false;
        }

        if (isjumpBuy)
        {
            player.BuyJump();
            isjumpBuy = false;
        }

        if (score >= 10 && isjumproop == false)
        {
            isjumpBuy = true;
            isjumproop = true;
        }

        clearTime += Time.deltaTime;
        text.text = $"ÉXÉRÉA:{score}";
        field = score;
        ct = clearTime;
        dc = damageCount;
    }

    public void Plus(){ score += 5; }
    public void QuickPlus(){ score += 10; }
    public void ShootPlus(){ score += 20; }
    public void JumpBuy(){ score -= 10; }
    public void DamagePlus(){ damage = true; }
}
