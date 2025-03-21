using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class FlashBangThrowing : MonoBehaviour
{
    public GameObject flashbangPrefab;
    public Transform throwPoint;
    public float throwingForce;

    [SerializeField]
    private bool isAiming = false;
    [SerializeField]
    private bool isEquiped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) //press E to equip the flash grenade
        {
            isEquiped = true;
        }

        if (Input.GetKey(KeyCode.E) & isEquiped) // unequip the flash grenade
        {
            isEquiped = false;
        }
        if (Input.GetMouseButtonDown(0)) // hold down right mouse button to aim
        {
            isAiming = true;
        }
        if (Input.GetMouseButtonUp(0) & isAiming & isEquiped) //release right mouse button to throw
        {
            ThrowBlind();
            isAiming = false;
            isEquiped = false;
        }
    }

    private void ThrowBlind()
    {
        GameObject fb = Instantiate(flashbangPrefab, throwPoint.position, Quaternion.identity);
        Rigidbody rb = fb.GetComponent<Rigidbody>();

        if (rb != null )
        {
            rb.AddForce(throwPoint.forward * throwingForce, ForceMode.VelocityChange);
        }
    }
}
