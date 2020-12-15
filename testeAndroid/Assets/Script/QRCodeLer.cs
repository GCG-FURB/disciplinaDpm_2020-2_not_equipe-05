using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRCodeLer : MonoBehaviour
{
    [SerializeField] private Texture2D qrCodeTexture;
    [SerializeField] private RawImage qrCodeRawImage;
    [SerializeField] private Text qrCode_Resultado;

    public void LerQRcode()
    {
        try
        {
            Texture2D qrCodeTexture = qrCodeRawImage.texture as Texture2D;
            IBarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(qrCodeTexture.GetPixels32(),qrCodeTexture.width,qrCodeTexture.height);
            if (result != null)
            {
                qrCode_Resultado.text = result.Text;
                Debug.Log("qrCode_Resultado: " +result.Text);
            }
        }
        catch (System.Exception ex) { Debug.LogWarning(ex.Message); }
    }

}
