using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    Transform enemy;
    Vector3 tpos;

    float tr = Data.range;
    float dot;
    Vector3 pf;

    EnemyCount enemycount;
    QuickEnemyCount quickEnemyCount;
    ShooterEnemyCount shooterEnemyCount;
    [SerializeField]ScoreText scoreText;
    // Start is called before the first frame update
    void Start()
    {
        enemycount = GameObject.FindObjectOfType<EnemyCount>();
        quickEnemyCount = GameObject.FindObjectOfType<QuickEnemyCount>();
        shooterEnemyCount = GameObject.FindObjectOfType<ShooterEnemyCount>();
    }

    // Update is called once per frame
    void Update()
    {
        tpos = GameObject.FindObjectOfType<Player>().gameObject.transform.position;
        pf = GameObject.FindObjectOfType<Player>().gameObject.transform.right;
        Enemy();
        QuickEnemy();
        ShooterEnemy();
    }


    void Enemy()
    {
        var list = GameObject.FindObjectsOfType<Enemy>();
        foreach (var enemy in list)
        {
            
            if ((enemy.transform.position.x - tpos.x) * (enemy.transform.position.x - tpos.x) + (enemy.transform.position.z - tpos.z) * (enemy.transform.position.z - tpos.z) < tr * tr)
            {//Ž‹ŠE”ÍˆÍ“à‚É“ü‚Á‚½ê‡
                dot = Vector3.Dot(pf, (enemy.transform.position - tpos).normalized);
                if (dot < 0) { dot *= -1; }
                if (Data.cosAlpha < dot)
                {
                    enemy.gameObject.SetActive(false);
                    enemycount.Minus();
                    scoreText.plus();
                }
            }
        }
    }
    void QuickEnemy()
    {
        var list = GameObject.FindObjectsOfType<QuickEnemy>();
        foreach (var enemy in list)
        {

            if ((enemy.transform.position.x - tpos.x) * (enemy.transform.position.x - tpos.x) + (enemy.transform.position.z - tpos.z) * (enemy.transform.position.z - tpos.z) < tr * tr)
            {//Ž‹ŠE”ÍˆÍ“à‚É“ü‚Á‚½ê‡
                dot = Vector3.Dot(pf, (enemy.transform.position - tpos).normalized);
                if (dot < 0) { dot *= -1; }
                if (Data.cosAlpha < dot)
                {
                    enemy.gameObject.SetActive(false);
                    quickEnemyCount.Minus();
                    scoreText.plus();
                }
            }
        }
    }
    void ShooterEnemy()
    {
        var list = GameObject.FindObjectsOfType<ShooterEnemy>();
        foreach (var enemy in list)
        {
            if ((enemy.transform.position.x - tpos.x) * (enemy.transform.position.x - tpos.x) + (enemy.transform.position.z - tpos.z) * (enemy.transform.position.z - tpos.z) < tr * tr)
            {//Ž‹ŠE”ÍˆÍ“à‚É“ü‚Á‚½ê‡
                dot = Vector3.Dot(pf, (enemy.transform.position - tpos).normalized);
                if (dot < 0) { dot *= -1; }
                if (Data.cosAlpha < dot)
                {
                    enemy.gameObject.SetActive(false);
                    shooterEnemyCount.Minus();
                    scoreText.plus();
                }
            }
        }
    }
}
