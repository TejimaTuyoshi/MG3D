using UnityEngine;


public enum InstanceEnemys
{
    Simple,
    Quick,
    shooter
}
public class Generator : MonoBehaviour
{
    [SerializeField] float time = 0f;
    [SerializeField] int enemylimit = 10;
    [SerializeField] Transform enemyinstance;
    [SerializeField] EnemyCount enemycount;
    [SerializeField] QuickEnemyCount quickenemycount;
    [SerializeField] ShooterEnemyCount shooterenemycount;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject quickObj;
    [SerializeField] GameObject shooterObj;
    [SerializeField] InstanceEnemys enemys;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (enemys == InstanceEnemys.Simple)
        {
            if (time >= 1 && enemycount.enemyCount < enemylimit)
            {
                time = 0;
                enemycount.Plus();
                Instantiate(obj, new Vector3(enemyinstance.position.x, enemyinstance.position.y, enemyinstance.position.z), Quaternion.identity);
                obj.name = obj.name;
            }
        }
        if (enemys == InstanceEnemys.Quick)
        {
            if (time >= 1 && quickenemycount.enemyCount < enemylimit)
            {
                time = 0;
                quickenemycount.Plus();
                Instantiate(quickObj, new Vector3(enemyinstance.position.x, enemyinstance.position.y, enemyinstance.position.z), Quaternion.identity);
                obj.name = quickObj.name;
            }
        }
        if (enemys == InstanceEnemys.shooter)
        {
            if (time >= 1 && shooterenemycount.enemyCount < enemylimit)
            {
                time = 0;
                shooterenemycount.Plus();
                Instantiate(shooterObj, new Vector3(enemyinstance.position.x, enemyinstance.position.y, enemyinstance.position.z), Quaternion.identity);
                obj.name = shooterObj.name;
            }
        }
    }
}
