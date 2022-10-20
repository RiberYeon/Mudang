using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed = 2.0f;
    public GameManger manager;
    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 무빙
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        // 버튼 이동
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        // 수직 운동
        if (hDown)
        {
            isHorizonMove = true;
        }
        else if (vDown || hUp)
        {
            isHorizonMove = false;
        }

        // Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("IsChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("IsChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("IsChange", false);
        }

        // 방향
        if (vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        // 스캔
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
        {
            // Debug.Log("이것은 NPC입니다.");
            manager.Action(scanObject);
        }
        if (Input.GetKeyDown(KeyCode.Z) && scanObject != null)
        {
            Destroy(scanObject);
        }
    }
    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec*speed;

        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
