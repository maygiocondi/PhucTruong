using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    static public TestPlayerController ins;
    public GameStates gameStates;
    Rigidbody2D rb;
    public Animator anim;

    // true khi tiếp xúc mặt đất, được gán bằng tia Raycat2D bắn từ nhân vật theo hướng xuống ở hàm CheckSurrounding
    bool isGrounded;

    // !=0 khi velocity.x của nhân vật thay đổi, đk để xét animation Walk, được gán trong hàm checkMovemenDirection
    bool isWalking;

    // xác định hướng xoay của model, nếu (movementInputDirection < 0 && isFacingRight = true) thì lật model lại và ngược lại, nằm trong hàm CheckMomentDirection
    bool isFacingRight = true;

    // Kiểm tra nhân vật có chạm tường hay ko, bằng một tia Raycast bắn từ Model theo hướng tranform.right ở hàm CheckSurrouding
    bool isTouchingWall;

    // Kiểm tra nhân vật có đang trượt tường hay ko, với đk (chạm tường && velocity.y < 0) ở hàm CheckIfWallSliding
    bool isWallSliding;

    // biến Số_lần_nhảy_còn_lại được gán bằng biến AmountOfJump khi game Start, mỗi lần Jump sẽ -= 1 ở hàm Jump, và sẽ xét lại = AmountOfJump khi (chạm đất && velocity.y <= 0) ở hàm CheckSurrounded
    int amountOfJumpLeft;

    // biến này gán giá trị Input người dùng nhập vào ở hàm CheckInput
    float movementInputDirection;

    // biến này check xem player có được nhả hay ko
    bool canJump;



    //Model chứa animator và Renderrer
    public Transform Model;

    // Tốc độ move
    public float MovementSpeed;

    // Lực nhảy
    public float JumpForce;

    // Độ dài tia Raycast kiểm tra mặt đất
    public float GroundCheckDistance;

    // độ dài tia Raycast kiểm tra tường
    public float WallCheckDistance;

    // velocity.y sẽ nhân với số này khi trượt tường, ban đầu để là 0.1
    public float WallSlidingSpeed;

    // số lần nhảy cho phép
    public int AmountOfJump;


    void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameStates = GameStates.Playing;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = Model.GetComponent<Animator>();
        amountOfJumpLeft = AmountOfJump;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.ins.isDead)
        {
            gameStates = GameStates.GameOver;
        }
        if (gameStates == GameStates.GameOver)
        {

        }

        if (gameStates == GameStates.Playing)
        {
            CheckInput();
            ApplyMovement();
            CheckMovementDirection();
            CheckSurroundings();
            UpdateAnimations();
            CheckIfWallSliding();
            CheckIfCanJump();
        }
    }

    // Hàm này xác định hướng nhân vật
    void CheckMovementDirection()
    {
        // Khi model xoay phải mà momentInput < 0 thì xoay model lại
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        // Khi nhân vật di chuyển thì bật lên, ngược lại tắt
        if (rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    void Flip()
    {
        //xoay Model đồng thời gán lại isFacing
        isFacingRight = !isFacingRight;
        Model.transform.Rotate(0, 180, 0);
    }

    void CheckInput()
    {

        movementInputDirection = Input.GetAxisRaw("Horizontal");


        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void ApplyMovement()
    {
        rb.velocity = new Vector2(movementInputDirection * MovementSpeed, rb.velocity.y);

        // khi isWallSliding = true, thì tốc độ trượt xuống sẽ giảm theo biến WallSlidingSpeed
        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * WallSlidingSpeed);
        }
    }

    void Jump()
    {
        rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
        amountOfJumpLeft--;
        if (amountOfJumpLeft < 0)
        {
            amountOfJumpLeft = 0;
        }
    }

    // hàm này kiểm tra một số thứ quanh player
    void CheckSurroundings()
    {
        // kiểm tra chạm đất
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, 1 << 8);

        // Kiểm tra chạm tường
        isTouchingWall = Physics2D.Raycast(Model.transform.position, Model.transform.right, WallCheckDistance, 1 << 8);
    }

    // hàm này kiểm tra xem nhân vật có đang trượt tường hay ko
    void CheckIfWallSliding()
    {
        // nếu nhân vật ko chạm đất và chạm tường và đang di chuyển theo hướng xuống thì true
        if (!isGrounded && isTouchingWall && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    // hàm này kiểm tra khi nào Player có thể nhảy
    void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0 || isWallSliding)
        {
            amountOfJumpLeft = AmountOfJump;
        }

        // khi Số_lần_nhảy_còn_lại <= 0 thì ko được phép nhảy
        if (amountOfJumpLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    // Hàm này UPdate Animation
    void UpdateAnimations()
    {
        // biến isWalking thay đổi khi giá trị rb.velocity.x thay đổi trong hàm CheckMoment direction, khi biến = true thì bật animation walk
        anim.SetBool("isWalking", isWalking);

        // Animation Jump được chia thành 2 trạng thái Jump1 Jump2 ở animation Blend Tree Jump/Fall. Khi nhân vật ko chạm đất và ko chạm tường thì từ mọi trạng thái sẽ chuyển qua -> Jump.
        anim.SetBool("isGrounded", isGrounded);

        // Trong Blend Tree gán Jump1/yVelocity = 1, Jump2/yVelocity = -1. Khi nhân vật nhảy lên thì sẽ có animation Jump1, khi rơi xuống sẽ là Jump2
        anim.SetFloat("yVelocity", rb.velocity.y);

        // trạng thái khi trượt tường, nếu isWallSliding = flase sẽ trở về trạng thái Jump
        anim.SetBool("isWallSliding", isWallSliding);
    }

    // Hàm này vẽ ra các tia giả lập các giá trị raycast để dễ chỉnh sửa, ko cần gọi
    void OnDrawGizmos()
    {
        // Tia check Ground
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - GroundCheckDistance, transform.position.z));

        // Tia checkWall
        Gizmos.DrawLine(Model.position, new Vector3(Model.position.x + WallCheckDistance, Model.transform.position.y, Model.transform.position.z));
    }

    public enum GameStates
    {
        Playing,
        GameOver
    }
}
