using UnityEngine.UI;
using UnityEngine;

public class ImageHolder : MonoBehaviour {

    [SerializeField]
    Texture[] Images;
    [SerializeField]
    Material Mat1,Mat2;
    [SerializeField]
    int Number = 0;

    public void NextImage()
    {
        Number++;
        if (Number > Images.Length - 1)
        {
            Number = 0;
        }

            Mat1.mainTexture = Images[Number];
            Mat2.mainTexture = Images[Number];
        
        

    }
    public void PreviousImage()
    {
        Number--;
        if (Number < 0)
        {
            Number = Images.Length - 1;
        }

            Mat1.mainTexture = Images[Number];
            Mat2.mainTexture = Images[Number];
        
       
    }

}
