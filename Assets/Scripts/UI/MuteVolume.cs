using Unity;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Audio;



class MuteVolume : MonoBehaviour
{
    public Sprite muteImage; 
    public Sprite unmuteImage; 
    public Image buttonImage; 
    bool isMute = false;
    private void Start()
    {
        UpdateButtonImage();
    }
    public void ToggleMute()
    {

        isMute = !isMute;

        AudioManager.Instance.Mute();

        
        UpdateButtonImage();
    }
    private void UpdateButtonImage()
    {
        if (isMute)
        {
            buttonImage.sprite = muteImage; 
        }
        else
        {
            buttonImage.sprite = unmuteImage;
        }
    }

}