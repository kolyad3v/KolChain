using blockchainCreator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KolChainApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlockchainController : ControllerBase
{
    private readonly Blockchain _blockchain;

    public BlockchainController(Blockchain blockchain)
    {
        _blockchain = blockchain;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Block>> Get()
    {
        return Ok(_blockchain.Chain);
    }

    [HttpGet("show-latest-data")]
    public ActionResult<string> ShowLatestData()
    {
        var latestBlockData = _blockchain.ShowDataForLatestBlock();
        return Ok(latestBlockData);
    }
    
    [HttpGet("show-all-data")]
    public ActionResult<string> ShowAllData()
    {
        var allBlocksData = _blockchain.Chain.Select(block => block.Data).ToList();
        return Ok(allBlocksData);
    }

    [HttpPost("add-block")]
    public ActionResult<Block> AddBlock(String data)
    {
        Block block = new Block(DateTime.Now, null, data);
        _blockchain.AddBlock(block);
        return Ok(block);
    }

}