using System;
using System.Collections.Generic;

public class StateMachine<T>
{
    private struct Tuple
    {
        public T item1;
        public T item2;
    }

    private readonly Dictionary<Tuple, Action> _stateTransitionHandlers;
    //private readonly Dictionary<T, Action> _stateHandlers;
    private T _currentState;

    public StateMachine()
        : this(default(T))
    {

    }

    public StateMachine(T defaultState)
    {
        _stateTransitionHandlers = new Dictionary<Tuple, Action>();
        //_stateHandlers = new Dictionary<T, Action>();
        _currentState = defaultState;
    }

    public void AddTransitionHanlder(T from, T to, Action handler)
    {
        var transition = new Tuple()
        {
            item1 = from,
            item2 = to
        };
        _stateTransitionHandlers.Add(transition, handler);
    }

    /*public void AddStateHandler(T state, Action handler)
    {
        _stateHandlers.Add(state, handler);
    }*/

    /*public void Update()
    {
        if (_stateHandlers.ContainsKey(_currentState))
            _stateHandlers[_currentState]();
    }*/

    public void Advance(T newState)
    {
        var transition = new Tuple()
        {
            item1 = _currentState,
            item2 = newState
        };

        if (_stateTransitionHandlers.ContainsKey(transition))
            _stateTransitionHandlers[transition]();
        _currentState = newState;
    }
}

public class StateMachine
{
    private struct Tuple
    {
        public object item1;
        public object item2;
    }

    private readonly Dictionary<Tuple, Action> _stateTransitionHandlers;
    private readonly Dictionary<object, Action> _stateHandlers;
    private object _currentState;

    public StateMachine()
        : this(null)
    {

    }

    public StateMachine(object defaultState)
    {
        _stateTransitionHandlers = new Dictionary<Tuple, Action>();
        _stateHandlers = new Dictionary<object, Action>();
        _currentState = defaultState;
    }

    public void AddTransitionHanlder(object from, object to, Action handler)
    {
        var transition = new Tuple()
        {
            item1 = from,
            item2 = to
        };
        _stateTransitionHandlers.Add(transition, handler);
    }

    public void AddStateHandler(object state, Action handler)
    {
        _stateHandlers.Add(state, handler);
    }

    public void Update()
    {
        if (_stateHandlers.ContainsKey(_currentState))
            _stateHandlers[_currentState]();
    }

    public void Advance(object newState)
    {
        var transition = new Tuple()
        {
            item1 = _currentState,
            item2 = newState
        };

        if (_stateTransitionHandlers.ContainsKey(transition))
            _stateTransitionHandlers[transition]();
        _currentState = newState;
    }
}