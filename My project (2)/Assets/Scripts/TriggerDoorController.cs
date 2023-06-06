using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    public GameObject door;

    private float smoothTime = 0.2f; 
    public float speed ;
    Vector3 velocity;
    public bool a = false;

    [SerializeField] private  Vector3 basePos;
    [SerializeField] private Vector3 move;



    private void Start()
    {
        basePos = door.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //myMaterial.color = Color.green;
            a= true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //myMaterial.color = Color.green;
            a= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //myMaterial.color = Color.red;
            a= false;
        }
    }

    private void Update()
    {
        if(a)
        {
            door.transform.position = Vector3.SmoothDamp(door.transform.position, basePos+move, ref velocity, smoothTime,speed);
        }
        else
        {
            door.transform.position = Vector3.SmoothDamp(door.transform.position, basePos, ref velocity, smoothTime,speed);
        }

    }

}