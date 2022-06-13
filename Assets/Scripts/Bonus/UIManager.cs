
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ball
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _panelWin;

        [SerializeField] private GameObject _panelLose;

//Delegate Write
        private void Start()
        {
            HeroMove.WinDelegate += Win;
            HeroMove.LoseDelegate += Lose;
        }

        public void Win()
        {
            _panelWin.SetActive(true);
        }

        public void Lose()
        {
            _panelLose.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

//Delegate UnWrite
        private void OnDestroy()
        {
            HeroMove.WinDelegate -= Win;
            HeroMove.LoseDelegate -= Lose;
        }
    }
}