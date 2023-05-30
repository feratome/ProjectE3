using UnityEngine;

public class TriggerPlatformController : MonoBehaviour
{
    public GameObject door;
    //private bool IsTriggered = false;
    //private bool IsNotTriggered = true;
    //[SerializeField] private Material myMaterial;

    
    private bool a = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            //IsTriggered=true;
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
            //IsNotTriggered=true;
            //myMaterial.color = Color.red;
            a= false;
        }
    }

    private void Update()
    {
        if(a){

            door.GetComponent<PlateformeMouvante>().enabled = true;
            //IsTriggered=false;
            

        }
        if(!a){
            door.GetComponent<PlateformeMouvante>().enabled=false;
            //IsNotTriggered=false;
        }

    }

}