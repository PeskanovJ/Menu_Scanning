namespace MenuParser.Domain.Entities
{
    public class Menu
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public  string Name { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        private readonly List<MenuItem> _items = new();
        public IReadOnlyCollection<MenuItem> Items => _items.AsReadOnly();

        public Menu(string name)
            { Name = name; }
        
        public void AddItem(MenuItem item)
            { _items.Add(item); }
        

    }
}
