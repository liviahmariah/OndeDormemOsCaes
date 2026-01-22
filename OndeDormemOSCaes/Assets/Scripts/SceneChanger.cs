using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName = "Jogo";

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
