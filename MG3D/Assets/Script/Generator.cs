using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]float time = 0f;
    [SerializeField] EnemyCount enemycount;
    [SerializeField]GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 1 && enemycount.enemyCount < 10)
        {
            time = 0;
            enemycount.Plus();
            Instantiate(obj, new Vector3(gameObject.transform.position.x, 0.4f, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
