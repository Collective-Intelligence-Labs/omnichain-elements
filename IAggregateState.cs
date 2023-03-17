namespace Cila
{
    public interface IAggregateState
    {
        int CurrentEvents {get; set;}

        string LastOriginChain {get;set;}

        string Hash {get;set;}
    }
}