using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseRollScript : MonoBehaviour
{
    public bool NextRoll { get; set; }
    [SerializeField] private GameObject[] DicePrefab;
    [SerializeField] private Transform DicePosition;

    public bool culcOK;
    public int ForculcNum;

    public static DiseRollScript Instance { get; private set; }
    void Start()
    {
        Instance = this;
        NextRoll = false;

        culcOK = false;
        ForculcNum = 0;
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
        ForculcNum = Random.Range(0, 5);
        Instantiate(DicePrefab[ForculcNum], DicePosition);
        culcOK = true;
        //NextRoll = true;
    }
}
