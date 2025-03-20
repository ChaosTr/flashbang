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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAiming = true;
        }
        if (Input.GetMouseButtonUp(0) & isAiming)
        {
            ThrowBlind();
            isAiming = false;
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
