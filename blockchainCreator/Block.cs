using System.Security.Cryptography;
using System.Text;

namespace blockchainCreator;

public class Block
{
    public int Index { get; set; }
    public DateTime Timestamp { get; set; }
    public string Data {get; set;}
    public string PreviousHash { get; set;}
    public string Hash {get; set;}

    public Block(DateTime timestamp, string previousHash, string data){
        Index = 0;
        Timestamp = timestamp;
        PreviousHash = previousHash;
        Data = data;
        Hash = CalculateHash();
    }

    public string CalculateHash()
    {
        SHA256 sha256 = SHA256.Create();

        byte[] inputBytes = Encoding.ASCII.GetBytes($"{Timestamp}-{PreviousHash ?? ""}-{Data}");
        byte[] outputBytes = sha256.ComputeHash(inputBytes);

        return Convert.ToBase64String(outputBytes);

    }
    

    
}