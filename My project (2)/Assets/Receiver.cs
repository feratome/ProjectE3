using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.ProBuilder.Shapes;

public class Receiver : MonoBehaviour
{
    [SerializeField] public List<Sender> senders = new List<Sender>();
    [SerializeField] public int enablingCount;
    private int currentCount;

    public bool output;

    private enum LogicMode
    {
        AND,
        OR,
        XOR
    }
    [SerializeField] private LogicMode mode;

    // Start is called before the first frame update
    void Start()
    {
        currentCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentCount = 0;

        foreach (Sender sender in senders) if(sender.output) currentCount++;

        output = (currentCount >= enablingCount);
        if (mode == LogicMode.AND) { output = (currentCount >= enablingCount); }
        else if (mode == LogicMode.OR) { output = (currentCount >= 0); }
        else if(mode == LogicMode.XOR) {  output = (currentCount%2 == 1); }
    }
}
