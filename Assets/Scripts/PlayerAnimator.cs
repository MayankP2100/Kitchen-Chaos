using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Variables
    private const string IS_WALKING = "IsWalking";

    private Animator animator;

    [SerializeField] private Player player;


    public void Awake() => animator = GetComponent<Animator>();


    private void Update() => animator.SetBool(IS_WALKING, player.IsWalking());
}
