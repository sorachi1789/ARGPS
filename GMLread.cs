using UnityEngine;
using System.Xml.Linq; //重要

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

            // xmlデータをログに表示するよ。
            //ShowData(root);

            // 名前を指定して検索する場合は、この関数を使おう！
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
            Debug.LogErrorFormat("うーむ、このXML情報は読み込めなかったらしい。エラーの詳細を添付しておくよ。{0}", i_exception);
        }
    }

    /// <summary>
    /// xmlのファイルパスから読み込む場合。
    /// </summary>
    private void LoadFromPath(string i_path)
    {
        try
        {
            XDocument xml = XDocument.Load(i_path);
            XElement root = xml.Root;

            // xmlデータをログに表示するよ。
            ShowData(root);

            // 名前を指定して検索する場合は、この関数を使おう！
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
            Debug.LogErrorFormat("うーむ、このXML情報は読み込めなかったらしい。エラーの詳細を添付しておくよ。{0}", i_exception);
        }
    }

    private void ShowData(XElement i_element)
    {
        string nameText = i_element.Name.LocalName;
        string valueText = i_element.Value;
        string atrText = string.Empty;

        // アトリビュートがある場合。
        if (i_element.HasAttributes)
        {
            foreach (var attribute in i_element.Attributes())
            {
                atrText += string.Format("\t\t{0}={1}\n", attribute.Name, attribute.Value);
            }
        }

        Debug.LogFormat("name:{0}\n\tvalue:{1}\n\tattribute:\n{2}", nameText, valueText, atrText);

        // 子ノードも探そう。
        foreach (var child in i_element.Elements())
        {
            ShowData(child);
        }
    }

}
