using UnityEngine;
using TMPro;
using System;

public class SubtitlesManager : MonoBehaviour
{
    [SerializeField] private SubtitleGroup[] _subtitles;
    [SerializeField] private GameObject _subObject;
    [SerializeField] private TextMeshProUGUI _subText;
    [SerializeField] private Animator _animator;

    private SubtitleGroup _currentSubtitles;

    public void StartSubtitles(string name)
    {
        _currentSubtitles = Array.Find(_subtitles, x => x.name == name);

        _subObject.SetActive(true);
        _animator.Play(_currentSubtitles.name);
    }

    public void NextDialogue(int index)
    {
        _subText.text = "<b>Рассказчик:</b> " + _currentSubtitles.subtitles[index];
    }

    public void StopDialogue()
    {
        _subText.text = "";
        _subObject.SetActive(false);
    }
}
