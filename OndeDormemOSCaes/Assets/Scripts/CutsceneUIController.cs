using UnityEngine;

public class CutsceneUIController : MonoBehaviour
{
    public GameObject startButton;

    public void ShowStartButton()
    {
        startButton.SetActive(true);
    }
}
