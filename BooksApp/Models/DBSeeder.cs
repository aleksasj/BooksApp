namespace BooksApp.Models
{
    public class DBSeeder
    {
        public static void Seed(LibDBContext context)
        {
            var a1 = new Author() { FirstName = "Aleksas", LastName = "Zbignev" };
            var a2 = new Author() { FirstName = "Zbignev", LastName = "Aleksas" };
            var a3 = new Author() { FirstName = "Tadas", LastName = "Mantas" };
            var a4 = new Author() { FirstName = "Mantas", LastName = "Zbignev" };
            var a5 = new Author() { FirstName = "Lina", LastName = "Linavicie" };

            context.Author.Add(a1);
            context.Author.Add(a2);
            context.Author.Add(a3);
            context.Author.Add(a4);
            context.Author.Add(a5);


            var b1 = new Book() { Title = "Astalevistą beibe", AuthorId = 1 };
            var b2 = new Book() { Title = "Gendalfas ir .net brolija", AuthorId = 2 };
            var b3 = new Book() { Title = "Eskabanas ir vienisas Jonas", AuthorId = 1 };
            var b4 = new Book() { Title = "Mordoras ir septyni nykstukai", AuthorId = 1 };
            var b5 = new Book() { Title = "Kas pavogė mano kelnes?", AuthorId = 2 };
            var b6 = new Book() { Title = "Kodėl nemoku PHP? penki patarimai kodėl turi eiti dirbti į statybas", AuthorId = 3 };

            context.Book.Add(b1);
            context.Book.Add(b2);
            context.Book.Add(b3);
            context.Book.Add(b4);
            context.Book.Add(b5);
            context.Book.Add(b6);

            context.SaveChanges();

        }
    }

}
