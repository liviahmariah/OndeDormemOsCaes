using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Image[] hearts;
    public Sprite heartFull;
    public Sprite heartEmpty;

    public void UpdateHearts(int life)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < life ? heartFull : heartEmpty;
        }
    }
}
