using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseRollScript : MonoBehaviour
{
    public bool NextRoll { get; set; }
    [SerializeField] private GameObject[] DicePrefab;
    [SerializeField] private Transform DicePosition; 
    void Start()
    {
        NextRoll = true;
    }

    void Update()
    {
        if (NextRoll)
        {
            NextRoll = false;
            Invoke("Roll", 1);
        }
    }

    void Roll()
    {
        int i = Random.Range(0, 5);
        Instantiate(DicePrefab[i], DicePosition);
        NextRoll = true;
    }
}
