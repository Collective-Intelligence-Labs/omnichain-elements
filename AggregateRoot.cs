using Example.Protobuf;

internal class AggregateRoot
{

     string ID {get;set;}
     private  Dictionary<string,Item> items = new Dictionary<string, Item>();

     public void Handle(TransferItem cmd)
     {
        if (!items.ContainsKey(cmd.Hash))
        {
            return; //throw no item found;
        }
        if (items[cmd.Hash].Owner != cmd.Sender)
        {
            return; //throw invalid sender execption
        }
        Apply(new ItemTransfered(){
            Hash = cmd.Hash,
            From = items[cmd.Hash].Owner,
            To = cmd.To
        });
     }

     public void Apply(object e)
     {
        if (e is ItemTransfered){
            this.On(e as ItemTransfered);
        }
        if (e is ItemMinted){
            this.On(e as ItemMinted);
        }
     }

     void On(ItemTransfered e)
     {
        items[e.Hash].Owner = e.To;
     }

     void On(ItemMinted e)
     {
        items[e.Hash] = new Item(e.Hash, e.Owner);
     }
}