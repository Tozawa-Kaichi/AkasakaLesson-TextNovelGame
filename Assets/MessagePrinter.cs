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
    private float _elapsed = 0; // ������\�����Ă���̌o�ߎ���
    [SerializeField] private float _interval; // �������̑҂�����
    
    // _message �t�B�[���h����\�����錻�݂̕����C���f�b�N�X�B
    // �����w���Ă��Ȃ��ꍇ�� -1 �Ƃ���B
    private int _currentIndex = -1;

    private void Start()
    {
        ShowMessage(_message);
    }

    /// <summary>
    /// �����o�͒����ǂ����B
    /// </summary>
    public bool IsPrinting
    {
        get
        {
            // TODO: �����ɃR�[�h������
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
    /// ���ݍĐ����̕����o�͂��ȗ�����B
    /// </summary>
    public void Skip()
    {
        // TODO: �����ɃR�[�h������
        _currentIndex = _message.Length + 1;
        _textUi.text = _message;
    }
}