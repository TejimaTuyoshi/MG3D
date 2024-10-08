using UnityEngine;

public class Player : MonoBehaviour
{
    int lifeCount = 3;
    [SerializeField] float normalMove = 0.08f;
    [SerializeField] float flash = 0f;
    [SerializeField] bool isStop = true;
    [SerializeField] bool isflash = false;

    [SerializeField] GameObject north;
    [SerializeField] GameObject south;
    [SerializeField] GameObject west;
    [SerializeField] GameObject east;
    [SerializeField] GameObject AttackArea;
    [SerializeField] GameObject okSign;
    EnemyCount enemyCount;
    QuickEnemyCount quickEnemyCount;
    ShooterEnemyCount shooterEnemyCount;
    ScoreText scoreText;
    WolrdTime wolrdTime;
    EndPanel endPanel;

    [SerializeField] Animator animator;
    Transform myTransform;
    Rigidbody rigidBody;
    Vector3 localPos;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.FindObjectOfType<EnemyCount>();
        quickEnemyCount = GameObject.FindObjectOfType<QuickEnemyCount>();
        shooterEnemyCount = GameObject.FindObjectOfType<ShooterEnemyCount>();
        scoreText = GameObject.FindObjectOfType<ScoreText>();
        wolrdTime = GameObject.FindObjectOfType<WolrdTime>();
        endPanel = GameObject.FindObjectOfType<EndPanel>();
        rigidBody = GetComponent<Rigidbody>();
        Time.timeScale = 0.0f;
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        flash += Time.deltaTime;
        if (isflash)
        {
            AttackArea.SetActive(true);
            isflash = false;
        }
        else if (flash >= 1.5f) { AttackArea.SetActive(false); }
        else { okSign.SetActive(false); }
        localPos = myTransform.localPosition;
        if (flash >= 3.5f)
        {
            okSign.SetActive(true);
            if (Input.GetKey("space") && !isStop)
            {
                isflash = true;
                animator.SetTrigger("Flash");
                flash = 0f;
            }
        }

        if (lifeCount == 0)
        {
            wolrdTime.Stop();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a") && !isStop)
        {
            myTransform.Translate(0, 0, normalMove);
        }
        if (Input.GetKey("d") && !isStop)
        {
            myTransform.Translate(0, 0, -normalMove);
        }

        if (Input.GetKey("w") && !isStop)
        {
            myTransform.Translate(normalMove, 0, 0);
        }
        if (Input.GetKey("s") && !isStop)
        {
            myTransform.Translate(-normalMove, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift) && !isStop)
        {
            normalMove = 0.16f;
        }
        else
        {
            normalMove = 0.08f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !isStop)
        {
            west.SetActive(true);
            north.SetActive(false);
            south.SetActive(false);
            east.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && !isStop)
        {
            west.SetActive(false);
            north.SetActive(true);
            south.SetActive(false);
            east.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && !isStop)
        {
            west.SetActive(false);
            north.SetActive(false);
            south.SetActive(true);
            east.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isStop)
        {
            west.SetActive(false);
            north.SetActive(false);
            south.SetActive(false);
            east.SetActive(true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void First()
    {
        isStop = false;
        Time.timeScale = 1.0f;
    }

    public void LifeMinus() { lifeCount--; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jump"))
        {
            rigidBody.AddForce(transform.TransformDirection(Vector3.right) * 0.2f, ForceMode.Impulse);
            rigidBody.AddForce(transform.TransformDirection(Vector3.up) * 0.5f, ForceMode.Impulse);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            LifeMinus();
            enemyCount.Minus();
            endPanel.CountUp();
        }
        if (other.gameObject.CompareTag("QuickEnemy"))
        {
            other.gameObject.SetActive(false);
            LifeMinus();
            quickEnemyCount.Minus();
            endPanel.CountUp();
        }
        if (other.gameObject.CompareTag("ShooterEnemy"))
        {
            other.gameObject.SetActive(false);
            LifeMinus();
            shooterEnemyCount.Minus();
            endPanel.CountUp();
        }
    }
}

static public class Data
{
    public const float range = 8f;
    public const float cosAlpha = 0.85f;
}
