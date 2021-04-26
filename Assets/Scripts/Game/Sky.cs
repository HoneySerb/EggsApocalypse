using UnityEngine;

public class Sky : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("RedValue")) { PlayerPrefs.SetFloat("RedValue", 0f); }
        if (!PlayerPrefs.HasKey("GreenValue")) { PlayerPrefs.SetFloat("GreenValue", 0f); }
        if (!PlayerPrefs.HasKey("BlueValue")) { PlayerPrefs.SetFloat("BlueValue", 255f); }
    }

    private void Start()
    {
        byte r = System.Convert.ToByte(PlayerPrefs.GetFloat("RedValue"));
        byte g = System.Convert.ToByte(PlayerPrefs.GetFloat("GreenValue"));
        byte b = System.Convert.ToByte(PlayerPrefs.GetFloat("BlueValue"));
        GetComponent<SpriteRenderer>().color = new Color32(r, g, b, 255);
    }
}
