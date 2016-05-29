using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

using com.google.zxing.qrcode;

public class qrCam : MonoBehaviour {
    public GameObject RenderPlane;
    public CameraChange Changer;
    public string qr=" ";
	private WebCamTexture camTexture;
	private Thread qrThread;

	private Color32[] c;
	private sbyte[] d;
	private int W, H, WxH;
	private int x, y, z;
	
	void OnEnable () {
		if(camTexture != null) {
			camTexture.Play();
			W = camTexture.width;
			H = camTexture.height;
			WxH = W * H;
		}
	}
	
	void OnDisable () {
		if(camTexture != null) {
			camTexture.Pause();
		}
	}
	
	void OnDestroy () {
		qrThread.Abort();
		camTexture.Stop();
	}
	
	void Start () {
		camTexture = new WebCamTexture();
        RenderPlane.GetComponent<Renderer>().material.mainTexture = camTexture;
        camTexture.Play();

		OnEnable();
		
		qrThread = new Thread(DecodeQR);
		qrThread.Start();



	}
	
	void Update () {
		c = camTexture.GetPixels32();

	}
	
	void DecodeQR () {
		while(true) {
			try {
				d = new sbyte[WxH];
				z = 0;
				for(y = H - 1; y >= 0; y--) {
					for(x = 0; x < W; x++) {
						d[z++] = (sbyte)(((int)c[y * W + x].r) << 16 | ((int)c[y * W + x].g) << 8 | ((int)c[y * W + x].b));
					}
				}

                qr = new QRCodeReader().decode(d, W, H).Text;

                if (qr == "ajf5")
                {
                    //Navigation nav = GameObject.Find("Navigator").GetComponent<Navigation>();
                    //nav.start = new Vector3(-6.99f, 0.21f, 1.39f);
                    Changer.changeCamera();
                    }

                if (qr == "ays4")
                {
                    //Navigation nav = GameObject.Find("Navigator").GetComponent<Navigation>();
                    //nav.start = new Vector3(30.34f, 0.21f, 23.36f);
                    Changer.changeCamera();
                }

                if (qr == "uhsn")
                {
                    //Navigation nav = GameObject.Find("Navigator").GetComponent<Navigation>();
                    //nav.start = new Vector3(55.0f, 0.21f, 2.06f);
                    Changer.changeCamera();
                }

                RenderPlane.SetActive(false);
               
                
			}
			catch {
				continue;
			}
		}
	}

   
}
