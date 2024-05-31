using UnityEngine;
using UnityEngine.UI;

namespace TDS.Scripts.Player
{
    public class PlayerUI : MonoBehaviour
    {
        private Slider playerHealthSlider;

        private void Awake()
        {
            playerHealthSlider = GetComponent<Slider>();
        }

        public void SetMaxHealth(int health)
        {
            playerHealthSlider.maxValue = health;
            playerHealthSlider.value = health;
        }

        public void SetHealth(int health)
        {
            playerHealthSlider.value = health;
        } 
    }

}

