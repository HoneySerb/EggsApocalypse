using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _leftBorder, _rightBorder;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _movementTime;
    [SerializeField] private float _yUp;
    [SerializeField] private float _yDispersion;

    private CameraLimit _cameraLimit;
    private GameObject _player;

    private float _minSleepZone, _maxSleepZone;
    private float _yPlayerDefaultPosition;
    private float _yCameraStart;


    void Start()
    {
        _leftBorder = GameObject.Find("leftBorder");
        _rightBorder = GameObject.Find("rightBorder");

        _cameraLimit = GetComponent<CameraLimit>();
        _player = GameObject.Find("Player");

        _minSleepZone = GetSleepZone(_leftBorder.transform.position.x, _cameraLimit.maxX);
        _maxSleepZone = GetSleepZone(_rightBorder.transform.position.x, _cameraLimit.maxX);

        _yPlayerDefaultPosition = _player.transform.position.y;

        _yCameraStart = transform.position.y;
    }

    void Update()
    {
        IsMove(out bool move, out bool jump);
        MoveToPlayer(in _movementTime, in move, in jump);
    }

    private void MoveToPlayer(in float movementTime, in bool move, in bool jump)
    {
        Vector3 currentPosition = transform.position;

        float xTarget = GetTargetPositionX(in move);
        float yTarget = GetTargetPositionY(in jump);

        Vector3 targetPosition = new Vector3(xTarget, yTarget, currentPosition.z);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * movementTime);
    }

    private void IsMove(out bool move, out bool jump)
    {
        if (_player.transform.position.x > _minSleepZone && _player.transform.position.x < _maxSleepZone)
        {
            move = true;
        }
        else
        {
            move = false;
        }

        if (_player.transform.position.y > _yPlayerDefaultPosition + _yDispersion)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
    }

    private float GetTargetPositionX(in bool move)
    {
        if (move)
        {
            return _player.transform.position.x;
        }
        else
        {
            if (_player.transform.position.x > 0)
            {
                return GetSleepZone(_rightBorder.transform.position.x, _cameraLimit.maxX);
            }
            else
            {
                return GetSleepZone(_leftBorder.transform.position.x, _cameraLimit.maxX);
            }
        }
    }

    private float GetTargetPositionY(in bool jump)
    {
        return jump == true ? _yCameraStart + _yUp : _yCameraStart;
    }

    private float GetSleepZone(float xObject, float xCameraSize)
    {
        return xObject > 0 ? xObject - xCameraSize : xObject + xCameraSize;
    }
}
