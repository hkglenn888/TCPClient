using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Joystick joystick;
    public SkillButton skillButton;

    protected bool useSkill;

    public float rotSpeed;
    public float tankSpeed;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        skillButton = FindObjectOfType<SkillButton>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        //rigidbody.velocity = new Vector3(joystick.Horizontal * 0f, rigidbody.velocity.y, joystick.Vertical * tankSpeed);

        transform.Translate(Vector3.forward * joystick.Vertical * tankSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * joystick.Horizontal * rotSpeed * Time.deltaTime);

        if (useSkill && skillButton.Pressed)
        {
            useSkill = true;
            TankSkill();
        }


    }


    void TankSkill()
    {
        Debug.Log("Use Skill !");
    }
}
