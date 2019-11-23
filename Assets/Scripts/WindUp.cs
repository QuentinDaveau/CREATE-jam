using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindUp : Module
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float maxValue = 1;

    [SerializeField]
    private Transform baseTransform;

    [SerializeField]
    private float angleToWind = 5000f;

    private Vector3 startPosition;

    private bool hasActivated = false;

    private bool firstActivation = true;

    private float windedUpAngle = 0f;

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
        
        hasActivated = false;
        windedUpAngle = 0f;

        animationPlayer.Play("WindUpEnableLight");
    }

    public void EnableDone()
    {
        base.Enable();
    }

    public override void PointerDrag()
    {
        RaycastHit hit;
        Ray vRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (hasActivated) return;
        
        if (Physics.Raycast(vRay, out hit)) 
        {
            Vector2 hitPointXY = new Vector2((hit.point - transform.position).x, (hit.point - transform.position).z);

            // Debug.Log(hitPointXY+"   "+new Vector2(Mathf.Cos(((transform.localRotation.eulerAngles.y) * Mathf.PI) / 180f), Mathf.Sin(((transform.localRotation.eulerAngles.y) * Mathf.PI) / 180f)));

            float currentAngle = Vector2.SignedAngle(new Vector2(Mathf.Cos(((transform.localRotation.eulerAngles.y) * Mathf.PI) / 180f), -Mathf.Sin(((transform.localRotation.eulerAngles.y) * Mathf.PI) / 180f)), hitPointXY);

            if(currentAngle < 0)
            {
                windedUpAngle += -currentAngle;
                transform.localRotation = Quaternion.AngleAxis(-Vector2.SignedAngle(Vector2.right, hitPointXY), Vector3.up);
                baseTransform.localRotation = Quaternion.Inverse(transform.localRotation);
                baseTransform.position = new Vector3(startPosition.x, startPosition.y + 1, startPosition.z);

                if(windedUpAngle >= angleToWind)
                {
                    Activated();
                    hasActivated = true;
                    animationPlayer.Play("WindUpDisableLight");
                }
            }
        }
    }
}
