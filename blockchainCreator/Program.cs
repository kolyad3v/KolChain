// See https://aka.ms/new-console-template for more information

using blockchainCreator;

Blockchain kolChain = new Blockchain();
kolChain.AddBlock(new Block(DateTime.Now, null, "{Sam and Nick are getting married in two days}"));
kolChain.ShowAllBlocksData();
var thumbsUp = char.ConvertFromUtf32(0x1F44D);
if (kolChain.IsValid())
{
    Console.WriteLine($"All good!");
}