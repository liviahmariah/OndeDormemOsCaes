using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip somBotao;

    public void TocarSom()
    {
        audioSource.PlayOneShot(somBotao);
    }
}
