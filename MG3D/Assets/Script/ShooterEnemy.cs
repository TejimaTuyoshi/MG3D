using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] GameObject enemy;
    [SerializeField] Collider enemyArea;

    float coolTime = 0f;
    [SerializeField] float limit = 3f;
    [SerializeField] bool isjump = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coolTime = Time.deltaTime;
        if (coolTime < limit)
        {
            isjump = true;
            coolTime = 0f;
        }
        else
        {
            enemyArea.enabled = false;
            isjump = false;
        }

        if (isjump)
        {
            enemyArea.enabled = true;
            enemy.transform.position += transform.TransformDirection(Vector3.up) * 0.1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(ammo, new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 1f, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
