using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
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
    float limitY = 2f;
    float limitZ = 5f;
    float time = 0f;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
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

    void FixedUpdate()
    {
        if (player.transform.position.x < this.transform.position.x)
        {
            ammo.front();//ëOï˚å¸Ç…ìäÇ∞ÇÈ
        }
        else if (player.transform.position.x > this.transform.position.x)
        {
            ammo.back();//å„ÇÎï˚å¸Ç…ìäÇ∞ÇÈ
        }
        if (player.transform.position.z < this.transform.position.z)
        {
            ammo.Right();//âEï˚å¸Ç…ìäÇ∞ÇÈ
        }
        else if (player.transform.position.z > this.transform.position.z)
        {
            ammo.Left();//ç∂ï˚å¸Ç…ìäÇ∞ÇÈ
        }
    }

}
