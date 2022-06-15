using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Password : MonoBehaviour
{
    [SerializeField] InputField field;
    [SerializeField] Text text;
    [SerializeField] string pw = "aaa";


    // Start is called before the first frame update
    void Start()
    {
        field.text = "";
        text.text = "��й�ȣ�� �Է��ϼ���";
    }

    // Update is called once per frame
    void Update()
    {
        if (field.text == pw)
        {
            text.text = "���Ƚ��ϴ�";
        }
        else
        {
            if(field.text.Length > 6)
            {
                field.text = "";
            }
            text.text = "��й�ȣ�� �Է��ϼ���";
        }
    }
}
