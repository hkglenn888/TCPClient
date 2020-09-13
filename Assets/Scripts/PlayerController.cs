using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camTransform;
    public Joystick joystick;
    public SkillButton skillButton;
    public bool skillButtonOnclick;


    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        skillButton = FindObjectOfType<SkillButton>();
        skillButtonOnclick = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ClientSend.PlayerShoot(camTransform.forward);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ClientSend.PlayerThrowItem(camTransform.forward);
        }

        if (skillButtonOnclick)
        {
                ClientSend.UseSkill(true);
            skillButtonOnclick = false;
        }
    }

    private void FixedUpdate()
    {
        //SendInputToServer();
        //SendInputToServer2();
    }

    /// <summary>Sends player input to the server.</summary>
    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.Space)
        };

        ClientSend.PlayerMovement(_inputs);
    }

    //private void SendInputToServer2()
    //{
    //    float[] _inputs = new float[]
    //    {
    //        joystick.Horizontal,
    //        joystick.Vertical
                     
    //    };

    //    ClientSend.PlayerMovement2(_inputs);

    //}

    public void ClickSkillButton()
    {
        skillButtonOnclick = true;
    }


}
