using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField]
    private Vector2 startPosition;
    [SerializeField]
    private float moveSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        void LookAtMouse() {
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3. forward);
        }

        void WASDMovement() {
            Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            // Debug.Log(moveInput);
            transform.position += (moveInput * moveSpeed * Time.fixedDeltaTime);
        }

        LookAtMouse();
        WASDMovement();

    }


}
