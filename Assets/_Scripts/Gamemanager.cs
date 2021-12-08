using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    public float population = 10;
    [SerializeField]
    public float money = 125;
    [SerializeField]
    public float happiness = 0;
    [SerializeField]
    public float loyalty = 0;
    [SerializeField]
    public float fear = 0;
    [SerializeField]
    public float education = 0;
    [SerializeField]
    public float crime = 0;
    [SerializeField]
    public float wealth = 0;
    [SerializeField]
    public float tax = 0.20f;
    public int Etap = 1;


    public static GameManager Instance;



    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Debug.Log("An instance error");
    }





}
