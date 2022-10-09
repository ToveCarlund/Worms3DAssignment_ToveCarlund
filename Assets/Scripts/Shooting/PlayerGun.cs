using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate;

    public static PlayerGun Instance;
    private float lastTimeShot = 0;
  


    private void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool IsPlayerTurn = playerTurn.IsPlayerTurn();
            if (IsPlayerTurn)
            {
                Shoot();
                Debug.Log("PANG");
            }
        }
    }

    public void Shoot()
    {
        if (lastTimeShot + fireRate <= Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        }

    }

}
