
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFix : MonoBehaviour
{
    [SerializeField] private GameObject perso;
        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log("trigger");
                // Récupérer le transform de l'objet avec le tag "Player"
                
                // Mettre l'objet "Player" comme enfant de la plateforme
            perso.transform.SetParent(transform);
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log("Dettrigered");
                // Récupérer le transform de l'objet avec le tag "Player"
            

                // Mettre l'objet "Player" comme enfant de la plateforme
                perso.transform.SetParent(null);
            }
        }
}
