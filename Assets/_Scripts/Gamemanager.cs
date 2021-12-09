using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public MusicManager Mm;
    [SerializeField]
    public float Score;
    [SerializeField]
    public GameObject myParent;
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
    [SerializeField]
    public int round = 1;
    [SerializeField]
    public bool gameplayActive = false;
    [SerializeField]
    public bool isDragged = false;

    [SerializeField]
    public GameObject buttonEnd;
    [SerializeField]
    public GameObject mainUi;


    public HandList Hl;
    public DeckList Dl;
    
    public static GameManager Instance;

    [SerializeField]
    private Camera mainCamera;
    public void ChangeCameraPosition()
    {
        mainCamera.transform.position = new Vector3(0, 117,-35);


    }

    public void GoToMainPosition()
    {
        mainCamera.transform.position = new Vector3(0, 0,-35);
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Debug.Log("An instance error");

      
    }


}
