using _Dev.Game.Scripts.UI.Views.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Dev.Game.Scripts.UI.Views
{
    public class MainView : View
    {
        [SerializeField] private Button m_restartButton;

        protected override void OnEnable()
        {
            m_restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            m_restartButton.onClick.RemoveAllListeners();
            base.OnDisable();
        }
    }
}