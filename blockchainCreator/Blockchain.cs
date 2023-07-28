using System.Net.Http.Json;
using Newtonsoft.Json;

namespace blockchainCreator;

public class Blockchain
{
    public IList<Block> Chain { set; get; }

    public Blockchain()
    {
        InitialiseChain();
        AddGenesisBlock();
        Console.WriteLine("New Chain Created!");
        AddBlock(new Block(DateTime.Now, null, "{Sam and Nick are getting married in two days}"));
    }

    private void InitialiseChain()
    {
        Chain = new List<Block>();
    }

    private void AddGenesisBlock()
    {
        Chain.Add(CreateGenesisBlock());
    }

    private Block CreateGenesisBlock()
    {
        return new Block(DateTime.Now, null, "{}");
    }

    public Block GetLatestBlock()
    {
        return Chain[Chain.Count - 1];
    }

    public void AddBlock(Block block)
    {
        Block latestBlock = GetLatestBlock();
        block.Index = latestBlock.Index + 1;
        block.PreviousHash = latestBlock.Hash;
        block.Hash = block.CalculateHash();
        Chain.Add(block);
    }

    public bool IsValid()
    {
        for (var i = 1; i < Chain.Count; i++)
        {
            
            Block currentBlock = Chain[i];
            Block previousBlock = Chain[i - 1];

            if (currentBlock.Hash != currentBlock.CalculateHash()) return false;
            
            if (currentBlock.PreviousHash != previousBlock.Hash) return false;

        }

        return true;

    }

    public void ShowAllBlocksData()
    {
        
        foreach (var t in Chain)
        {
            Console.WriteLine(t.Data);
        }
    }

    public string ShowDataForLatestBlock()
    {
        var data = Chain[Chain.Count - 1].Data;
        return JsonConvert.SerializeObject(data);
    }
}

