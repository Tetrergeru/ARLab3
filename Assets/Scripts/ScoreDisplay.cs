using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterField;

    private int _counter = 0;

    public void AddPoint(string newValeu = "1")
    {
        _counterField.text = newValeu;
    }
}
