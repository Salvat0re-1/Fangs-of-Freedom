using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private static Finish instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Victoria");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
