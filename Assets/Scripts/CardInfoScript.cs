﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScript : MonoBehaviour
{
    public CardController CC;

    public Image Logo;
    public TextMeshProUGUI Name, Attack, Defense, Manacost;
    public GameObject HideObject, HighlightedObj;
    public Color NormalCol, TargetCol, SpellTargetCol;

    public void HideCardInfo()
    {
        HideObject.SetActive(true);
        Manacost.text = "";
    }

    public void ShowCardInfo()
    {
        HideObject.SetActive(false);
        
        Logo.sprite = CC.Card.Logo;
        Logo.preserveAspect = true;
        Name.text = CC.Card.Name;

        RefreshData();
    }

    public void RefreshData()
    {
        Attack.text = CC.Card.Attack.ToString();
        Defense.text = CC.Card.Defense.ToString();
        Manacost.text = CC.Card.Manacost.ToString();
    }

   public void HighlightCard(bool highlight)
    {
        HighlightedObj.SetActive(highlight);
    }


    public void HighlightManaAvaliability(int currentMana)
    {
        GetComponent<CanvasGroup>().alpha = currentMana >= CC.Card.Manacost ?
            1 :
            .5f;
    }

    public void HighlightAsTarget(bool highlight)
    {
        GetComponent<Image>().color = highlight ?
            TargetCol :
            NormalCol;
    }

    public void HighlightAsSpellTarget(bool highlight)
    {
        GetComponent<Image>().color = highlight ?
            SpellTargetCol :
            NormalCol;
    }
}
