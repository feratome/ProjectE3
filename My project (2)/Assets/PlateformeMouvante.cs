using Unity.VisualScripting;
using UnityEngine;

public class PlateformeMouvante : MonoBehaviour
{
    [SerializeField] private Vector3 pointA; // Le point de départ
    [SerializeField] private Vector3 pointB; // Le point d'arrivée
    [SerializeField] private float vitesse = 5f; // La vitesse de déplacement

    private Vector3 destination; // La destination actuelle

    [SerializeField] private Receiver input;
    [SerializeField] private bool alwaysActive;

    private void Start()
    {
        // Initialiser la destination au point A
        destination = pointA;
    }

    private void Update()
    {
        // Calculer la distance entre la position actuelle et la destination
        float distance = Vector3.Distance(transform.position, destination);

        // Si la distance est suffisamment petite, changer la destination
        if (distance < 0.01f)
        {
            if (destination == pointA)
            {
                destination = pointB;
            }
            else
            {
                destination = pointA;
            }
        }

        if (alwaysActive)
        {
            // Déplacer la plateforme vers la destination en utilisant une interpolation linéaire
            transform.position = Vector3.MoveTowards(transform.position, destination, vitesse * 7 * Time.deltaTime);
        }
        else if (input != null) if (input.output) transform.position = Vector3.MoveTowards(transform.position, destination, vitesse * 7 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}