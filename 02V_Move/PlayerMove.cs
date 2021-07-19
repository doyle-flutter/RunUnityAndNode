using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum C
{
    L,
    R
}

public class PlayerMove : MonoBehaviour
{
    public Button LeftBtn;
    public Button RightBtn;
    private float _endFloor = 5.0f;

    private BoxCollider2D box;
    private bool MoveCheck = false;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        this.LeftBtn.onClick.AddListener(() => this.Move(C.L));
        this.RightBtn.onClick.AddListener(() => this.Move(C.R));
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            MoveCheck = true;
            this.transform.position += new Vector3(this.transform.position.x < 0 ? 2.0f : -2.0f, 0, 0);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        MoveCheck = false;
    }

    private void Move(C cc)
    {
        if (MoveCheck)
        {
            this.transform.position += Vector3.zero;
        }
        else {
            if (cc == C.L)
            {
                if (this.transform.position.x <= -1 * _endFloor)
                {
                    this.transform.position += Vector3.zero;
                    return;
                }
                this.transform.position += Vector3.left;
            }
            if (cc == C.R)
            {
                if (this.transform.position.x > this._endFloor)
                {
                    this.transform.position += Vector3.zero;
                    return;
                }
                this.transform.position += Vector3.right;
            }
        }

    }
    

}
