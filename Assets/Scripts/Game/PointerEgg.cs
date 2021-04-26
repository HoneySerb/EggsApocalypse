using UnityEngine;

public class PointerEgg : MonoBehaviour
{
    private void LateUpdate()
    {
        if (GameObject.Find("Player").GetComponent<Player>().isAlive)
        {
            Vector3 dir = GetEggPosition() - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = Vector3.forward * angle;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private Vector3 GetEggPosition()
    {
        return GameObject.FindGameObjectWithTag("Egg").transform.position;
    }
}
