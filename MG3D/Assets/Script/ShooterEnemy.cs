using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] GameObject enemy;
    [SerializeField] Collider enemyArea;

    float coolTime = 0f;
    [SerializeField] float shotlimit = 0f;
    [SerializeField] float limit = 3f;
    [SerializeField] float ammolimit = 1f;
    [SerializeField] bool isjump = false;
    [SerializeField] bool isshot = false;
    [SerializeField] bool islimit = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coolTime += Time.deltaTime;
        shotlimit += Time.deltaTime;
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

        if (shotlimit >= ammolimit)
        {
            islimit = true;
            shotlimit = 0f;
        }
        else
        {
            islimit = false;
        }

        if (isjump)
        {
            enemyArea.enabled = true;
            enemy.transform.position += transform.TransformDirection(Vector3.up) * 0.1f;
        }

        if (isshot && islimit)
        {
            Instantiate(ammo, new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 1f, gameObject.transform.position.z), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isshot = true;
        }
    }
}
