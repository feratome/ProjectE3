using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    public GameObject door;
    private bool Istriggered = false;
    private bool IsNotTriggered = false;
    [SerializeField] private Material myMaterial;

    public Vector3 targetPosition;
    public Vector3 targetPosition2;
    private float smoothTime = 0.2f; 
    public float speed = 10;
    Vector3 velocity;
    public int a;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Istriggered=true;
            myMaterial.color = Color.green;
            a=1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsNotTriggered=true;
            myMaterial.color = Color.red;
            a=0;
        }
    }

    private void Update()
    {
        if(Istriggered && a == 1){
            door.transform.position = Vector3.SmoothDamp(door.transform.position, targetPosition, ref velocity, smoothTime, speed);
            //Istriggered=false;
        }
        if(IsNotTriggered && a==0){
            door.transform.position = Vector3.SmoothDamp(door.transform.position, targetPosition2, ref velocity, smoothTime, speed);
            //IsNotTriggered=false;
        }

    }

}