using UnityEngine;

/// <summary>
/// Makes object look at the main Camera
/// </summary>
 
public class LookAtCamera : MonoBehaviour
{
    public bool LookAway;
    Transform m_view;

    private void Start()
    {
        m_view = Camera.main.transform;
    }

    private void Update()
    {
        if (LookAway)
            transform.LookAt(transform.position + m_view.forward);

        else
            transform.LookAt(m_view);
    }
}
