using UnityEngine;

public class Enemy: MonoBehaviour
{
    Transform enemyTransform;
    Player player = null;
    EnemyCount enemycount;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        enemycount = GameObject.FindObjectOfType<EnemyCount>();
        enemyTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < this.transform.position.x)
        {
            enemyTransform.Translate(-0.02f, 0, 0);
        }
        else if (player.transform.position.x > this.transform.position.x)
        {
            enemyTransform.Translate(0.02f, 0, 0);
        }

        if (player.transform.position.z < this.transform.position.z)
        {
            enemyTransform.Translate(0, 0, -0.02f);
        }
        else if (player.transform.position.z > this.transform.position.z)
        {
            enemyTransform.Translate(0, 0, 0.02f);
        }

            if (this.gameObject.transform.position.y <= 0.3f)
        {
            transform.position += new Vector3(0,1,0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hit"))
        {
            this.gameObject.SetActive(false);
            enemycount.Minus();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            enemycount.Minus();
        }
    }
}
