using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 **IMPORTANT*
 *During an animation it is good to disable the possibility 
 *of movement of the avatar that activated the animation
 * To do this use PlayerMoviment.enableMoviment() / disableMoviment()
 */
public class DoorController : MonoBehaviour
{
    private Animator _myDoor = null;
    private bool _isOpen = false;
    private GameObject _firstLeaf;
    private AvatarController _avatar;
    private string pathOpen = "DoorOpen";
    private string pathClose = "DoorClose";
    private void Start()
    {
        //GameObject tmp = GameObject.Find(gameObject.name);
        //_firstLeaf = GameObject.Find("firstLeafCVPRLAB");
        //_avatar = GameObject.Find("BaseMesh_Anim").GetComponent<AvatarController>();
        //_myDoor = tmp.GetComponent<Animator>();
        /*
        if (_myDoor == null)
            throw new System.Exception("inDoorController.cs myDoor is null");
        */
        _myDoor = gameObject.GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        _avatar = other.gameObject.GetComponent<AvatarController>();
        if (!other.CompareTag("Player"))
            return;

        if (!_isOpen)
            Open();
        else
            Close();
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        //It should close 
        if (_isOpen)
            Close();
        else//It should open
            Open();
    }
    

    private void Open()
    {
        string path = pathOpen + _myDoor.tag.ToString();
        _myDoor.Play(path, 0, 0.0F);
        _isOpen = true;
    }

    private void Close()
    {
        string path = pathClose + _myDoor.tag.ToString();
        _myDoor.Play(path, 0, 0.0F);
        _isOpen = false;
    }

 

}
