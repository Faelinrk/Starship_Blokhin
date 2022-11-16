using Spaceship.Controllers;
using Spaceship.Interfaces;
using Spaceship.Views;

namespace Spaceship.Player
{
    public sealed class PlayerInitializer
    {
        private UnityStarter _unityStarter;
        public PlayerView Player;
        public IDamageble PlayerHealth;
        public IMovable PlayerMove;
        public DamagebleController DamagebleController;
        public HealthView HealthView;

        public PlayerInitializer(UnityStarter unityStarter)
        {
            _unityStarter = unityStarter;
            _unityStarter.EventOnAwake += Initialize;
        }

        private void Initialize()
        {
            Player = new PlayerView();
            PlayerMove = new PlayerMove(Player.PlayerRigidbody);
            PlayerHealth = new PlayerHealth(Player);
            DamagebleController = new DamagebleController(PlayerHealth, HealthView);
        }

        ~PlayerInitializer()
        {
            _unityStarter.EventOnAwake -= Initialize;
            DamagebleController.Dispose();
        }
    }
}