﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackedHero : MonoBehaviour, IDropHandler
{ 
    public enum HeroType
    {
        ENEMY,
        PLAYER
    }

    public HeroType Type;
    public Color NormalCol, TargetCol;

    public void OnDrop(PointerEventData eventData)
    {
        if (!GameManagerScript.Instance.IsPlayerTurn)
            return;

        CardController card = eventData.pointerDrag.GetComponent<CardController>();

        if (card &&
            card.Card.CanAttack &&
            Type == HeroType.ENEMY &&
            !GameManagerScript.Instance.EnemyFieldCards.Exists(x => x.Card.IsProvocation))
        {
            GameManagerScript.Instance.DamageHero(card, true);
        }
    }

    public void HighlightAsTarget(bool highlight)
    {
        GetComponent<Image>().color = highlight ?
            TargetCol :
            NormalCol;
    }
}
