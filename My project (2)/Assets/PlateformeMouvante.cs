using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class PlateformeMouvante : MonoBehaviour
{
    [SerializeField] private Vector3 pointA; // Le point de départ
    [SerializeField] private Vector3 pointB; // Le point d'arrivée
    [SerializeField] private float vitesse = 5f; // La vitesse de déplacement

    private Vector3 destination; // La destination actuelle

    [SerializeField] private Receiver input;
    [SerializeField] private bool alwaysActive;

    [SerializeField] private float waitingTime;
    private float currentTime;

    private void Start()
    {
        // Initialiser la destination au point A
        destination = pointA;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        // Calculer la distance entre la position actuelle et la destination
        float distance = Vector3.Distance(transform.position, destination);

        // Si la distance est suffisamment petite, changer la destination
        if (distance < 0.01f)
        {
            currentTime = 0;
            if (destination == pointA)
            {
                destination = pointB;
            }
            else
            {
                destination = pointA;
            }
        }

        if(currentTime > waitingTime)
        {
            if (alwaysActive)
            {
                // Déplacer la plateforme vers la destination en utilisant une interpolation linéaire
                transform.position = Vector3.MoveTowards(transform.position, destination, vitesse * 7 * Time.deltaTime);
            }
            else if (input != null) if (input.output) transform.position = Vector3.MoveTowards(transform.position, destination, vitesse * 7 * Time.deltaTime);
        }
    }
}