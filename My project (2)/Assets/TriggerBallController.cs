using UnityEngine;

public class TriggerBallController : MonoBehaviour
{
    public GameObject door;

    private float smoothTime = 0.2f;
    [SerializeField] private float speed ;
    private Vector3 velocity;
    public bool a = false;

    [SerializeField] private  Vector3 basePos;
    [SerializeField] private Vector3 move;

    

    private void Start()
    {
        basePos = door.transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            //myMaterial.color = Color.green;
            a= true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {   
            //myMaterial.color = Color.green;
            a= true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag.Equals("Ball"))
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