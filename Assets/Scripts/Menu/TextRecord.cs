using UnityEngine.UI;
using UnityEngine;

public class TextRecord : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Record").ToString();
    }
}