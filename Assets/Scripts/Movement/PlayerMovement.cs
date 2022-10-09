using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 60;

    public int maxMoves = 2500;
    public int currentMovement;

    public MovementBar movement;

    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;

    

    private void Start()
    {
        currentMovement = maxMoves;
        movement.SetMaxMovement(maxMoves);


    }

    private void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
                
            }
            if (currentMovement >= 1)
            {
                if (Input.GetAxis("Vertical") != 0)
                {
                    transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
                    --currentMovement;
                    movement.SetMovement(currentMovement);
                }
            }


            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }

            if (Input.GetButtonUp("Enter"))
            {
                TurnManager.GetInstance().TriggerChangeTurn();
                currentMovement = 5000;
            }                    
          
        }

      
    }

    private void Jump()
    {

        rb.AddForce(Vector3.up * 500f);
    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result = Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        return result;
    }

    
}
