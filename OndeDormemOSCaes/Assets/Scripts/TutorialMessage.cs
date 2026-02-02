using UnityEngine;
using TMPro;

public class TutorialMessage : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float duration = 3f;

    void Start()
    {
        StartCoroutine(ShowMessage());
    }

    System.Collections.IEnumerator ShowMessage()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        text.gameObject.SetActive(false);
    }
}
