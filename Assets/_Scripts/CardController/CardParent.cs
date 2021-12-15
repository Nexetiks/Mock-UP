using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

abstract public class CardParent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerExitHandler, IPointerEnterHandler, IDragHandler, IPointerClickHandler
{
    private RoundManager Rm;

    [SerializeField]
    public float costAmount = 0;

    [SerializeField]
    public int idCard;

    [SerializeField]
    public float populationAmount = 0;
    [SerializeField]
    public float populationMultiplier = 1;

    [SerializeField]
    public float moneyAmount = 0;
    [SerializeField]
    public float moneyMultiplier = 1;

    [SerializeField]
    public float happinessAmount = 0;
    [SerializeField]
    public float happinessMultiplier = 1;

    [SerializeField]
    public float loyaltyAmount = 0;
    [SerializeField]
    public float loyaltyMultiplier = 1;

    [SerializeField]
    public float fearAmount = 0;
    [SerializeField]
    public float fearMultiplier = 1;

    [SerializeField]
    public float educationAmount = 0;
    [SerializeField]
    public float educationMultiplier = 1;

    [SerializeField]
    public float crimeAmount = 0;
    [SerializeField]
    public float crimeMultiplier = 1;

    [SerializeField]
    public float wealthAmount = 0;
    [SerializeField]
    public float wealthMultiplier = 1;

    [SerializeField]
    public float taxAmount = 20;

    [SerializeField]
    public float taxMultiplier = 1;



    [SerializeField]
    public bool isDragged = false, isHovered = false;

    [SerializeField]
    public TextMesh textCard;

    [SerializeField]
    public Camera cam;

    [SerializeField]
    public Canvas canvas;

    [SerializeField]
    public Texture textureCard;

    [SerializeField]
    public RawImage rawImage;

    [SerializeField]
    public RectTransform rectTra;

    [SerializeField]
    public int helpe=0;


    [SerializeField]
    public Vector3 viewPortCardPosition;

    [SerializeField]
    public Vector3 worldPosition, startPostion, temporaryPosition;

    [SerializeField]
    public Quaternion startRotation,temporaryRotation;

    [SerializeField]
    public int x;
    [SerializeField]
    public int xCount;
    [SerializeField] private CardDestroyer cardDestroyer;


    [SerializeField]
    public bool isThereCardToDestroy =false;
    [SerializeField]
    public int amountCardToDiscard;


    

    virtual public void Awake()
    {
        canvas = FindObjectOfType<Canvas>();


        rectTra = this.GetComponent<RectTransform>();
        rawImage = this.GetComponent<RawImage>();

        cam = Camera.main;
        Rm = new RoundManager();
    }

    private void Start()
    {
        //  startPostion = GameManager.Instance.indexHelper;
        transform.position = GameManager.Instance.position[GameManager.Instance.HandList.GetIndex(idCard)];
        transform.rotation = GameManager.Instance.rotation[GameManager.Instance.HandList.GetIndex(idCard)];

        //if(isThereCardToDestroy ==true) 
        //amountCardToDiscard = ((GameManager.Instance.round) % 5);
    }

    virtual public void OnBeginDrag(PointerEventData eventData)
    {
    }

