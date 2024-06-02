using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TDS.Scripts.Player
{
    public class PlayerPoints : MonoBehaviour
    {
        [SerializeField] private int _points = 0;
        [SerializeField] private Text _pointsText;

        private PlayerManager playerManager;

        public void Initialize(PlayerManager manager)
        {
            playerManager = manager;
            UpdatePointsText();
        }

        public void AddPoints(int amount)
        {
            _points += amount;
            playerManager.UpdateAttackSpeed(_points);
            UpdatePointsText();
        }

        private void UpdatePointsText()
        {
            _pointsText.text = "Points " + _points;
        }
    }
}
