using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    private enum TALK_STATE {
        NORMAL,
        QUEST_YES,
        QUEST_NO,
    }
    
    [SerializeField] private GameObject   talk_box;
    [SerializeField] private bool         has_quest                 = false;
    [SerializeField] private float        raider_radius             = 3f;
    [SerializeField] private List<string> normal_talk_content       = new List<string>( );
    [SerializeField] private List<string> quest_yes_talk_content    = new List<string>( );
    [SerializeField] private List<string> quest_no_talk_content     = new List<string>( );

    private GameObject  m_talk_box;
    private int         m_page          = 0;
    private bool        m_is_talking    = false;
    private TALK_STATE  m_talk_state    = TALK_STATE.NORMAL;

    public GameObject TalkBox   { get { return m_talk_box;      } }
    public bool       HasQuest  { get { return has_quest;       } }
    public bool       IsTalking { get { return m_is_talking;    } }

    void Start( ) {
        init( );
    }

    void init( ) {
        //他のObjectとinterationのために'Raider'を作る
        GameObject raider = new GameObject( "Raider" );
        raider.transform.SetParent( gameObject.transform );
        raider.transform.position   = transform.position;
        raider.transform.tag        = "NPC";
        raider.AddComponent<SphereCollider>( );
        raider.GetComponent<SphereCollider>( ).isTrigger    = true;
        raider.GetComponent<SphereCollider>( ).radius       = raider_radius;
    }

    public void StartTalking( ) {
        m_talk_box = Instantiate( talk_box ) as GameObject;
        m_talk_box.GetComponentInChildren<Text>( ).text = normal_talk_content[ m_page++ ];

        m_is_talking = true;
    }

    void IfTalkFinishedDoInit( int page_end ) {
        if ( m_page > page_end - 1 ) {
            Destroy( m_talk_box );
            m_is_talking = false;
            m_page = 0;
        }
    }

    public void NextPage( ) {
        switch ( m_talk_state ) {
            case TALK_STATE.NORMAL:
                IfTalkFinishedDoInit( normal_talk_content.Count );
                m_talk_box.GetComponentInChildren<Text>( ).text = normal_talk_content[ m_page++ ];
                break;
            case TALK_STATE.QUEST_YES:
                IfTalkFinishedDoInit( quest_yes_talk_content.Count );
                m_talk_box.GetComponentInChildren<Text>( ).text = quest_yes_talk_content[ m_page++ ];
                break;
            case TALK_STATE.QUEST_NO:
                IfTalkFinishedDoInit( quest_no_talk_content.Count );
                m_talk_box.GetComponentInChildren<Text>( ).text = quest_no_talk_content[ m_page++ ];
                break;
        }
    }
}
