using UnityEngine;
using System.Collections;

public class UIGrowIn : MonoBehaviour
{
    public float m_ShrinkSpeed;

    private RectTransform m_RectTransform;

    private void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
    }

    public void GrowInSelf()
    {
        StartCoroutine(_GrowIn(m_RectTransform));
    }
    public void GrowIn(RectTransform aRect)
    {
        StartCoroutine(_GrowIn(aRect));
    }

    public void ShrinkOutSelf()
    {
        StartCoroutine(_ShrinkOut(m_RectTransform));
    }
    public void ShrinkOut(RectTransform aRect)
    {
        StartCoroutine(_ShrinkOut(aRect));
    }

    IEnumerator _GrowIn(RectTransform aRect)
    {
        Vector2 increaseBy = Vector2.zero;
        float s = 0;
        

        while (aRect.anchorMax.x < 1 || aRect.anchorMax.y < 1)
        {
            s = Time.deltaTime * m_ShrinkSpeed;

            increaseBy.x = aRect.anchorMax.x < 1 ? s : 0;
            increaseBy.y = aRect.anchorMax.y < 1 ? s : 0;

            aRect.anchorMax += increaseBy;

            yield return null;
        }

        aRect.anchorMin = Vector2.zero;
        aRect.anchorMax = Vector2.one;
    }

    IEnumerator _ShrinkOut(RectTransform aRect)
    {
        Vector2 decreaseBy = Vector2.zero;
        float s = 0;

        while (aRect.anchorMax.x > 0 || aRect.anchorMax.y > 0)
        {
            s = Time.deltaTime * m_ShrinkSpeed;

            decreaseBy.x = aRect.anchorMax.x > 0 ? s : 0;
            decreaseBy.y = aRect.anchorMax.y > 0 ? s : 0;

            aRect.anchorMax -= decreaseBy;

            yield return null;
        }

        aRect.anchorMin = Vector2.zero;
        aRect.anchorMax = Vector2.zero;
    }
}