using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector3 move;
    
    public Vector3 getMove() {return move;}
}