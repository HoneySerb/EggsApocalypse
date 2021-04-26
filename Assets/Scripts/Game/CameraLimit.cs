using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public float maxX;


    void Awake()
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray maxRay = Camera.main.ViewportPointToRay(Vector2.one);

        plane.Raycast(maxRay, out float maxHit);

        Vector3 maxVector = maxRay.GetPoint(maxHit);

        maxX = maxVector.x;
    }
}
