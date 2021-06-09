using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{

    public static TrapManager instance;
    public Trap_Basic[] allTraps;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        allTraps = FindObjectsOfType<Trap_Basic>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetAllTraps()
    {
        for (int i = 0; i < allTraps.Length; i++)
        {
            allTraps[i].instance.resetTrap();
        }
    }
}