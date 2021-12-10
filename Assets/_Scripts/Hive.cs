using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive :AllCardClass
{
    override public void CardInvocate()
    {
        float value = (GameManager.Instance.fear + GameManager.Instance.loyalty) / 2;
        GameManager.Instance.fear = value;
        GameManager.Instance.loyalty = value;
    }


}
