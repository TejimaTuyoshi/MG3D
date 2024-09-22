using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    EnemyCount enemycount;
    ScoreText scoreText;
    [SerializeField] Ammo ammo;
    float x = 0f;
    float y = 0f;
    float z = 0f;
    float playerX = 0f;
    float playerY = 0f;
    float playerZ = 0f;
    float distanceX = 0f;
    float distanceY = 0f;
    float distanceZ = 0f;
    float limitX = 5f;
    float limitY = 8f;
    float limitZ = 5f;
    float time = 0f;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        playerZ = player.transform.position.z;
        distanceX = playerX - x;
        distanceY = playerY - y;
        distanceZ = playerZ - z;
        if (distanceX < 0) { distanceX *= -1; }
        if (distanceY < 0) { distanceY *= -1; }
        if (distanceZ < 0) { distanceZ *= -1; }

        if (distanceX < limitX && distanceY < limitY && distanceZ < limitZ)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                time = 0;
                Instantiate(ammo, new Vector3(x, y + 1f, z), Quaternion.identity);
            }
        }
    }
}
