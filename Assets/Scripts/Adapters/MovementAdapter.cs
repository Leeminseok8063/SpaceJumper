using Assets.Scripts.Adapters;
using Assets.Scripts.Data;
using UnityEngine;

public class MovementAdapter : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private EnergeManagement energe;
    private Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } }

    private float boostVelocity = 0f;
    private float moveVelocity = 0f;
    
    public bool isMovement = false;
    public bool isBoost = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        PlayerData data = PlayerCore.Instance.PlayerData;
        energe = PlayerCore.Instance.EnergeManagement;
        boostVelocity = data.boostVelocity;
        moveVelocity = data.moveVelocity;
    }

    private void FixedUpdate()
    {
        MoveUpdate();
        FlagUpdate();      
    }

    public void Boost(Vector2 val)
    {      
        moveDir.y = val.y;
    }
    public void Movement(Vector2 val)
    {
        moveDir.x = val.x;
    }

    private void FlagUpdate()
    {
        isBoost = moveDir.y != 0 ? true : false;
        if (!isBoost) { isMovement = moveDir.x != 0 ? true : false; }
        else { isMovement = false; }
    }
    private void MoveUpdate()
    {
        if (!energe.CanUseEnerge)
        {
            moveDir.y = 0f;
        }
        rb2d.velocity = new Vector2(moveDir.x * moveVelocity,
            moveDir.y == 0 ? rb2d.velocity.y : moveDir.y * boostVelocity);
    }
}
