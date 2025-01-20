using UnityEngine;

public enum Road
{
    Simple,
    Fall,
    Break
}

public class RamdamRoad : MonoBehaviour
{

    [SerializeField] Road roads;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject fallObj;
    [SerializeField] GameObject breakObj;
    [SerializeField] Transform roadPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var random = new System.Random();
        var num = random.Next(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (roads == Road.Simple)
        {
            Instantiate(obj, new Vector3(roadPosition.x, roadPosition.position.y, roadPosition.position.z), Quaternion.identity);
        }
        if (roads == Road.Fall)
        {
            Instantiate(fallObj, new Vector3(roadPosition.position.x, roadPosition.position.y, roadPosition.position.z), Quaternion.identity);
        }
        if (roads == Road.Break)
        {
            Instantiate(breakObj, new Vector3(roadPosition.position.x, roadPosition.position.y, roadPosition.position.z), Quaternion.identity);
        }
    }
}
