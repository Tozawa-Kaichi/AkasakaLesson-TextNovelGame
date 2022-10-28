using TMPro;
using UnityEngine;

public class MessagePrinter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textUi = default;
    [SerializeField]
    private float _speed = 1.0F;
    [SerializeField]
    private string _message = "";
    private float _elapsed = 0; // 文字を表示してからの経過時間
    [SerializeField] private float _interval; // 文字毎の待ち時間
    
    // _message フィールドから表示する現在の文字インデックス。
    // 何も指していない場合は -1 とする。
    private int _currentIndex = -1;

    private void Start()
    {
        ShowMessage(_message);
    }

    /// <summary>
    /// 文字出力中かどうか。
    /// </summary>
    public bool IsPrinting
    {
        get
        {
            // TODO: ここにコードを書く
            if (_currentIndex + 1 < _message.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void Update()
    {
        if (_textUi is null || _message is null || _currentIndex + 1 >= _message.Length) { return; }

        _elapsed += Time.deltaTime;
        if (_elapsed > _interval)
        {
            _elapsed = 0;
            _currentIndex++;
            _textUi.text += _message[_currentIndex];
        }
    }

    public void ShowMessage(string message)
    {
        _message = message;
        _textUi.text = " ";
        _currentIndex = -1;
    }

    /// <summary>
    /// 現在再生中の文字出力を省略する。
    /// </summary>
    public void Skip()
    {
        // TODO: ここにコードを書く
        _currentIndex = _message.Length + 1;
        _textUi.text = _message;
    }
}