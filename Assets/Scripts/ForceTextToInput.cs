using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTextToInput : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.InputField m_Input;
    private UnityEngine.UI.Text m_Text;

	void Start ()
    {
        m_Text = GetComponent<UnityEngine.UI.Text>();
	}
	
	void Update ()
    {
        m_Text.text = m_Input.text;
	}
}
