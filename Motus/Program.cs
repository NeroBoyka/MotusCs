namespace Motus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetMot(5));
        }

        static void AfficherCouleur(String texte, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            Console.Write(texte);

            Console.ForegroundColor = ConsoleColor.White;
        }

        static String GetMot(int lenMot)
        {
            string inputWord = "";

            while (inputWord.Length < lenMot)
            {
                Console.WriteLine("Entrez un mot de " + lenMot + " caracteres: ");
                inputWord = Console.ReadLine();
            }

            return inputWord;
        }
    }
}
