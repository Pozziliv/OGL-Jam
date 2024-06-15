using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private int _indexOfScene;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(_indexOfScene);
    }
}