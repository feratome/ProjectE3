using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OpenDoor : MonoBehaviour
{
    public bool isPressed = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Poids"))
        {
            isPressed = true;
            // Appeler une fonction pour ouvrir la porte
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Poids"))
        {
            isPressed = false;
            // Appeler une fonction pour fermer la porte
        }
    }
}