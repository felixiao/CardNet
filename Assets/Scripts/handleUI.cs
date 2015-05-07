using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class handleUI : MonoBehaviour {
    public Image image_loading;
    public float spinningSpeed;
    public float pullThreshold=1.4f;
    public ScrollRect scrollRect;
    public float loadingWaitTime=10;

    bool playLoading;
	// Use this for initialization
	void Start () {
        playLoading = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(playLoading)
            PlayLoadingAnimation();
	}
    void PlayLoadingAnimation()
    {
        if (scrollRect.verticalNormalizedPosition < pullThreshold - 0.15f)
        {
            scrollRect.verticalNormalizedPosition = pullThreshold - 0.15f;
            scrollRect.vertical = false;
        }
        image_loading.rectTransform.Rotate(new Vector3(0, 0, -spinningSpeed * Time.deltaTime));
        loadingWaitTime -= Time.deltaTime;
        if (loadingWaitTime <= 0)
        {
            playLoading = false;
            StopLoadingAnimation();
        }
    }
    void StopLoadingAnimation()
    {
        scrollRect.vertical = true;
        image_loading.gameObject.SetActive(false);
        loadingWaitTime = 10;
    }
    public void PullRefresh(Vector2 scrollVal)
    {
        if (scrollVal.y > pullThreshold)
        {
            image_loading.gameObject.SetActive(true);
            playLoading = true;
        }
    }
}
