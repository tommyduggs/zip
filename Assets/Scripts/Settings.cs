using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    private bool gettingKey = false;
    private static readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    [SerializeField] private TextMeshProUGUI jumpKeyText;
    [SerializeField] private TextMeshProUGUI floatKeyText;
    [SerializeField] private TextMeshProUGUI torpedoKeyText;
    [SerializeField] private TextMeshProUGUI slideKeyText;
    private enum Move {
        None,
        Jump,
        Float,
        Torpedo,
        Slide
    };
    private Move currentMove = Move.None;
    private Dictionary<Move, string> MOVE_NAMES = new Dictionary<Move, string>(){
        {Move.Jump, "Jump"},
        {Move.Float, "Float"},
        {Move.Torpedo, "Torpedo"},
        {Move.Slide, "Slide"}
    };
    private Dictionary<Move, TextMeshProUGUI> MOVE_TEXT_OBJS;

    // Start is called before the first frame update
    void Start()
    {
        MOVE_TEXT_OBJS = new Dictionary<Move, TextMeshProUGUI>(){
            {Move.Jump, jumpKeyText},
            {Move.Float, floatKeyText},
            {Move.Torpedo, torpedoKeyText},
            {Move.Slide, slideKeyText}
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(gettingKey && currentMove != Move.None)
        {
            if(Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKey(keyCode)) {
                        PlayerPrefs.SetInt(MOVE_NAMES[currentMove],(int)keyCode);
                        TextMeshProUGUI textToChange = MOVE_TEXT_OBJS[currentMove];
                        textToChange.text = keyCode.ToString();
                        
                        gettingKey = false;
                        currentMove = Move.None;
                        break;
                    }
                }
            }
        }
    }

    public void SetJumpKey()
    {
        EnterKeyMode(Move.Jump);
    }

    public void SetFloatKey()
    {
        EnterKeyMode(Move.Float);
    }

    public void SetTorpedoKey()
    {
        EnterKeyMode(Move.Torpedo);
    }

    public void SetSlideKey()
    {
        EnterKeyMode(Move.Slide);
    }

    private void EnterKeyMode(Move move)
    {
        gettingKey = true;
        currentMove = move;
    }
}
