using Prism.Events;
using System.Collections.Generic;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.EventAggregator.Events
{
    public class ListEvent : PubSubEvent<List<Employee>> { }
}
