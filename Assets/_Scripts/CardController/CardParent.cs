using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class CardParent : MonoBehaviour
{
    public float costCard;

    public float populationCard;

    public float moneyCard;

    public float happinessCard;

    public float loyaltyCard;

    public float fearCard;

    public float educationCard;

    public float crimeCard;

    public float wealthCard;

    public float taxCard;

    public TextMesh textCard;

    public Texture textureCard;

   public  RawImage rawImage;



    public bool isClicked = false, isInvaded = false;

    public Vector3 clickedd = new Vector3(0f, -300f, 0f);
    public Vector3 startPosition = new Vector3(0f, -440f, 0f);
    public Vector3 placeOfMouse, worldPosition;
    public  Vector3 centerConst = new Vector3(960f, 540f, 0f);



    /*virtual  void CardInvocate() {

        Gamemanager.Instance.cost = Gamemanager.cost * costCard;

        Gamemanager.Instance.population = Gamemanager.population * populationCard;

        Gamemanager.Instance.money; = Gamemanager.money; *moneyCard; ;

        Gamemanager.Instance.happiness; = Gamemanager.happiness; *happinessCard; ;

        Gamemanager.Instance.loyalty; = Gamemanager.loyalty; *loyaltyCard;

        Gamemanager.Instance.fear; = Gamemanager.fear; *fearCard;

        Gamemanager.Instance.education; = Gamemanager.education; *educationCard;

        Gamemanager.Instance.crime; = Gamemanager.crime; *crimeCard;

        Gamemanager.Instance.wealth; = Gamemanager.wealth; *wealthCard;

        Gamemanager.Instance.tax; = Gamemanager.tax; *taxCard;
    }*/




    virtual public void OnMouseDrag()
    {
        mouseDRAG();

    }
    virtual public void mouseDRAG()
    {
        isClicked = true;
        isInvaded = true;
    }


    virtual public void OnMouseEnter()
    {
        mouseENTER();
    }
    virtual public void mouseENTER()
    {
        isInvaded = true;
    }

    private void OnMouseExit()
    {
        MouseEXIT();
    }


    virtual public void MouseEXIT()
    {
        isClicked = false;
        isInvaded = false;
    }




    virtual public void Update()
    {
        updateR();
    }

    virtual public void updateR()
    {
        //Object is invaded but it is not clicked
        //MOUSE ENTER
        if (isInvaded == true && isClicked == false)
        {
            rawImage.rectTransform.position = centerConst+clickedd;
            rawImage.rectTransform.sizeDelta = new Vector2(300, 300);
        }

        //Object is invaded but also is also clicked
        //MOUSE DRAG
        if (isInvaded == true && isClicked == true)
        {
            rawImage.rectTransform.sizeDelta = new Vector2(300, 300);
            rawImage.rectTransform.position = new Vector3(mousePlace().x, mousePlace().y - (rawImage.rectTransform.sizeDelta.y/3), mousePlace().z);   
        }

        //Object is NOT invaded and it is NOT clicked
        //MouseEXIT
        if (isInvaded == false && isClicked == false)
        {
            isItPlaced();

            rawImage.rectTransform.sizeDelta = new Vector2(100, 100);

            rawImage.rectTransform.position = centerConst+startPosition; 

        }
    }


    //Cheking if the card is places in the center
    public void isItPlaced()
    {
        if (rawImage.rectTransform.position.y > 700)
        {
            Destroy(gameObject);
        }
    }




    //Returning mouse position to be able to move cards
    virtual public Vector3 mousePlace()
    {
        Vector3 placeOfMouse = Input.mousePosition;
        placeOfMouse.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(placeOfMouse);


        return placeOfMouse;
    }

}
