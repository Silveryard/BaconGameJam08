using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour{

    public float MovementSpeed;
    public float RotationSpeed;

    public bool CanMoveLeft;
    public bool CanMoveRight;
    public bool CanMoveUp;
    public bool CanMoveDown;

    private Rigidbody _rigidbody;

    protected void Awake(){
        _rigidbody = GetComponent<Rigidbody>();

        CanMoveLeft = true;
        CanMoveRight = true;
        CanMoveUp = true;
        CanMoveDown = true;
    }

    protected void Update(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 && !CanMoveRight)
            horizontal = 0;
        if (horizontal < 0 && !CanMoveLeft)
            horizontal = 0;

        if (vertical > 0 && !CanMoveUp)
            vertical = 0;
        if (vertical < 0 && !CanMoveDown)
            vertical = 0;

        Vector3 vector = new Vector3(horizontal * MovementSpeed * Time.deltaTime, 0, vertical * MovementSpeed * Time.deltaTime);

        transform.position += vector;

        float rotation = Input.GetAxis("Rotate");

        Vector3 rVector = new Vector3(0, rotation*RotationSpeed*Time.deltaTime, 0);

        transform.Rotate(rVector);
    }
}