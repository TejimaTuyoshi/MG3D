using UnityEngine;

public class Enemy: MonoBehaviour
{
    Transform area;
    Vector3 tpos;

    float tr = Data.range;
    float dot;

    [SerializeField] float move = 0.02f;
    Transform enemyTransform;
    Player player = null;
    EnemyCount enemycount;
    ScoreText scoreText;
    // Start is called before the first frame update
    void Start()
    {
        tpos = transform.position;
        player = GameObject.FindObjectOfType<Player>();
        enemycount = GameObject.FindObjectOfType<EnemyCount>();
        scoreText = GameObject.FindObjectOfType<ScoreText>();
        enemyTransform = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        area.transform.Find("AttactArea");
        if (player.transform.position.x < this.transform.position.x){ enemyTransform.Translate(-move, 0, 0); }
        else if (player.transform.position.x > this.transform.position.x){ enemyTransform.Translate(move, 0, 0); }

        if (player.transform.position.z < this.transform.position.z){ enemyTransform.Translate(0, 0, -move); }
        else if (player.transform.position.z > this.transform.position.z){ enemyTransform.Translate(0, 0, move); }

        var pf = area.forward;

        if ((area.position.x - tpos.x) * (area.position.x - tpos.x) + (area.position.z - tpos.z) * (area.position.z - tpos.z) < tr * tr)
        {//Ž‹ŠE”ÍˆÍ“à‚É“ü‚Á‚½ê‡
            dot = Vector3.Dot(pf, (tpos - area.position).normalized);
            if (Data.cosAlpha < dot)
            {
                this.gameObject.SetActive(false);
                scoreText.plus();
                enemycount.Minus();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            enemycount.Minus();
        }
    }
}
