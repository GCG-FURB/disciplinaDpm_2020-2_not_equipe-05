using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRCodeGerar : MonoBehaviour
{
    [SerializeField] private RawImage qrCode_Resultado_Image;
   
    public void GerarQR() 
    {
      Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

     Texture2D generateQR(string text)
    {
        RectTransform rt = qrCode_Resultado_Image.rectTransform;
        var encoded = new Texture2D((int)rt.rect.width, (int)rt.rect.height);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }
    
    qrCode_Resultado_Image.texture = generateQR("http://tecedu.inf.furb.br");
 }

}

