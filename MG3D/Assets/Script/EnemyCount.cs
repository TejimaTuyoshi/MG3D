using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Minus()
    {
        enemyCount--;
    }

    public void Plus()
    {
        enemyCount++;
    }
}
