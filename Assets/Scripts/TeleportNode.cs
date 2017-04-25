using UnityEngine.Events;
using UnityEngine;

public class TeleportNode : RaySelectionVolume
{
    public UnityEvent OnLeave;

    [SerializeField] private GameObject m_cameraRig;

    private TeleportNodeManager m_nodeManager;

    private void Start()
    {
        m_nodeManager = FindObjectOfType<TeleportNodeManager>();
        loadedAction.AddListener(Teleport);

        if (m_cameraRig == null)
            m_cameraRig = GetRootObject(Camera.main.gameObject);
    }

    public void Teleport()
    {
        Vector3 temp = transform.position;
        temp.y = m_cameraRig.transform.position.y;
        m_cameraRig.transform.position = temp;
        m_nodeManager.ArriveAtNode(this);
    }

    public void InvokeLoadedAction()
    {
        loadedAction.Invoke();
    }

    GameObject GetRootObject(GameObject aObject)
    {
        if (aObject.transform.parent == null)
            return aObject;
        else
            return GetRootObject(aObject.transform.parent.gameObject);
    }
}