    virtual public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.gameplayActive == true)
        {
            GameManager.Instance.isDragged = true;
            rawImage.transform.DORotateQuaternion(Quaternion.Euler(0f, 0f, 0f), 0.2f);
            rawImage.transform.DOMove(new Vector3((cam.ScreenToWorldPoint(MousePlace())).x, -4.6f, (cam.ScreenToWorldPoint(MousePlace())).z + 45f), 0.2f);
        }
    }

    virtual public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        if (GameManager.Instance.isDragged == false && rawImage.transform.position == GameManager.Instance.position[GameManager.Instance.HandList.GetIndex(idCard)] && GameManager.Instance.gameplayActive == true)
        {
            Debug.Log("enter if");
            GameManager.Instance.isBacking = false;
            GameManager.Instance.musicManager.PlaySound("cardHover");

            enterCard(GameManager.Instance.HandList.GetIndex(idCard));

            MouseENTER();  
        }
    }

    virtual public void OnPointerExit(PointerEventData eventData)
    {

        if (GameManager.Instance.isDragged == false && GameManager.Instance.gameplayActive == true  )
        {
            Debug.Log("exit");
            exitCard(GameManager.Instance.HandList.GetIndex(idCard));
            MouseEXIT();
        }
    }

    virtual public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("enddrag");
        if (IsCardPlaced() != true&& GameManager.Instance.isBacking == false)
        {

            GameManager.Instance.isDragged = false;
            GameManager.Instance.isBacking = true;

            exitCard(GameManager.Instance.HandList.GetIndex(idCard));
            MouseUP();
        }
    }



    virtual public void CardInvocate()
    {

        GameManager.Instance.money = GameManager.Instance.money - costAmount;


        GameManager.Instance.population = GameManager.Instance.population + populationAmount;
        GameManager.Instance.population = GameManager.Instance.population * populationMultiplier;

        GameManager.Instance.money = GameManager.Instance.money + moneyAmount;
        GameManager.Instance.money = GameManager.Instance.money * moneyMultiplier;

        GameManager.Instance.happiness = Mathf.Clamp01(GameManager.Instance.happiness + happinessAmount / 100);
        GameManager.Instance.happiness = Mathf.Clamp01(GameManager.Instance.happiness * happinessMultiplier);

        GameManager.Instance.loyalty = Mathf.Clamp01(GameManager.Instance.loyalty + loyaltyAmount / 100);
        GameManager.Instance.loyalty = Mathf.Clamp01(GameManager.Instance.loyalty * loyaltyMultiplier);

        GameManager.Instance.fear = Mathf.Clamp01(GameManager.Instance.fear + fearAmount / 100);
        GameManager.Instance.fear = Mathf.Clamp01(GameManager.Instance.fear * fearMultiplier);

        GameManager.Instance.education = Mathf.Clamp01(GameManager.Instance.education + educationAmount / 100);
        GameManager.Instance.education = Mathf.Clamp01(GameManager.Instance.education * educationMultiplier);

        GameManager.Instance.crime = Mathf.Clamp01(GameManager.Instance.crime + crimeAmount / 100);
        GameManager.Instance.crime = Mathf.Clamp01(GameManager.Instance.crime * crimeMultiplier);

        GameManager.Instance.wealth = GameManager.Instance.wealth + wealthAmount;
        GameManager.Instance.wealth = GameManager.Instance.wealth * wealthMultiplier;

        GameManager.Instance.tax = Mathf.Clamp01(GameManager.Instance.tax + taxAmount / 100);
        GameManager.Instance.tax = Mathf.Clamp01(GameManager.Instance.tax * taxMultiplier);
    }


    //Returning mouse position to be able to move cards
    virtual public Vector3 MousePlace()
    {
        Vector3 placeOfMouse = Input.mousePosition;
        placeOfMouse.z = canvas.planeDistance;
        worldPosition = cam.ScreenToWorldPoint(placeOfMouse);

        return placeOfMouse;
    }


    //Cheking if the card is places in the center
    virtual public bool IsCardPlaced()
    {
        if (GameManager.Instance.gameplayActive == true)
        {
            viewPortCardPosition = cam.WorldToViewportPoint(rawImage.rectTransform.position);

            if (viewPortCardPosition.y > 0.1f )
            {
                GameManager.Instance.gameplayActive = false;

                temporaryPosition = rawImage.rectTransform.position;
                startPostion = temporaryPosition;

                temporaryRotation = rawImage.rectTransform.rotation;
                startRotation = temporaryRotation;

                GameManager.Instance.willBeDestroyed = true;

                GameManager.Instance.positionNumber = GameManager.Instance.HandList.GetIndex(idCard);



                CardInvocate();

                Debug.Log("przed wejscie ");

                if (GameManager.Instance.discardAmount > 0&&0==2)
                {
                    Debug.Log("if ");
                    cardDestroyer.DestroyCard();

                    GameManager.Instance.HandList.UsedCard(idCard);
                    GameManager.Instance.HandList.SendCardToHand(GameManager.Instance.DeskList.cards);

                    cardToDiscard();

                    
                }


                else
                {
                    Debug.Log("else ");
                    Debug.Log("nie wszedlem");

                    

                   GameManager.Instance.ChangeFillAmount();


                    GameManager.Instance.musicManager.PlaySound("throw");

                    Debug.Log(GameManager.Instance.HandList.GetIndex(idCard));

                    GameManager.Instance.isDragged = false;



                    GameManager.Instance.HandList.UsedCard(idCard);

                    GameManager.Instance.HandList.SendCardToHand(GameManager.Instance.DeskList.cards);





                    cardDestroyer.DestroyCard();


                    /// end tutaj!!!
                    Rm.EndOfTheRound();


                }

                return true;
            }
            else return false;
        }
        return false;
    }


    virtual public void BeginDRAG()
    {
        GameManager.Instance.isDragged = true;
        isHovered = true;
    }

    virtual public void MouseENTER()
    {
        isHovered = true;
    }

    virtual public void MouseEXIT()
    {
        isHovered = false;
    }

    virtual public void MouseUP()
    {
        GameManager.Instance.isDragged = false;
    }

    virtual public void cardReplacement()
    {

        if (GameManager.Instance.DeskList.cards.Count == 0 && GameManager.Instance.willBeDestroyed == false)
        {
            xCount = GameManager.Instance.HandList.cardsInHand.Count;

            /*
            for (int i = 0; i < xCount; i++)
            {
                if (startPostion == GameManager.Instance.position[i])
                {
                    Debug.Log(this.name + " " + i);
                    x = i;
                }
            }
            */


            x = GameManager.Instance.HandList.GetIndex(idCard);

            if (xCount == 1)
            {
                // startPostion = GameManager.Instance.position[2];
                // temporaryPosition = GameManager.Instance.position[2];

                startRotation = GameManager.Instance.rotation[2];
                temporaryRotation = GameManager.Instance.rotation[2];

                rawImage.transform.DORotateQuaternion(temporaryRotation, 0.2f);
                rawImage.transform.DOMove(temporaryPosition, 0.2f);
            }

            if (xCount == 3)
            {
                if (x == 0)
                {
                    // startPostion = GameManager.Instance.position[1];
                    //temporaryPosition = GameManager.Instance.position[1];

                    startRotation = GameManager.Instance.rotation[1];
                    temporaryRotation = GameManager.Instance.rotation[1];

                    rawImage.transform.DORotateQuaternion(temporaryRotation, 0.2f);
                    rawImage.transform.DOMove(temporaryPosition, 0.2f);
                }
                if (x == 1)
                {
                    // startPostion = GameManager.Instance.position[2];
                    // temporaryPosition = GameManager.Instance.position[2];

                    startRotation = GameManager.Instance.rotation[2];
                    temporaryRotation = GameManager.Instance.rotation[2];

                    rawImage.transform.DORotateQuaternion(temporaryRotation, 0.2f);
                    rawImage.transform.DOMove(temporaryPosition, 0.2f);
                }
                if (x == 2)
                {
                    // startPostion = GameManager.Instance.position[3];
                    // temporaryPosition = GameManager.Instance.position[3];
                    startRotation = GameManager.Instance.rotation[3];
                    temporaryRotation = GameManager.Instance.rotation[3];

                    rawImage.transform.DORotateQuaternion(temporaryRotation, 0.2f);
                    rawImage.transform.DOMove(temporaryPosition, 0.2f);
                }
            }


            /*  if (xCount == 5)
              {
                  startPostion = GameManager.Instance.position[x];
                  temporaryPosition = GameManager.Instance.position[x];
                  Debug.Log("5");
              }
              */


        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(transform.position);
        if (GameManager.Instance.waitForDiscard == true)
        {


            GameManager.Instance.HandList.UsedCard(this.idCard);

            GameManager.Instance.HandList.SendCardToHand(GameManager.Instance.DeskList.cards);

            cardDestroyer.DestroyCard();

            Debug.Log(this.idCard);

            GameManager.Instance.waitForDiscard = false;



        }
    }

    public virtual void cardToDiscard()
    {

        if (GameManager.Instance.chosenToDiscard != -1)
        {
            GameManager.Instance.waitForDiscard = true;
            

        }

        else
        {
            GameManager.Instance.waitForDiscard = false;
            Debug.Log("else  z funkcji");
        }
       GameManager.Instance.isDragged = false;
    }
    virtual public void enterCard(int x)
    {
        rawImage.transform.DOMove(GameManager.Instance.enterPosition[x], 0.7f);
        rawImage.transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0,0,0)), 0.7f);
    }
    virtual public void exitCard(int x)
    {
        rawImage.transform.DOMove(GameManager.Instance.position[x], 0.7f);
        rawImage.transform.DORotateQuaternion(GameManager.Instance.rotation[x], 0.7f);
    }
}
