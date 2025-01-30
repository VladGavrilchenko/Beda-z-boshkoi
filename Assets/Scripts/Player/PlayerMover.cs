using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIsDead
{
    bool IsDead();
    void SetIsDead();
}
public interface IMove
{
    bool IsMove();
    void SetIsMove(bool isMove);

    void SetRotateCamera(Vector3 rotateVector);
}

public class PlayerMover : MonoBehaviour , IIsDead , IMove
{
    [SerializeField] private GameObject UIGameObject;
    [SerializeField] private Camera moveCamera;
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speedScale = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float turnSpeed = 90f;
    [SerializeField] private bool isCanMove;

    private Animator animatorController;
    private const float gravityScale = 9.8f;
    private float verticalSpeed;
    private float mouseX;
    private float mouseY;
    private float currentAngleX = 0f;
    private float currentAngleY = 0f;
    private Vector3 direction;
    private bool isDead;
    private IPause iPause;


    public void SetIsDead()
    {
        isDead = true;
        isCanMove = false;
        FindObjectOfType<DeadController>().SetDead();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public bool IsMove()
    {
        return isCanMove;
    }
    public void SetIsMove(bool isMove)
    {
        isCanMove=isMove;
    }


    void Start()
    {
        animatorController = GetComponentInChildren<Animator>();
        iPause = FindAnyObjectByType<PauseController>().GetComponent<IPause>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(isCanMove == false || iPause.IsPause())
        {
        }


        if (isCanMove && isDead == false && iPause.IsPause() == false)
        {
            RotateCharacter();
            MoveCharacter();
        }
        else
        {
            Fall();
        }
    }

    public void SetRotateCamera(Vector3 rotateVector)
    {
        cameraHolder.transform.localEulerAngles = rotateVector;
    }

    private void RotateCharacter()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0f, mouseX * turnSpeed * Time.deltaTime, 0f));
        currentAngleY += mouseX * turnSpeed * Time.deltaTime;
        currentAngleX += -mouseY * turnSpeed * Time.deltaTime;
        currentAngleX = Mathf.Clamp(currentAngleX, -30f, 40f);

        SetRotateCamera(new Vector3(currentAngleX, 0f, 0f));
    }

    private void MoveCharacter()
    {

        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        direction = transform.TransformDirection(direction) * speedScale;


        if (controller.isGrounded)
        {
            verticalSpeed = 0f;
            if (Input.GetButton("Jump"))
            {
                verticalSpeed = jumpForce;
            }
        }
        else
        {
            verticalSpeed -= gravityScale * Time.deltaTime;
        }

        direction.y = verticalSpeed;
        controller.Move(direction * Time.deltaTime);

    }

    private void Fall()
    {
        if (!controller.isGrounded)
        {
            verticalSpeed -= gravityScale * Time.deltaTime;
            direction.y = verticalSpeed;
            controller.Move(direction * Time.deltaTime);
        }
    }

    public void SetSpeedScale(float speedScale)
    {
        this.speedScale = speedScale;
    }
}
