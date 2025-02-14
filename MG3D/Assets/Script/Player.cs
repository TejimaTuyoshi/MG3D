using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float normalMove = 0.08f;
    [SerializeField] float flash = 0f;
    [SerializeField] bool isStop = true;
    [SerializeField] bool isflash = false;
    [SerializeField] bool isJump = false;
    bool isJumpUnlock = false;
    
    [SerializeField] GameObject attackArea;
    [SerializeField] GameObject okSign;
    [SerializeField] GameObject PlayerLight;
    EnemyCount enemyCount;
    QuickEnemyCount quickEnemyCount;
    ShooterEnemyCount shooterEnemyCount;
    ScoreText scoreText;
    ExplainText explainText;
    WolrdTime wolrdTime;

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
            attackArea.SetActive(true);
            isflash = false;
        }
        else if (flash >= 1.5f) { attackArea.SetActive(false); }
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
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !isStop)
        {
            myTransform.Translate(0, 0, normalMove);
            attackArea.transform.rotation = Quaternion.Euler(0, 180, 0);
            PlayerLight.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isStop)
        {
            myTransform.Translate(0, 0, -normalMove);
            attackArea.transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerLight.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && !isStop)
        {
            myTransform.Translate(normalMove, 0, 0);
            attackArea.transform.rotation = Quaternion.Euler(0, 270, 0);
            PlayerLight.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && !isStop)
        {
            myTransform.Translate(-normalMove, 0, 0);
            attackArea.transform.rotation = Quaternion.Euler(0, 90, 0);
            PlayerLight.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift) && !isStop){ normalMove = 0.16f; }
        else{ normalMove = 0.08f; }
        if (Input.GetKey("z") && !isStop && isJump)
        {
            rigidBody.AddForce(transform.TransformDirection(Vector3.up) * 30f, ForceMode.Force);
            isJump = false;
            Debug.Log("Hit");
        }
    }

    public void First()
    {
        isStop = false;
    }


    public void Finish() { isStop = true;}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jump"))
        {
            isJumpUnlock = true;
            isJump = true;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Wall") && isJumpUnlock)
        {
            isJump = true;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            enemyCount.Minus();
            scoreText.damagePlus();
        }
        if (other.gameObject.CompareTag("QuickEnemy"))
        {
            other.gameObject.SetActive(false);
            quickEnemyCount.Minus();
            scoreText.damagePlus();
        }
        if (other.gameObject.CompareTag("ShooterEnemy"))
        {
            other.gameObject.SetActive(false);
            shooterEnemyCount.Minus();
            scoreText.damagePlus();
        }
    }
}
