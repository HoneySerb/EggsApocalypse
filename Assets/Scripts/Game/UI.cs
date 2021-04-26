using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _textScore;
    [SerializeField] private GameObject _buttonPause;
    [SerializeField] private List<GameObject> _listButtons;
    [Header("Death Frame")]
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _frame;
    [SerializeField] private Text _frameTextScore, _frameTextRecord, _frameText;

    private Animator _frameTextAnim;
    private Player _player;


    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _frameTextAnim = _frameText.GetComponent<Animator>();    
    }

    public void OnDead(bool isRecord)
    {
        _scorePanel.SetActive(true);
        SetFrameText(in isRecord);
        _textScore.SetActive(false);
        _buttonPause.SetActive(false);
        _frame.SetActive(true);
    }

    private void SetFrameText(in bool isRecord)
    {
        _frameTextScore.text = string.Format("Score: {0}", _player.Score.ToString());
        _frameTextRecord.text = string.Format("Record: {0}", PlayerPrefs.GetInt("Record").ToString());
        if (isRecord)
        {
            _frameText.text = "Good job, Dude!";
            _frameTextAnim.SetBool("isRecord", true);
        }
        else
        {
            _frameText.text = "U silly duck!";
            _frameTextAnim.SetBool("isRecord", false);
        }
    }
}
