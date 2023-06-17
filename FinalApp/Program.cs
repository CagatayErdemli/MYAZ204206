using FinalApp;
using LinkedList.Singly;
using PriorityQueue;
using Trees;
using Trees.BinaryTree.BinarySearchTree;

ArrayRemove();

void ArrayRemove()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.ToArray();
        var array = new Array.Array<Product>();
        foreach (var item in list) array.Add(item);
        for (int i=0; i<800;i++) array.RemoveItem(0);
        Console.WriteLine($"Kapasite: {array.Capacity}");
        Console.WriteLine($"Sakladığı Eleman Sayısı: {array.Count}");
        Console.WriteLine($"İlk Eleman: {array.GetItem(0)}");
    }
}

void MaxHeapDelete()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.Where(p => p.Price < 5600 && p.Price >= 5500).ToList();
        var maxHeap = new MaxHeap<Product>(list);
        var result = new List<Product>();
        for (int i = 0; i < 5; i++)
        {
           var c = maxHeap.DeleteMinMax();
           result.Add(c);
        }
        foreach (var item in result) Console.WriteLine(item);
    }
}

void GetProductPaging()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.ToList();
        var result = getPagination(list, 7, 7);
        var tree = new BST<Product>(result);
        var traverse = BinaryTree<Product>.LevelOrderTraverse(tree.Root);

        foreach (var item in traverse) Console.WriteLine(item);
    }
}

List<Product> getPagination(List<Product> list, int page, int pageSize)
{
    return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
}