using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    public bool output;

    [SerializeField] private List<string> Tags;


    private void Start()
    {
        output = false;
    }

    private void OnTriggerStay(Collider other)
    {
        foreach(string indexer in Tags)
        {
            if (other.CompareTag(indexer))
            {
                output = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (string indexer in Tags)
        {
            if (other.CompareTag(indexer))
            {
                output = false;
            }
        }
    }
}