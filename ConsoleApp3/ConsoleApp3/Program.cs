using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ConsoleApp3;
class Program
{
    public static void Main(string[] args)
    {
        
    }
}

public class Tower()
{
    public string TowerName { get; }
    public int Damage { get; protected set; }
    public int Range { get; protected set; }
    public int FireRate { get; protected set; }

}
