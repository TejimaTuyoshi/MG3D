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

        if (time >= 1 && enemycount.enemyCount < enemylimit)
        {
            time = 0;
            enemycount.Plus();
            if (enemys == InstanceEnemys.Simple){Instantiate(obj, new Vector3(enemyinstance.position.x, enemyinstance.position.y, enemyinstance.position.z), Quaternion.identity);}
            if (enemys == InstanceEnemys.Quick) { Instantiate(quickObj, new Vector3(enemyinstance.position.x, enemyinstance.position.y, enemyinstance.position.z), Quaternion.identity); }
            if (enemys == InstanceEnemys.shooter) { Instantiate(shooterObj, new Vector3(enemyinstance.position.x, enemyinstance.position.y, enemyinstance.position.z), Quaternion.identity); }
        }
    }
}
