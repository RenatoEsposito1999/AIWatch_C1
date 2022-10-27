using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TransparentRoofController : MonoBehaviour
{ 
    private Ray _ray;
    private RaycastHit _hit;
    private bool _isTransparent = false;
    private GameObject _currentObject = null; 

    private void Update()
    {
        StartCoroutine(_TransparentRoofController()); 
    }


    // Update is called once per frame
    IEnumerator _TransparentRoofController()
    {
        while (true) {
            if (CameraController._currentCam.name == "AvatarCam")
            {
                //emits a ray from the camera
                _ray = new Ray(transform.position, transform.forward);
                //if ray hits somethings
                if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
                {
                    //check if ray hits roof that was not already hits on the previous call
                    if (_hit.collider.gameObject.tag == "Roof" && _hit.collider.gameObject != _currentObject)
                    {
                        _hit.collider.gameObject.SetActive(false);
                        _isTransparent = true;
                        if (_currentObject != null)
                            _currentObject.SetActive(true);
                        _currentObject = _hit.collider.gameObject;
                    }
                    else if (_hit.collider.gameObject.tag == "Roof" && _hit.collider.gameObject == _currentObject)
                    {
                        if (!_isTransparent)
                        {
                            _isTransparent = true;
                            _hit.collider.gameObject.SetActive(false);
                        }
                    }


                }
             
            }
            else
            {
                if (_currentObject != null) {
                    _currentObject.SetActive(true);
                    _isTransparent = false;
                    _currentObject = null;
                }
                
            }
            yield return new WaitForSeconds(1.4f);
        }
        
        
    }// Stop coroutine
}
