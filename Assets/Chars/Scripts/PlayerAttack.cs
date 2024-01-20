using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private GameInputActions playerControls;
    private InputAction attack;

    private Animator AnimPlayer;

    [Header("Attack Player")]
    private bool inAttack = false;
    public float AtttackDuration;

    public GameObject HitBoxAttack;
    private Vector2 initPosHitBoxAttack;

    private void Awake()
    {
        playerControls = new GameInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        AnimPlayer = GetComponent<Animator>();
        initPosHitBoxAttack = HitBoxAttack.transform.localPosition;
    }

    private void OnEnable()
    {
        attack = playerControls.Player.Attack;
        attack.Enable();
        attack.performed += OnAttack;
    }

    private void OnDisable()
    {
        attack.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        if (!inAttack)
        {
            FlipHitBox();
            StartCoroutine(TimeAnimAttack());
        }
    }

    void FlipHitBox()
    {
        Vector2 posHitBox = initPosHitBoxAttack;

        if (GetComponent<SpriteRenderer>().flipX)
        {
            posHitBox = new Vector2(-initPosHitBoxAttack.x, posHitBox.y);
        }
        else
        {
            posHitBox = new Vector2(initPosHitBoxAttack.x, posHitBox.y);
        }

        HitBoxAttack.transform.localPosition = posHitBox;
        StartCoroutine(TimeAnimAttack());
    }

    private IEnumerator TimeAnimAttack()
    {
        inAttack = true;
        AnimPlayer.SetBool("InAttack", true);

        yield return new WaitForSeconds(AtttackDuration);

        inAttack = false;
        AnimPlayer.SetBool("InAttack", false);
    }
}
