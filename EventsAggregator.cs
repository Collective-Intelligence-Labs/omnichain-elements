namespace Cila
{
    public class EventsAggregator
    {

        public List<IExecutionChain> Chains {get;set; }
        
        public EventsAggregator()
        {
            Chains = new List<IExecutionChain>();
        }
    }
}