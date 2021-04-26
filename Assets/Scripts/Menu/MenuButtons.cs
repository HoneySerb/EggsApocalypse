using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private BoolEvent _recordEvent;


    public void BannerRecord()
    {
        bool value = gameObject.transform.GetChild(1).gameObject.activeSelf ? false : true;
        _recordEvent.Invoke(value);
    }

    public void Play() => SceneManager.LoadScene("Game");

    public void Shop() => SceneManager.LoadScene("Shop");
}
