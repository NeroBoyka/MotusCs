namespace Motus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void AfficherCouleur(String texte, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            Console.Write(texte);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
