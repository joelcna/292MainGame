using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform[] path;

    public Transform StartPoint;

    public int credits; 

    private void Awake()
    {
        main = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        credits = 100;
    }

    public void IncreaseCredits(int amount)
    {
        credits += amount;
    }

    public bool SpendCredits(int amount)
    {
        if (amount <= credits)
        {
            credits -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough credits");
            return false;
        }
    }
}