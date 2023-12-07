using System;
using _Dev.Game.Scripts.EventSystem;
using UnityEngine;

namespace _Dev.Game.Scripts.Managers
{
    public sealed class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            InitilizeGame();
        }
        
        private void InitilizeGame()
        {
            try
            {
                //game systems initilization
                InputManager.Instance.Initialize();
                WaveManager.Instance.Initialize();
                ViewManager.Instance.Initialize();
                
                EventSystemManager.InvokeEvent(EventId.on_game_initialized);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Game Manager Initilization Failed: {e}");
                throw;
            }
        }
    }
}
