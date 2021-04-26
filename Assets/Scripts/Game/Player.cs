using UnityEngine.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Audio settings")]
    [SerializeField] private AudioClip _dieClip;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _moveClip;
    [SerializeField] private AudioClip _eggClip;
    [SerializeField] private AudioClip _fallClip;
    [Header("Movement settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _flyingGravityScale;
    [Space]
    [SerializeField] private Sprite _deadSprite;

    [SerializeField] private StringEvent ScoreEvent;      //to update score
    [SerializeField] private BoolEvent DieEvent;          //to check a new record
    [SerializeField] private UnityEvent MovementEvent;    //to movementPS

    public int Score { get; private set; } = 0;

    public bool isGround, isPlatform, isAlive, isJump;    //ground,platform => GroundCheck.cs, alive => this.cs, jump => PlayerButtons.cs
    public float move;                                    //from PlayerButtons.cs
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private AudioClick _aClick;


    public void OnMove(float move) => this.move = move; //event PlayerButtons.cs

    public void OnJump(bool isJump) => this.isJump = isJump; //event PlayerButtons.cs

    public void SetScore(int score) //Egg.cs
    {
        Score = score;
        ScoreEvent.Invoke(this.Score.ToString());
        _aClick.AudioPlay(_eggClip);
    }

    public void MovementStop() 
    {
        _rigidbody.velocity = new Vector2(Mathf.Lerp(_rigidbody.velocity.x, 0, Time.deltaTime), _rigidbody.velocity.y);
    }

    public void Die()
    {
        if (isAlive)
        {
            _aClick.AudioPlay(_dieClip);
            _aClick.AudioPlay(_fallClip);
        }

        isAlive = false;
        _animator.enabled = false;

        GetComponent<SpriteRenderer>().sprite = _deadSprite;

        NewRecord(out bool isRecord, Score);

        DieEvent.Invoke(isRecord);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _aClick = GetComponent<AudioClick>();
    }

    private void Update()
    {
        if (isAlive)
        {
            Jump(in isJump);
            Movement(in move);
        }
        else
        {
            MovementStop();
        }
    }

    private void LateUpdate()
    {
        ActionAudio(in isJump, in isGround, in isPlatform, in move);
    }

    private void Jump(in bool isJump)
    {
        if (isJump)
        {
            _animator.SetBool("isFly", true);
            if (isGround && _rigidbody.velocity.y == 0)
            {
                _rigidbody.gravityScale = 1f;
                _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            }
            else if (!isGround && _rigidbody.velocity.y <= 0)
            {
                _rigidbody.gravityScale = _flyingGravityScale;
            }
        }
        else
        {
            _animator.SetBool("isFly", false);
            _rigidbody.gravityScale = 1f;
        }
    }

    private void Movement(in float move)
    {
        if (move != 0f)
        {
            transform.localScale = move == 1f ? new Vector2(2.2f, 2.2f) : new Vector2(-2.2f, 2.2f);

            _animator.SetBool("isMove", true);

            if (isGround && !isPlatform) { MovementEvent.Invoke(); }
        }
        else
        {
            _animator.SetBool("isMove", false);
        }

        _rigidbody.velocity = new Vector2(move * _moveSpeed, _rigidbody.velocity.y);
    }

    private void ActionAudio(in bool IsJump, in bool IsGround, in bool IsPlatform, in float Move)
    {
        if (IsJump)
        {
            _aClick.AudioPlay(_jumpClip, true);
        }
        else if (IsGround && !IsPlatform && Move != 0f)
        {
            _aClick.AudioPlay(_moveClip, true);
        }
        else
        {
            _aClick.AudioPlay(null);
        }
    }

    private void NewRecord(out bool isRecord, int score)
    {
        if (PlayerPrefs.GetInt("Record") <= score)
        {
            PlayerPrefs.SetInt("Record", score);
            isRecord = true;
        }
        else
        {
            isRecord = false;
        }
    }
}