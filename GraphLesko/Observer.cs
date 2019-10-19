using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLesko
{
    public class VertexLocator : IObservable<Vertex>
    {

        private List<IObserver<Vertex>> _observers;

        public VertexLocator()
        {
            _observers = new List<IObserver<Vertex>>();
        }
        public IDisposable Subscribe(IObserver<Vertex> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        public void SendMessage(Vertex vertex)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(vertex);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Vertex>> _observers;
            private IObserver<Vertex> _observer;

            public Unsubscriber(List<IObserver<Vertex>> observers, IObserver<Vertex> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }

    public class Observer : IObserver<Vertex>
    {
        private IDisposable _unsubscriber;
        private string _instName;

        public Observer(string name)
        {
            _instName = name;
        }

        public virtual void Subscribe(IObservable<Vertex> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public void OnCompleted()
        {
            Console.WriteLine(String.Format("Observer {0} shut down", _instName));
            _unsubscriber.Dispose();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.ToString());
        }

        public void OnNext(Vertex value)
        {
            Console.WriteLine(String.Format("{1} is notifying: {0} is dead end", value.data, _instName));
        }
    }

}
