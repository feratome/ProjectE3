using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector3 move;
    //[SerializeField] private GameObject perso;
    
	[SerializeField] private FadeScreen fs;

    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
	{
		Debug.Log("TRIGGER");
		if (other.CompareTag("Player"))
		{
			Debug.Log(other.gameObject.name);
			other.transform.position = other.transform.position + move;
			if(fs != null)
			{
                fs.ChangeColor(10f, 100f, 0);
                fs.FadeIn();
            }
		}
	}
}
