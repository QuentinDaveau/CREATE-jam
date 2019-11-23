using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{
    public float execTime = 5f;

    protected Animation animationPlayer;

    void Start()
    {
        animationPlayer = gameObject.GetComponent<Animation>();
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 1, transform.localPosition.z);
    }

    public virtual void Enable() 
    { 
        StartCoroutine(SpawnDelay());
    }

    public void Disable() 
    { 
        animationPlayer.Play("Disabling");
    }

    void OnMouseDown()
    {
        PointerDown();
    }

    void OnMouseUp()
    {
        PointerUp();
    }

    void OnMouseDrag()
    {
        PointerDrag();
    }

    void OnMouseUpAsButton()
    {
        PointerClick();
    }

    void OnMouseEnter()
    {
        HoverEnter();
    }

    void OnMouseExit()
    {
        HoverLeave();
    }

    public virtual void HoverEnter() {}

    public virtual void HoverLeave() {}

    public virtual void PointerDown() {}

    public virtual void PointerUp() {}

    public virtual void PointerClick() {}

    public virtual void PointerDrag() {}

    public void Activated()
    {
        FindObjectOfType<GameDirector>().ModuleActivated(this);
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(0f, .5f));
        animationPlayer.Play("Enabling");
    }
}
