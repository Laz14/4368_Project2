using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    [SerializeField] BoardSpawner _boardSpawner = null;
    [SerializeField] List<AttackCardData> _attackDeckConfig = new List<AttackCardData>();

    Camera _camera = null;
    RaycastHit _hitInfo;

    CommandInvoker _commandInvoker = new CommandInvoker();

    Deck<Card> _deck = new Deck<Card>();
    Card _selectedCard = null;

    private void Awake()
    {
        _camera = Camera.main;
        SetupAbilityDeck();
        _selectedCard = _deck.Draw();
    }

    private void Update()
    {
        // Spawn Command!
        if (Input.GetMouseButtonDown(0))
        {
            GetNewMouseHit();
            if (_hitInfo.transform.GetComponent<CardSpot>() != null && _selectedCard != null)
            {
                _hitInfo.transform.GetComponent<CardSpot>().SetCard(_selectedCard);
                _selectedCard = _deck.Draw();
            }
            if (_hitInfo.transform.GetComponent<DiscardSpot>() != null && _selectedCard != null)
            {
                _hitInfo.transform.GetComponent<DiscardSpot>().AddCard(_selectedCard);
                _selectedCard = _deck.Draw();
            }
        }
        // Buff command!
        if (Input.GetMouseButtonDown(1))
        {
            GetNewMouseHit();
            BuffToken();
        }
        // undo last command
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }
    }

    void GetNewMouseHit()
    {
        // spawn token at mouse position
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hitInfo, Mathf.Infinity))
        {
            //Debug.Log("Ray hit: " + _hitInfo.transform.name);
        }
    }

    void SpawnToken()
    {
        // create the command
        ICommand spawnTokenCommand = new SpawnTokenCommand(_boardSpawner, _hitInfo.point);
        // perform the command!
        _commandInvoker.ExecuteCommand(spawnTokenCommand);
    }

    public void Undo()
    {
        _commandInvoker.UndoCommand();
    }

    public void BuffToken()
    {
        // note, this search only works if the Collider and IBuffable component
        // are attached to the same gameObject
        IBuffable buffableUnit = _hitInfo.transform.GetComponent<IBuffable>();
        // if we have the token, command it to buff
        if (buffableUnit != null)
        {
            ICommand buffCommand = new BuffCommand(buffableUnit);
            _commandInvoker.ExecuteCommand(buffCommand);
        }
    }

    private void SetupAbilityDeck()
    {
        foreach (AttackCardData attackData in _attackDeckConfig)
        {
            AttackCard newAttackCard = new AttackCard(attackData);
            _deck.Add(newAttackCard);
        }

        _deck.Shuffle();
    }
}
