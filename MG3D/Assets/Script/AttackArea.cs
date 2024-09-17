using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    Transform enemy;
    Vector3 tpos;

    float tr = Data.range;
    float dot;

    EnemyCount enemycount;
    ScoreText scoreText;
    // Start is called before the first frame update
    void Start()
    {
        enemycount = GameObject.FindObjectOfType<EnemyCount>();
        scoreText = GameObject.FindObjectOfType<ScoreText>();
    }

    // Update is called once per frame
    void Update()
    {
        tpos = GameObject.FindObjectOfType<Player>().gameObject.transform.position;
        Enemy();
        ShooterEnemy();
    }


    void Enemy()
    {
        var list = GameObject.FindObjectsOfType<Enemy>();
        foreach (var enemy in list)
        {
            var pf = enemy.transform.forward;
            if ((enemy.transform.position.x - tpos.x) * (enemy.transform.position.x - tpos.x) + (enemy.transform.position.z - tpos.z) * (enemy.transform.position.z - tpos.z) < tr * tr)
            {//���E�͈͓��ɓ������ꍇ
                dot = Vector3.Dot(pf, (enemy.transform.position - tpos).normalized);
                if (dot < 0) { dot *= -1; }
                Debug.Log($"{dot}");
                if (Data.cosAlpha < dot)
                {
                    enemy.gameObject.SetActive(false);
                    enemycount.Minus();
                    Debug.Log("Hit");
                }
            }
        }
    }
    void ShooterEnemy()
    {
        var list = GameObject.FindObjectsOfType<ShooterEnemy>();
        foreach (var enemy in list)
        {
            var pf = enemy.transform.forward;
            if ((enemy.transform.position.x - tpos.x) * (enemy.transform.position.x - tpos.x) + (enemy.transform.position.z - tpos.z) * (enemy.transform.position.z - tpos.z) < tr * tr)
            {//���E�͈͓��ɓ������ꍇ
                dot = Vector3.Dot(pf, (enemy.transform.position - tpos).normalized);
                if (dot < 0) { dot *= -1; }
                Debug.Log($"{dot}");
                if (Data.cosAlpha < dot)
                {
                    enemy.gameObject.SetActive(false);
                    enemycount.Minus();
                    Debug.Log("Hit");
                }
            }
        }
    }
}
