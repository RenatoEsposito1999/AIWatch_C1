using UnityEngine;

/*
 * each window and handle have a "tag" which is a number value, from 0 to 4:
 * 0 -> corridor window
 * 1 ... 4 -> cvprlab windows from left to rightù
 * The animations are all titled:
 * WindowOpenX
 * WindowCloseX
 * handleRotationX
 * handleRotationCloseX
 * where x is the tag.
 * All this was done to avoid writing further code, rather with a string 
 * manipulation we concatenate name + X that is equal to the tag.
 */
public class WindowController : MonoBehaviour
{
    private handleController _handleController;
    private string _openPath = "WindowOpen";
    private string _closePath = "WindowClose";
    private string _tag;
    private bool isOpen;
    public bool state
    {
        set{ this.isOpen = value; }
        get { return this.isOpen; }
    }

    private Animator _myAnim = null;

    public void Start()
    {
        isOpen = false;
        _myAnim = GetComponent<Animator>();
        _handleController = GetComponentInChildren<handleController>();
        _tag = gameObject.tag;
    }

    public void Open()
    {
        _openPath += _tag;
        _handleController.open(_tag);
        _myAnim.Play(_openPath);
        isOpen = true;
        restoreState();
    }

    public void Close()
    {
        _closePath += _tag;
        _handleController.close(_tag);
        _myAnim.Play(_closePath);
        isOpen = false;
        restoreState();
    }

    private void restoreState()
    {
        _openPath = "WindowOpen";
        _closePath = "WindowClose";
}
}
