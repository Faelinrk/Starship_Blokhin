using System;

namespace Spaceship.Player
{
    public class PlayerComponent : IDisposable
    {
        protected PlayerModel playerModel;
        public PlayerComponent()
        {
            PlayerController.OnPlayerInitialized += HandlePlayerInitialized;
        }

        private void HandlePlayerInitialized(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }
        public void Dispose()
        {
            PlayerController.OnPlayerInitialized -= HandlePlayerInitialized;
        }
    }
}
