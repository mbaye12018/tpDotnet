using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("👋 Salut, et bienvenue dans le jeu 'Trouver le Nombre' !");
        Console.WriteLine("Prépare-toi, ça va être fun ! 😄");

        // Étape 1 : Trouver un nombre entre 1 et 10
        Console.WriteLine("\n🔍 Étape 1 : Trouve un nombre entre 1 et 10.");
        int fixedNumber = 5; // Le nombre fixe à deviner
        bool hasWon = false; // Indicateur de victoire
        List<int> attempts = new List<int>(); // Historique des choix

        while (!hasWon)
        {
            try
            {
                Console.Write("🤔 Allez, choisis un nombre entre 1 et 10 : ");
                int userGuess = int.Parse(Console.ReadLine());

                // Vérification des bornes
                if (userGuess < 1 || userGuess > 10)
                    throw new ArgumentOutOfRangeException("⚠️ Le nombre doit être compris entre 1 et 10. Essaye encore !");

                attempts.Add(userGuess);

                if (userGuess == fixedNumber)
                {
                    Console.WriteLine("🎉 Bravo, tu as gagné ! C'était bien 5 !");
                    hasWon = true;
                }
                else
                {
                    Console.WriteLine("❌ Oups, ce n'est pas ça. Réessaye !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"😅 Petit problème : {ex.Message}");
            }
        }

        Console.WriteLine($"📋 Tu as essayé ces nombres : {string.Join(", ", attempts)}");

        // Étape 3 : Générer un nombre dans des bornes personnalisées
        Console.WriteLine("\n🔄 Maintenant, passons à l'étape suivante !");
        Console.WriteLine("Tu vas choisir un intervalle, et je vais générer un nombre à deviner.");

        int lowerBound = 0, upperBound = 0, randomNumber = 0;
        Random random = new Random();

        while (true)
        {
            try
            {
                Console.Write("🔢 Donne-moi la borne inférieure : ");
                lowerBound = int.Parse(Console.ReadLine());

                Console.Write("🔢 Donne-moi la borne supérieure : ");
                upperBound = int.Parse(Console.ReadLine());

                if (lowerBound >= upperBound)
                    throw new ArgumentException("⚠️ La borne inférieure doit être strictement inférieure à la borne supérieure.");

                randomNumber = random.Next(lowerBound, upperBound + 1);
                Console.WriteLine($"🎲 J'ai choisi un nombre entre {lowerBound} et {upperBound}. À toi de jouer !");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"😅 Oups : {ex.Message}");
            }
        }

        attempts.Clear(); // Réinitialisation des choix pour la nouvelle étape
        int attemptCount = 0;

        while (true)
        {
            try
            {
                Console.Write($"🤔 Fais un choix entre {lowerBound} et {upperBound} : ");
                int userGuess = int.Parse(Console.ReadLine());
                attemptCount++;

                if (userGuess < lowerBound || userGuess > upperBound)
                    throw new ArgumentOutOfRangeException($"⚠️ Le nombre doit être compris entre {lowerBound} et {upperBound}. Essaye encore !");

                if (attempts.Contains(userGuess))
                {
                    Console.WriteLine("⚠️ Hé, tu as déjà essayé ce nombre. Choisis un autre !");
                    continue;
                }

                attempts.Add(userGuess);

                if (userGuess == randomNumber)
                {
                    Console.WriteLine("🎉 Incroyable ! Tu as trouvé le bon nombre !");
                    break;
                }
                else
                {
                    Console.WriteLine(userGuess > randomNumber
                        ? "📉 Trop grand ! Réessaye."
                        : "📈 Trop petit ! Réessaye.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"😅 Oups : {ex.Message}");
            }
        }

        // Calcul de la note
        double score = (double)(upperBound - lowerBound + 1) / attemptCount;
        Console.WriteLine($"\n🌟 Bravo, voici ton score : {score:F2} !");
        Console.WriteLine($"📋 Tes choix durant cette étape : {string.Join(", ", attempts)}");
        Console.WriteLine("\nMerci d'avoir joué ! À bientôt ! 😊");
    }
}
