using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Jogo fechado!"); // só aparece no editor
    }
}
