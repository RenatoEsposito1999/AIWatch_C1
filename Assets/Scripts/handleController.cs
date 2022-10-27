using UnityEngine;

//See WindoeController.cs to understand how animations works. 
public class handleController : MonoBehaviour
{
    private Animator _anim;
    private string _openPath = "handleRotation";
    private string _closePath = "handleRotationClose";
    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    public void open(string tag)
    {

        _openPath+=tag;
        _anim.Play(_openPath);
        restoreState();
    }
    public void close(string tag)
    {
        _closePath += tag;
        _anim.Play(_closePath);
        restoreState();
    }

    private void restoreState()
    {
        _openPath = "handleRotation";
        _closePath = "handleRotationClose";
}
}
