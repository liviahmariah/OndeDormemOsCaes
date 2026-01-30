using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        Scene cena = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Jogo");
    }

    public void VoltarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicial");
    }
}
