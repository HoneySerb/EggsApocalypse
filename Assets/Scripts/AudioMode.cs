using UnityEngine;

public class AudioMode : MonoBehaviour
{
    public void ChangeAudioMode()
    {
        GetAudioMode();
    }

    private void Awake()
    {
        GetAudioMode();
    }

    private void GetAudioMode() 
    {
        if (!PlayerPrefs.HasKey("Audio"))
            PlayerPrefs.SetInt("Audio", 1);

        GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Audio") == 1 ? 1f : 0f;  
    }
}
