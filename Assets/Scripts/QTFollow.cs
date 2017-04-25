using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class QTFollow : MonoBehaviour
{
    public bool m_WillFollow;
    public AudioSource m_Audio;
    public List<RectTransform> UIBubbles;
    private RectTransform cBubble;

    private NavMeshAgent m_NavAgent;
    private Animator m_Animator;

    void Start()
    {
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();

        cBubble = UIBubbles[0];
    }

    float speed;
	void Update ()
    {
        if (!m_WillFollow)
            return;

        speed = Mathf.Clamp(Vector3.Distance(transform.position, m_NavAgent.destination), 0, 1);
        m_Animator.SetFloat("Speed", speed);
    }

    public void SetNavTargetNode(GameObject aNode)
    {
        if (!m_WillFollow)
            return;

        if(Vector3.Distance(transform.position, aNode.transform.position) < 1)
        {
            StopAndLook();
            return;
        }

        cBubble.GetComponent<UIGrowIn>().ShrinkOutSelf();
        m_NavAgent.SetDestination(aNode.transform.position);
    }

    public void EnableFollow()
    {
        m_WillFollow = true;
    }

    void StopAndLook()
    {
        StartCoroutine(_StopAndLook());
    }

    public IEnumerator _StopAndLook()
    {
        yield return new WaitForSeconds(0.1f);

        Vector3 cam = Camera.main.transform.position;
        cam.y = transform.position.y;

        transform.LookAt(cam);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if(Vector3.Distance(transform.position, m_NavAgent.destination) < 1)
                m_NavAgent.Warp(m_NavAgent.destination);

            StopAndLook();

            switch(other.gameObject.tag)
            {
                case "10x10":
                    cBubble = UIBubbles[1];
                    break;
                case "10x20":
                    cBubble = UIBubbles[2];
                    break;
                case "20x20":
                    cBubble = UIBubbles[3];
                    break;
                case "30x30":
                    cBubble = UIBubbles[4];
                    break;

                default:
                    break;
            }

            cBubble.GetComponent<UIGrowIn>().GrowInSelf();
            m_Audio.Play();
        }
    }

    public void CheckEmail(UnityEngine.UI.InputField aInput)
    {
        m_WillFollow = aInput.text.Contains("@");

        if (m_WillFollow)
            UIBubbles[0].GetComponent<UIGrowIn>().ShrinkOutSelf();
    }
}