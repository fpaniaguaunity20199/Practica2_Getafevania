using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIConfigManager : MonoBehaviour
{
    [SerializeField] Toggle soundOnOff;
    [SerializeField] Slider sliderVolume;
    [SerializeField] Button buttonSave;

    private void Start()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("volume", 1);
        soundOnOff.isOn = (PlayerPrefs.GetInt("sound", 1) == 1) ? true : false;
        //soundOnOff.isOn = (PlayerPrefs.GetInt("sound", 1) == 1);
    }

    public void Save()
    {
        //Sound on/off, volumen
        int sound = soundOnOff.isOn ? 1 : 0;
        float volume = sliderVolume.value;
        PlayerPrefs.SetInt("sound", sound);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }
    public void Jump()
    {
        Vector3 scaleVector = new Vector3(1.2f, 1.2f, 1.2f);
        buttonSave.transform.DOScale(scaleVector, 0.25f).SetLoops(-1, LoopType.Yoyo);
        //buttonSave.image.DOFade(0, 1).SetLoops(-1, LoopType.Yoyo);
        //buttonSave.image.DOBlendableColor(Color.blue, 1).SetLoops(-1, LoopType.Yoyo);
    }
    public void DeJump()
    {
        buttonSave.transform.DOKill();
        buttonSave.transform.DOScale(new Vector2(1,1), 0.25f);
    }
}
