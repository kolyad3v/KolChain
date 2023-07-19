namespace blockchainCreator;

public class Block
{
    public int Index { get; set; }
    public DateTime Timestamp { get; set; }
    public string Data {get; set;}
    public string PreviousHash { get; set;}
    public string Hash {get; set;}

    public Block(DateTime Timestamp, string PreviousHash, string data){
        Index = 0;
        Timestamp = timestamp;
        
    }  
    

    
}