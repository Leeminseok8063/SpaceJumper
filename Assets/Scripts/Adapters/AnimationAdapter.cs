using UnityEngine;

public class AnimationAdapter : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;  
    Vector2 currentDir = Vector2.zero;
    private int isMoveHash;
    private int isBoostHash;
    private int isLadderHash;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        isMoveHash = Animator.StringToHash("isMove");
        isBoostHash = Animator.StringToHash("isBoost");
        isLadderHash = Animator.StringToHash("isLadder");
    }
    private void FlipCheck()
    {
        Vector2 tempVal = PlayerCore.Instance.MovementAdapter.MoveDir;
        
        if (tempVal.x != 0)
        {
            currentDir = tempVal;
            spriteRenderer.flipX = currentDir.x < 0 ? true : false;
        }
    }
    private void AnumUpdate()
    {
        animator.SetBool(isMoveHash, PlayerCore.Instance.MovementAdapter.isMovement);
        animator.SetBool(isBoostHash, PlayerCore.Instance.MovementAdapter.isBoost);
    }

    private void Update()
    {
        FlipCheck();
        AnumUpdate();
    }

}
