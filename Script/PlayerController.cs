using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpped;
    public float jumpSpped;
    public float doubleJumpSpped;
    private bool _canDoubleJump;
    private bool _isGround;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private Animator _animator;
    private bool _isOneWayPlatform;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameController.IsGamerAlive)
        {
            Run();
            Filp();
            Jump();
            CheckIsGround();
            SwitchAnimation();
            OneWayPlatformCheck();
        }
    }
    
    
    // 实现人物翻转
    private void Filp()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {   
            // 判断人物方向为右
            if (_rigidbody2D.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (_rigidbody2D.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            
        }
        
    }

    private void CheckIsGround()
    {
        _isGround = _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) || 
                    _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"))||
                    _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        _isOneWayPlatform = _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }
    
    // 跳跃 - > 二段跳
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_isGround)
            {
                _animator.SetBool("Jump",true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpped);
                _rigidbody2D.velocity = Vector2.up * jumpVel;
                _canDoubleJump = true;
            }
            else 
            {
                if (_canDoubleJump)
                {
                    {
                        _animator.SetBool("DoubleJump", true);
                        Vector2 doubelJumpVel = new Vector2(0.0f, doubleJumpSpped);
                        _rigidbody2D.velocity = Vector2.up * doubelJumpVel;
                        _canDoubleJump = false;
                    }
                }
            }
        } 
        
    }
    
    // 奔跑
    private void Run()
    {
        var moveDir = Input.GetAxis("Horizontal");
        Vector2 playVel = new Vector2(moveDir * moveSpped, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = playVel;
        
        // player 如果有x轴速度,即大于0
        bool playerHasXAxisSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("Run", playerHasXAxisSpeed);
    }

    //检测跳跃状态,切换动画
    private void SwitchAnimation()
    {
        _animator.SetBool("Idle",false);
        if (_animator.GetBool("Jump"))
        {
            if (_rigidbody2D.velocity.y < 0.0f)
            {   
                _animator.SetBool("Jump",false);
                _animator.SetBool("Fall",true);
            }
        }
        else if(_isGround)
        {
            _animator.SetBool("Fall",false);
            _animator.SetBool("Idle",true);
        }

        if (_animator.GetBool("DoubleJump"))
        {
            if (_rigidbody2D.velocity.y < 0.0f)
            {   
                _animator.SetBool("DoubleJump",false);
                _animator.SetBool("DoubleFall",true);
            }
        }
        else if(_isGround)
        {
            _animator.SetBool("DoubleFall",false);
            _animator.SetBool("Idle",true);
        }
        
    }

    private void OneWayPlatformCheck()
    {
        //if (_isGround && gameObject.layer != )
        var moveY = Input.GetAxis("Vertical");

        if (_isOneWayPlatform && moveY < -0.1f)
        {
            gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
            Invoke("ResetPlayerLayer",0.5f);
        }
    }

    private void ResetPlayerLayer()
    {
        if (!_isOneWayPlatform && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");

        }
    }
    
    
    
}
