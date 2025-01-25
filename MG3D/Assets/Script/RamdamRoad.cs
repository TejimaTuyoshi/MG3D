using UnityEngine;

public enum Road
{
    Simple,
    Fall,
    Break
}

public class RamdamRoad : MonoBehaviour
{

    [SerializeField] bool isside;
    [SerializeField] int rotateY = 0;
    [SerializeField] Road roads;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject fallObj;
    [SerializeField] GameObject breakObj;
    Transform roadTransform;
    Vector3 roadPosition;
    Quaternion roadRotation;

    void Start()
    {
        var random = new System.Random();
        var num = random.Next(0, 3);
        roadTransform = this.gameObject.transform;
        roadPosition = roadTransform.position;
        roadRotation = roadTransform.rotation;
        roads += num;
        Create();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Create()
    {
        if (isside) { rotateY = 90; }
        else { rotateY = 0; }

        if (roads == Road.Simple)
        {
            Instantiate(obj, new Vector3(roadPosition.x, roadPosition.y, roadPosition.z), Quaternion.Euler(roadRotation.x, rotateY, roadRotation.z));
        }
        if (roads == Road.Fall)
        {
            Instantiate(fallObj, new Vector3(roadPosition.x, roadPosition.y, roadPosition.z), Quaternion.Euler(roadRotation.x, rotateY, roadRotation.z));
        }
        if (roads == Road.Break)
        {
            Instantiate(breakObj, new Vector3(roadPosition.x, roadPosition.y, roadPosition.z), Quaternion.Euler(roadRotation.x, rotateY, roadRotation.z));
        }
    }
}
