using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EventSetImplementation
{
    public sealed class EventKey :Object
    {

    }

    public sealed class EventSet
    {
        private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();
        public void Add(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(eventKey,out d);
            m_events[eventKey] = Delegate.Combine(d, handler);
            Monitor.Exit(m_events);

        }

        public void Remove(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            if (m_events.TryGetValue(eventKey, out d))
            {
                d = Delegate.Remove(d, handler);
                if (d != null)
                    m_events[eventKey] = d;
                else
                    m_events.Remove(eventKey);
            }
            Monitor.Exit(m_events);
        }

        public void Raise(EventKey evenetkey, Object sender, EventArgs e)
        {
            Delegate d;
            Monitor.Enter(m_events);
            m_events.TryGetValue(evenetkey, out d);
            Monitor.Exit(m_events);
            if (d != null)
            {
                d.DynamicInvoke(new Object[] {sender,e});
            }
        }

    }

    public class FooEventArgs : EventArgs
    {

    }

    public class TypeWithLotsOfEvents
    {
        private readonly EventSet m_eventSet = new EventSet();

        protected EventSet EventSet { get { return m_eventSet; } }

        protected static readonly EventKey s_fooEventKey = new EventKey();
        public event EventHandler<FooEventArgs> Foo
        {
            add { m_eventSet.Add(s_fooEventKey, value); }
            remove { m_eventSet.Remove(s_fooEventKey, value); }
        }

        protected virtual void OnFoo(FooEventArgs e)
        {
            m_eventSet.Raise(s_fooEventKey, this, e);
        }

        public void SimulateFoo()
        {
            OnFoo(new FooEventArgs());
        
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();

            twle.Foo += new EventHandler<FooEventArgs>(twle_Foo);
            twle.SimulateFoo();
        }

        static void twle_Foo(object sender, FooEventArgs e)
        {
            Console.WriteLine("Handling FooEvent here");
        }
    }
}
