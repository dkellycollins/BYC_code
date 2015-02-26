using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

public class Tuple<T>
{
    public readonly T item1;
    public readonly T item2;

    public Tuple(T item1, T item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }

    public override bool Equals(object obj)
    {
        var tuple = obj as Tuple<T>;

        if (tuple == null)
        {
            return false;
        }
        return item1.Equals(tuple.item1) && item2.Equals(tuple.item2);
    }

    public override int GetHashCode()
    {
        int h1 = item1.GetHashCode();
        int h2 = item2.GetHashCode();
        return (((h1 << 5) + h1) ^ h2);
    }

    public override string ToString()
    {
        return string.Format("{0}, {1}", item1, item2);
    }
}

public abstract class StateMachineBehaviour<T> : BaseBehaviour
{
    private readonly Dictionary<Tuple<T>, Action> _stateTransitionHandlers;
    private T _currentState;

    public StateMachineBehaviour()
        : this(default(T))
    {

    }

    public StateMachineBehaviour(T defaultState)
    {
        _stateTransitionHandlers = new Dictionary<Tuple<T>, Action>();
        _currentState = defaultState;
    }

    public void AddTransitionHanlder(T from, T to, Action handler)
    {
        var transition = new Tuple<T>(from, to);
        _stateTransitionHandlers.Add(transition, handler);
    }

    public void Advance(T newState)
    {
        var transition = new Tuple<T>(_currentState, newState);

        if (_stateTransitionHandlers.ContainsKey(transition))
            _stateTransitionHandlers[transition]();
        _currentState = newState;
    }

    protected abstract void Update();
}

public abstract class StateMachine<T>
{
    private readonly Dictionary<Tuple<T>, Action> _stateTransitionHandlers;
    private readonly Dictionary<T, Action> _stateHandlers;
    private T _currentState;

    public StateMachine()
        : this(default(T))
    {

    }

    public StateMachine(T defaultState)
    {
        _stateTransitionHandlers = new Dictionary<Tuple<T>, Action>();
        _stateHandlers = new Dictionary<T, Action>();
        _currentState = defaultState;
    }

    public void AddTransitionHanlder(T from, T to, Action handler)
    {
        var transition = new Tuple<T>(from, to);
        _stateTransitionHandlers.Add(transition, handler);
    }

    public void AddStateHandler(T state, Action handler)
    {
        _stateHandlers.Add(state, handler);
    }

    public void Advance(T newState)
    {
        var transition = new Tuple<T>(_currentState, newState);

        if (_stateTransitionHandlers.ContainsKey(transition))
            _stateTransitionHandlers[transition]();
        _currentState = newState;
    }

    public abstract void Update();
}