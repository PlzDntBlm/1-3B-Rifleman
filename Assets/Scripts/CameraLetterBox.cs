using UnityEngine;

public class CameraLetterBox : MonoBehaviour
{
    public Camera backgroundCam;
    public Camera mainCam;
    public float targetAspectRatio = 1f;

    private float cachedScreenWidth = -1;
    private float cachedScreenHeight = -1;
    private void Start()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
            if (mainCam == null)
                mainCam = GetComponent<Camera>();
        }
        if (backgroundCam == null)
        {
            foreach (var cam in Camera.allCameras)
            {
                if (cam != mainCam)
                {
                    backgroundCam = cam;
                    break;
                }
            }
            if (backgroundCam == null)
            {
                backgroundCam = new GameObject("BackgroundCam").AddComponent<Camera>();
            }
            backgroundCam.depth = mainCam.depth - 1;
        }
    }

    private void Update()
    {
        float w = Screen.width;
        float h = Screen.height;
        if (w == cachedScreenWidth && h == cachedScreenHeight)
        {
            return;
        }
        cachedScreenWidth = w;
        cachedScreenHeight = h;

        float a = w / h;
        Rect r;
        if (a > targetAspectRatio)
        {
            float tw = h * targetAspectRatio;
            float o = (w - tw) * 0.5f;
            r = new Rect(o, 0, tw, h);
        }
        else
        {
            float th = w / targetAspectRatio;
            float o = (h - th) * 0.5f;
            r = new Rect(0, o, w, th);
        }
        mainCam.pixelRect = r;
    }
}