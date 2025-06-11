using MenuParser.Domain.ValueObjects;

namespace MenuParser.Domain.Entities;

public class MenuItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public Price Price { get; private set; }

    public bool IsDeleted { get; private set; } = false;


    public MenuItem(string name, Price price)
        {  
            Name= name;
            Price = price;

        }

public void SoftDelete() => IsDeleted = true;
}

