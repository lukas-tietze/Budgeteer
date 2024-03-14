namespace Budgeteer.DataStructures.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var tree = new BasicTree<int>(0);

        tree.EnumerateDepthFirst();
    }
}