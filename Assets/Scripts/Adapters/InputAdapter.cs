using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAdapter : MonoBehaviour
{
    PlayerCore player;
    private void Start()
    {
        player = GetComponent<PlayerCore>();
    }

    public void OnMove(InputValue val)
    {
        PlayerCore.Instance.MovementAdapter.Movement(val.Get<Vector2>());
    }

    public void OnJump(InputValue val)
    {
        PlayerCore.Instance.MovementAdapter.Boost(val.Get<Vector2>());
    }
}
