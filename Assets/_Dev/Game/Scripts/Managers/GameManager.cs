using System;
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
            }
            catch (Exception e)
            {
                Console.WriteLine($"Game Manager Initilization Failed: {e}");
                throw;
            }
        }
    }
}
