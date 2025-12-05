using UnityEngine;
using UnityEngine.EventSystems;

public class ImageButtonGlow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject glow;

    public void OnPointerDown(PointerEventData eventData)
    {
        glow.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        glow.SetActive(false);
    }
}
