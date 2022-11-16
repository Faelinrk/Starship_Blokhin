using UnityEngine;
using TMPro;
using Spaceship.Player;

namespace Spaceship.Views
{
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text HealthTextComponent;
        public string PlayerHealthText
        {
            set => HealthTextComponent.text = value;
        }

        public void ChangeHealthText(int newValue)
        {
            PlayerHealthText = newValue.ToString();
        }
    }
}

