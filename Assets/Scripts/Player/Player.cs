using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess
// ReSharper disable once CheckNamespace
public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed;
    public float jumpForce;
    public int jumpTime;
    public int jumpCount;
    public bool isJump;
    public bool isGround;
    public LayerMask ground;
    public Vector2 offsetLeft;
    public Vector2 offsetRight;

    public bool IsJump
    {
        get => isJump;
        set => isJump = value;
    }

    public bool IsGround
    {
        get => isGround;
        set => isGround = value;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        ground = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Move();
    }

    private void CheckInput()
    {
        // get input
        float x = Input.GetAxis("Horizontal");
        bool y = Input.GetButtonDown("Jump");
        // move
        _rigidbody2D.velocity = new Vector2(x * speed, _rigidbody2D.velocity.y);
        // flip
        if (x > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (x < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        // jump
        if (y)
        {
            if (IsJump) return;
            if (jumpCount == jumpTime) return;
            IsJump = true;
        }
    }

    private void Move()
    {
        if (!IsJump) return;
        IsJump = false;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        jumpCount++;
    }

    private void GroundCheck()
    {
        RaycastHit2D raycastHit2DLeft = Raycast(offsetLeft, Vector2.down, 1, ground);
        RaycastHit2D raycastHit2DRight = Raycast(offsetRight, Vector2.down, 1, ground);
        if (raycastHit2DLeft || raycastHit2DRight)
            IsGround = true;
        else
            IsGround = false;
        if (IsGround && _rigidbody2D.velocity.y < 0.01f)
            jumpCount = 0;
    }

    /// <summary>
    /// offset 偏移量 direction 射线方向 distance 射线长度 layer 判断图层
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    private RaycastHit2D Raycast(Vector2 offset, Vector2 direction, float distance, LayerMask layer)
    {
        Vector2 position = transform.position; // 游戏角色位置
        RaycastHit2D hit = Physics2D.Raycast(offset + position, direction, distance, layer);
        Color color = hit ? Color.red : Color.green;
        Vector2 testRay = new Vector2(direction.x, distance);
        Debug.DrawRay(offset + position, testRay, color);
        return hit;
    }
}