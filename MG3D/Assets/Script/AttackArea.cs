using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    Transform enemy;
    Transform quickenemy;
    Transform shooterenemy;
    Vector3 tpos;

    float tr = Data.range;
    float dot;

    EnemyCount enemycount;
    ScoreText scoreText;
    // Start is called before the first frame update
    void Start()
    {
        tpos = transform.position;
        enemycount = GameObject.FindObjectOfType<EnemyCount>();
        scoreText = GameObject.FindObjectOfType<ScoreText>();
    }

    // Update is called once per frame
    void Update()
    {

        enemy.transform.Find("Enemy(Clone)");
        quickenemy.transform.Find("QuickEnemy(Clone)");
        shooterenemy.transform.Find("ShooterEnemy(Clone)");

        var ef = enemy.forward;
        var qf = quickenemy.forward;
        var sf = shooterenemy.forward;

        if ((enemy.position.x - tpos.x) * (enemy.position.x - tpos.x) + (enemy.position.z - tpos.z) * (enemy.position.z - tpos.z) < tr * tr)
        {//Ž‹ŠE”ÍˆÍ“à‚É“ü‚Á‚½ê‡
            dot = Vector3.Dot(ef, (tpos - enemy.position).normalized);
            if (Data.cosAlpha < dot)
            {
                enemy.gameObject.SetActive(false);
                scoreText.plus();
                enemycount.Minus();
            }
        }

        if ((quickenemy.position.x - tpos.x) * (quickenemy.position.x - tpos.x) + (quickenemy.position.z - tpos.z) * (quickenemy.position.z - tpos.z) < tr * tr)
        {//Ž‹ŠE”ÍˆÍ“à‚É“ü‚Á‚½ê‡
            dot = Vector3.Dot(qf, (tpos - quickenemy.position).normalized);
            if (Data.cosAlpha < dot)
            {
                quickenemy.gameObject.SetActive(false);
                scoreText.plus();
                enemycount.Minus();
            }
        }

        if ((shooterenemy.position.x - tpos.x) * (shooterenemy.position.x - tpos.x) + (shooterenemy.position.z - tpos.z) * (shooterenemy.position.z - tpos.z) < tr * tr)
        {//Ž‹ŠE”ÍˆÍ“à‚É“ü‚Á‚½ê‡
            dot = Vector3.Dot(sf, (tpos - shooterenemy.position).normalized);
            if (Data.cosAlpha < dot)
            {
                shooterenemy.gameObject.SetActive(false);
                scoreText.plus();
                enemycount.Minus();
            }
        }
    }
}
