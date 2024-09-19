using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickEnemy : MonoBehaviour
{
    [SerializeField] float move = 0.02f;
    Transform enemyTransform;
    Player player = null;
    QuickEnemyCount enemycount;
    ScoreText scoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        enemycount = GameObject.FindObjectOfType<QuickEnemyCount>();
        scoreText = GameObject.FindObjectOfType<ScoreText>();
        enemyTransform = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        enemyTransform.Translate(0, 0, move);
    }
}
