using UnityEngine;

public class AudioDestroyBlock : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1) { Destroy(GameObject.FindGameObjectsWithTag(gameObject.tag)[1]); }
    }
}
