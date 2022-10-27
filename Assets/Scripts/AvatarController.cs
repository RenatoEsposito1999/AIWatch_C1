using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using Confluent.Kafka;


public class AvatarController : MonoBehaviour
{
    private Animator _anim = null;
    private GameObject _myAvatar;
    private Vector3 _position; //Used in AnimationGesture
    private Vector3 _lastPosRecived; // Used in AnimationGesture
    private Vector3 _pos; // Used for updateEachSecond and Key pressed function function 

    private Material RED;
    private Material WHITE;

    Renderer rend;

    private bool _stopCorutine;
    private bool startedCorutine;

    private float _y; //Used for rotation during keyboard movement

    private int _index;
    private Thread tr;


    private Frame _deserializedClass;
    public readonly static Queue<Action> ExecuteOnMainThread = new Queue<Action>();

    private void Start()
    {
        CameraController.init();
        FileManager._init(Application.dataPath);

        _deserializedClass = new Frame();
        _lastPosRecived = _position = transform.position;

        _index = 0;

        _stopCorutine = false;
        startedCorutine = false;
        _myAvatar = GameObject.Find("BaseMesh_Anim");
        _anim = _myAvatar.GetComponent<Animator>();


        rend = _myAvatar.GetComponentInChildren<Renderer>();
        rend.enabled = true;

        ConsoleDisplayInstructions();

        tr = new Thread(ConsumeData);
        tr.Priority = System.Threading.ThreadPriority.Highest;
        tr.Start();

        RED = (Material)Resources.Load("Materials/RED");
        WHITE = (Material)Resources.Load("Materials/Color_TRUEWHITE");


    }

    private void Update()
    {
        while (ExecuteOnMainThread.Count > 0)
        {
            ExecuteOnMainThread.Dequeue().Invoke();
        }
        if (!startedCorutine)
        {
            startedCorutine = true;
            StartCoroutine(AnimationGesture());
        }

        if (_stopCorutine)
        {
            StopCoroutine(Simulation());
            _stopCorutine = false;// For next frame update.
        }

        MovementGesture();
   
        // ---------------------- TEST ------------------------------------
        //the animation have to be start when we detect the
        //interaction beetween avatar and window.
        //But for test the opening of the windows is possible by pressing buttons 1 to 5
        WindowManager(); //See WindowController.cs to understand how window animations work
        //Change camera view.
        if (Input.GetKeyDown(KeyCode.C))
            cPressed();

        // (Y) Jump - (U) Return from jump
        if (Input.GetKeyDown(KeyCode.Y))
            yPressed();
        if (Input.GetKeyDown(KeyCode.U))
            uPressed();
    }

    private void MovementGesture()
    {
        float speed = 1.5f;
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        if (xDirection != 0 || zDirection != 0)
        {
            transform.rotation = SetRotation(xDirection, zDirection);
            Vector3 moveDirection = new Vector3(xDirection * Time.deltaTime, 0.0f, zDirection * Time.deltaTime);
            transform.position += moveDirection * speed;
        }
    }

    private Quaternion SetRotation(float xDirection, float zDirection)
    {
        Quaternion target;
        if (zDirection < 0 && zDirection != 0)
            _y = -180f;
        else if (zDirection > 0 && zDirection != 0)
            _y = 0f;
        else if (xDirection < 0 && xDirection != 0)
            _y = -90f;
        else if (xDirection > 0 && xDirection != 0)
            _y = 90f;
        return target = Quaternion.Euler(transform.rotation.x, _y, transform.rotation.z); ;

    }

    //JUMP  
    private void yPressed()
    {
        _pos = new Vector3(transform.position.x, 1.04f, transform.position.z);
        transform.position = _pos;

    }
    //RETURN FROM JUMP
    private void uPressed()
    {
        _pos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        transform.position = _pos;
    }
    //To change the camera view
    private void cPressed()
    {
        CameraController.changeCamera();
    }

    public void startWalk()
    {
        _anim.Play("Root|Walk_loop");
    }

