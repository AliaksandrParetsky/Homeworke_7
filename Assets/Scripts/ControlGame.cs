using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    [SerializeField] private Transform sectionPrefab;
    [SerializeField] private Transform playerPrefab;
    [SerializeField] private Transform parentPrefabs;

    private Transform instance;
    private float offsetScaleSectionPrefab = 29.65f;
    private float positionSection = 0.0f;

    private List<Transform> sections = new List<Transform>();
    private Transform player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = Instantiate(sectionPrefab, Vector3.zero, Quaternion.identity, parentPrefabs);

            player = Instantiate(playerPrefab, new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);

            sections.Add(instance);
        }
    }

    private void OnEnable()
    {
        Trigger.triggerEvent += Trigger_triggerEvent;
    }

    private void Trigger_triggerEvent(Trigger.Direction direction)
    {
        if(direction == Trigger.Direction.Up)
        {
            SetOffsetScaleSectionPrefab(false);
        }
        if(direction == Trigger.Direction.Down)
        {
            SetOffsetScaleSectionPrefab(true);
        }
    }

    private void SetOffsetScaleSectionPrefab(bool direction)
    {
        if (direction)
        {
            positionSection = positionSection + -offsetScaleSectionPrefab;
        }
        if (!direction)
        {
            positionSection = positionSection + offsetScaleSectionPrefab;
        }
        if (instance != null)
        {
            instance = Instantiate(sectionPrefab,  new Vector3(0.0f, positionSection, 0.0f),
                Quaternion.identity, parentPrefabs);

            ControlSection();
        }
    }

    private void ControlSection()
    {
        if (sections.Count < 3)
        {
            sections.Add(instance);
        }

        if (sections.Count == 3)
        {
            Destroy(sections[0].gameObject);
            sections.RemoveAt(0);
        }
    }

    private void OnDisable()
    {
        Trigger.triggerEvent -= Trigger_triggerEvent;
    }
}
