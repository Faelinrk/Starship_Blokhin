using UnityEngine;
using TMPro;
using Spaceship.Player;

namespace Spaceship.Views
{
    public class HealthView : MonoBehaviour
    {
        private string playerHealthText;
        [SerializeField] private TMP_Text HealthTextComponent;
        public string PlayerHealthText
        {
            get => playerHealthText;
            set => HealthTextComponent.text = value;
        }
        private void OnEnable()
        {
            PlayerHealth.PlayerOnHealthChanged += ChangeHealthText;
        }
        private void OnDisable()
        {
            PlayerHealth.PlayerOnHealthChanged -= ChangeHealthText;
        }

        private void ChangeHealthText(int newValue)
        {
            PlayerHealthText = newValue.ToString();
        }
    }
}

