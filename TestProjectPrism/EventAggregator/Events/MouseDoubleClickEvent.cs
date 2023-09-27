using Prism.Events;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.EventAggregator.Events
{
    public class MouseDoubleClickEvent : PubSubEvent<DbEntity>
    {
    }
}
