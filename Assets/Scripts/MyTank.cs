using UnityEngine;
using System.Collections;

public class MyTank : MonoBehaviour
{
    public JoyStick MyStick;
    public GameButton Abutton, Bbutton, Cbutton;

    ParticleSystem bullet;

    public bool SlerpMode = true;


	void Start()
	{
        bullet = GetComponentInChildren<ParticleSystem>();
        bullet.enableEmission = false;
	}
	
	void Update()
	{
	    if (MyStick.isClick)
        {
            transform.Translate(Vector3.forward * 4.0f * Time.deltaTime);

            if (SlerpMode)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(MyStick.Degree, Vector3.up), Time.deltaTime * 2.0f); // 스틱 방향으로 서서히 회전
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(MyStick.Degree, Vector3.up); // 스틱 방향으로 바로 회전
            }
        }
        bullet.enableEmission = Abutton.isClick;
	}

    void JumpTank()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 600f);
    }
}
