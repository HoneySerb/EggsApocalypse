using UnityEngine;

public class AudioClick : MonoBehaviour
{
    [SerializeField] AudioClip _clip;

    private AudioSource _audioSource;


    public void AudioPlay(AudioClip clip, bool isLoop = false)
    {
        if (isLoop)
        {
            if (Time.timeScale == 1f)
            {
                _audioSource.clip = clip;
                _audioSource.loop = true;

                if (!_audioSource.isPlaying) { _audioSource.Play(); }
            }
        }
        else
        {
            _audioSource.loop = false;
            if (clip)
            {
                _audioSource.PlayOneShot(clip);
            }
            else
            {
                _audioSource.clip = null;
            }
        }
    }

    public void OnClick()
    {
        _audioSource.PlayOneShot(_clip);
    }

    private void Awake()
    {
        _audioSource = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
    }
}
