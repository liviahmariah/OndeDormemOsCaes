using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void VoltarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
