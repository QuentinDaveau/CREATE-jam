using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Module
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float maxValue = 1;

    [SerializeField]
    private Transform baseTransform;

    private Vector3 startPosition;

    private bool hasActivated = false;

    private bool firstActivation = true;

    public override void Enable()
    {
        if(firstActivation)
        {
            startPosition = baseTransform.position;
            firstActivation = false;
        }

        transform.localRotation = Quaternion.identity;
        baseTransform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        baseTransform.localRotation = Quaternion.identity;
        base.Enable();
        hasActivated = false;
    }

    public override void PointerDrag()
    {
        RaycastHit hit;
        Ray vRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(vRay, out hit)) 
        {
            float dist = (transform.position.z - hit.point.z)/maxValue;

            if (dist > 0.83f)
            {
                dist = 0.83f;

                if(!hasActivated)
                {
                    Activated();
                    hasActivated = true;
                }
            }

            if (dist < -0.83f)
            {
                dist = -0.83f;
            }


            transform.localRotation = Quaternion.AngleAxis(90f - (90f * Mathf.Asin(-dist)), Vector3.right);
            baseTransform.localRotation = Quaternion.Inverse(transform.localRotation);
            baseTransform.position = new Vector3(startPosition.x, startPosition.y + 1, startPosition.z);

            Debug.Log(transform.localRotation.eulerAngles.x);
        }
    }
}