    public void stopWalk()
    {
        _anim.Play("Idle");
    }



    /*
     * This function allows you to open the 
     * windows by pressing keys 1 to 5
     */
    private void WindowManager()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WindowController cc = GameObject.Find("WindowRotation1").GetComponent<WindowController>();
            if (cc.state) //if state is true(=OPEN) you have to close
                cc.Close();
            else
                cc.Open(); 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WindowController cc = GameObject.Find("WindowRotation1 (1)").GetComponent<WindowController>();
            if (cc.state) //if state is true(=OPEN) you have to close
                cc.Close();
            else
                cc.Open();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WindowController cc = GameObject.Find("WindowRotation1 (2)").GetComponent<WindowController>();
            if (cc.state) //if state is true(=OPEN) you have to close
                cc.Close();
            else
                cc.Open();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WindowController cc = GameObject.Find("WindowRotation1 (3)").GetComponent<WindowController>();
            if (cc.state) //if state is true(=OPEN) you have to close
                cc.Close();
            else
                cc.Open();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            WindowController cc = GameObject.Find("WindowRotation1 (4)").GetComponent<WindowController>();
            if (cc.state) //if state is true(=OPEN) you have to close
                cc.Close();
            else
                cc.Open();
        }

    }

    //Deserializes the object read by kafka
    private void Deserialization()
    {
        _deserializedClass = JsonUtility.FromJson<Frame>(FileManager.ReadFromFile());
    }

    private void ConsoleDisplayInstructions()
    {
        Debug.Log("Press 8 to save position into file (for simulation)");
        Debug.Log("Press from 1 to 5 to open windows");
        Debug.Log("Press C to change the camera view");
        Debug.Log("Press Y to jump");
        Debug.Log("Press U to return on the plane (after jump)");
    }

    //Allows you to move by reading a deserialized object
    IEnumerator Simulation()
    {
        Vector3 pos;
        Quaternion rot;
        List<People> peopleList = _deserializedClass.getPeopleList();

        foreach (People p in peopleList)
        {
            foreach(Skeleton s in p.GetSkeletonList())
            {
                if(s.pointID == 8)
                {
                    //Questo ' in futuro va modificato con la s.y
                    //Attualmente se uso y l'avatar è in aria
                    pos = new Vector3(s.x,0,s.z);
                    rot = new Quaternion(s.x_rotation, s.y_rotation, s.z_rotation, s.w_rotation);
                    transform.position = pos;
                    transform.rotation = rot;
                    anomalyDetection(s.anomaly);
                    _stopCorutine = true;
                }
            }
        }

        //Se ci sono problemi con l'animazione potrebbe essere questa istruzione
        //forse va tra le parentesi dei for
        yield return null;
    }

    // This coroutine check every 0.8 seconds the position to understand if avatar have to
    // start animation walk or not.
    IEnumerator AnimationGesture()
    {

        while (true)
        {
            _position = transform.position;
            if (_position != _lastPosRecived)
            {
                startWalk();
                _lastPosRecived = _position;
            }
            else
            {
                stopWalk();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ConsumeData()
    {

        ConsumerConfig conf = new ConsumerConfig
        {
            GroupId = "consumer-group-",
            BootstrapServers = "192.168.160.195:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var cons = new ConsumerBuilder<Ignore, string>(conf).Build())
        {
            cons.Subscribe("topic_unity");
            while (true)
            {
                var msg = cons.Consume();
                FileManager.WriteOnFile(msg.Message.Value);
                Deserialization();
                ExecuteOnMainThread.Enqueue(() =>
                {
                    StartCoroutine(Simulation());
                });
            }
        }
    }

    private void anomalyDetection(int detected)
    {

        if (detected == 1)
            rend.sharedMaterial = RED;
        else if (rend.sharedMaterial == RED)
            rend.sharedMaterial = WHITE;
    }

    private void OnApplicationQuit()
    {
        tr.Abort();
    }

}
