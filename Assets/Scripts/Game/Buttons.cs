using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject _AudioBlock;
    [SerializeField] private List<GameObject> _showList, _hideList;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private List<GameObject> _scorePanelChildList;


    public void Play()
    {
        if (Time.timeScale == 1f)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            ChangeParent(_scorePanel.transform);
            ShowAndHide();
            Time.timeScale = 1f;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        ChangeParent(transform.parent);
        ShowAndHide();
    }

    public void Audio()
    {
        PlayerPrefs.SetInt("Audio", PlayerPrefs.GetInt("Audio") == 1 ? 0 : 1);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioMode>().ChangeAudioMode();
        ShowAudio();
    }

    private void OnEnable() => ShowAudio();

    private void ChangeParent(Transform newParent)
    {
        foreach (GameObject obj in _scorePanelChildList) { obj.transform.SetParent(newParent); }
    }

    private void ShowAudio()
    {
        bool isAudio = PlayerPrefs.GetInt("Audio") == 0;
        if (_AudioBlock != null) { _AudioBlock.SetActive(isAudio); }
    }

    private void ShowAndHide()
    {
        foreach (GameObject obj in _showList) { obj.SetActive(true); }

        foreach (GameObject obj in _hideList) { obj.SetActive(false); }
    }
}