using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class CardParent : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IPointerExitHandler,IPointerEnterHandler,IDragHandler
{
    
    private RoundManager Rm;
    public float costAmount=0;

    public int idCard;

    public float populationAmount=0;
    public float populationMultiplier=1;

    public float moneyAmount=0;
    public float moneyMultiplier=1;

    public float happinessAmount = 0;
    public float happinessMultiplier=1;

    public float loyaltyAmount = 0;
    public float loyaltyMultiplier=1;

    public float fearAmount = 0;
    public float fearMultiplier=1;

    public float educationAmount = 0;
    public float educationMultiplier=1;

    public float crimeAmount = 0;
    public float crimeMultiplier=1;

    public float wealthAmount = 0;
    public float wealthMultiplier=1;

    public float taxAmount = 20;
    public float taxMultiplier=1;

    public Camera cam;

    public bool isDragged = false, isHovered = false;

    public TextMesh textCard;

    Canvas canvas;

    public Texture textureCard;

    public Vector2 size;

    public RawImage rawImage;

    Vector3 viewPortCardPosition;

    /// <summary>
    /// mozliwe ze zostanie zmienione na przypisywanie i inspektorze
    /// </summary>
    public Vector3 initialPosition;

    public Vector3 worldPosition;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        initialPosition = rawImage.rectTransform.position;//mozliwa zmaina na wartosc edytowana w inpsektorze
        cam = Camera.main;
        size= rawImage.rectTransform.sizeDelta;

    }


    virtual public void OnEndDrag(PointerEventData eventData)
    {
        if (IsCardPlaced() == true) ;//end of the round
        else
        {
            rawImage.rectTransform.position = initialPosition;
            rawImage.rectTransform.sizeDelta = size;
            MouseUP();
        }
    }

    virtual public void OnBeginDrag(PointerEventData eventData)
    {
        rawImage.rectTransform.sizeDelta = 2 * size;
        BeginDRAG();
    }

    virtual public void OnPointerExit(PointerEventData eventData)
    {
        if (isDragged == false)
        {
            rawImage.rectTransform.position = initialPosition;
            rawImage.rectTransform.sizeDelta = size;
        }

        MouseEXIT();
    }

    virtual public void OnPointerEnter(PointerEventData eventData)
    {
        rawImage.rectTransform.sizeDelta = size * 2;
        MouseENTER();
    }

    virtual public void OnDrag(PointerEventData eventData)
    {
        rawImage.rectTransform.position = cam.ScreenToWorldPoint(MousePlace());
        rawImage.rectTransform.sizeDelta = 2 * size;
    }



    virtual public void CardInvocate() {


        GameManager.Instance.money = GameManager.Instance.money - costAmount;


        GameManager.Instance.population = GameManager.Instance.population + populationAmount;
        GameManager.Instance.population = GameManager.Instance.population * populationMultiplier;

        GameManager.Instance.money = GameManager.Instance.money + moneyAmount;
        GameManager.Instance.money = GameManager.Instance.money * moneyMultiplier;

        GameManager.Instance.happiness = Mathf.Clamp01(GameManager.Instance.happiness + happinessAmount/100);
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
    public bool IsCardPlaced()
    {
        Debug.Log(GameManager.Instance.gameplayActive);
        if (GameManager.Instance.gameplayActive == true)
        {
            viewPortCardPosition = cam.WorldToViewportPoint(rawImage.rectTransform.position);
            Debug.Log(viewPortCardPosition.y);

            if (viewPortCardPosition.y > 0.5f)
            {
                Destroy(gameObject);//w dalszym etapie zamiana/dodanie na animacje

                GameManager.Instance.Hl.UsedCard(idCard);
                Rm.EndOfTheRound();
                return true;
            }
            else return false;
        }
        return false;
    }


    virtual public void BeginDRAG()
    {
        isDragged = true;
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
        isDragged = false;
        
    }
}
