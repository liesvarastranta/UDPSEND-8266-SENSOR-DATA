using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class manager : MonoBehaviour
{

    public int Remoteport = 25666;

    [SerializeField]
    private string IPAdressNodeMCU;

    public UDPSendData sender = new UDPSendData();

    public string datafromnode;

    void Start()
    {
        //sender.init("192.168.1.9", Remoteport, 25666);
        sender.init(IPAdressNodeMCU, Remoteport, 25666);
        sender.sendString("Hello from Start. " + Time.realtimeSinceStartup);

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
            sender.sendString("This should be delivered");

        if (sender.newdatahereboys)
        {
            datafromnode = sender.getLatestUDPPacket();
        }
    }

    public void OnDisable()
    {
        sender.ClosePorts();
    }

    public void OnApplicationQuit()
    {
        sender.ClosePorts();
    }

}