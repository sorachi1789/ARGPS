using UnityEngine;
using System.Xml.Linq; //�d�v

public class GMLread : MonoBehaviour
{

    public TextAsset mXmlText;
    private void Start()
    {
        LoadFromText(mXmlText.text);
    }

    private void LoadFromText(string i_xmlText)
    {
        try
        {
            XDocument xml = XDocument.Parse(i_xmlText);
            XElement root = xml.Root;

            // xml�f�[�^�����O�ɕ\�������B
            //ShowData(root);

            // ���O���w�肵�Č�������ꍇ�́A���̊֐����g�����I
            var titles = root.Descendants("gml:posList");
            if (titles != null)
            {
                foreach (var title in titles)
                {
                    string nameText = title.Name.LocalName;
                    string valueText = title.Value;
                    Debug.LogFormat("name:{0}, value:{1}", nameText, valueText);
                }
            }
        }
        catch (System.Exception i_exception)
        {
            Debug.LogErrorFormat("���[�ށA����XML���͓ǂݍ��߂Ȃ������炵���B�G���[�̏ڍׂ�Y�t���Ă�����B{0}", i_exception);
        }
    }

    /// <summary>
    /// xml�̃t�@�C���p�X����ǂݍ��ޏꍇ�B
    /// </summary>
    private void LoadFromPath(string i_path)
    {
        try
        {
            XDocument xml = XDocument.Load(i_path);
            XElement root = xml.Root;

            // xml�f�[�^�����O�ɕ\�������B
            ShowData(root);

            // ���O���w�肵�Č�������ꍇ�́A���̊֐����g�����I
            var titles = root.Descendants("title");
            if (titles != null)
            {
                foreach (var title in titles)
                {
                    string nameText = title.Name.LocalName;
                    string valueText = title.Value;
                    Debug.LogFormat("name:{0}, value:{1}", nameText, valueText);
                }
            }
        }
        catch (System.Exception i_exception)
        {
            Debug.LogErrorFormat("���[�ށA����XML���͓ǂݍ��߂Ȃ������炵���B�G���[�̏ڍׂ�Y�t���Ă�����B{0}", i_exception);
        }
    }

    private void ShowData(XElement i_element)
    {
        string nameText = i_element.Name.LocalName;
        string valueText = i_element.Value;
        string atrText = string.Empty;

        // �A�g���r���[�g������ꍇ�B
        if (i_element.HasAttributes)
        {
            foreach (var attribute in i_element.Attributes())
            {
                atrText += string.Format("\t\t{0}={1}\n", attribute.Name, attribute.Value);
            }
        }

        Debug.LogFormat("name:{0}\n\tvalue:{1}\n\tattribute:\n{2}", nameText, valueText, atrText);

        // �q�m�[�h���T�����B
        foreach (var child in i_element.Elements())
        {
            ShowData(child);
        }
    }

}
