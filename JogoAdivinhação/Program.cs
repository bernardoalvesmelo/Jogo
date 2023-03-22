namespace JogoAdivinhação
{
    public class Program
    {
        static void Main()
        {
            MostrarTitulo();
            int dificuldade = ReceberDificuldade();
            Random aleatorio = new Random();
            int numeroSecreto = aleatorio.Next(1, 21);
            double pontuacao = 1000;
            string resultado = "Você perdeu!";
            for (int i = 0; i < dificuldade; i++)
            {
                int palpite = ReceberPalpite(dificuldade - i);
                if (CompararPalpite(numeroSecreto, palpite))
                {
                    resultado = "Você venceu!";
                }
                else
                {
                    pontuacao -= Math.Abs((palpite - numeroSecreto) / 2);
                    Console.WriteLine("Sua pontuação é: " + pontuacao);
                }
            }

            Console.WriteLine(resultado);
            Console.WriteLine("O número secreto escolhido foi: " + numeroSecreto);
            Console.WriteLine("Sua pontuação foi: " + pontuacao);
            Console.ReadLine();
        }

        static void MostrarTitulo()
        {
            string titulo = "Jogo da Adivinhação";
            string asteriscos = new string('*', titulo.Length + 4);
            Console.WriteLine(asteriscos);
            Console.WriteLine("* " + titulo + " *");
            Console.WriteLine(asteriscos);
        }

        static int ReceberDificuldade()
        {
            while (true)
            {
                Console.WriteLine("Dificuldades Disponíveis:");
                Console.WriteLine("(1) Fácil = 15 chances");
                Console.WriteLine("(2) Médio = 10 chances");
                Console.WriteLine("(3) Difícil = 5 chances");
                Console.Write("Escolha a dificuldade: ");
                int dificuldade = Convert.ToInt32(Console.ReadLine());
                if (dificuldade < 0 || dificuldade > 3)
                {
                    Console.WriteLine("Escolha um número entre 1 e 3!");
                    Console.ReadLine();
                    continue;
                }
                return 20 - (5 * dificuldade);
            }
        }
        static int ReceberPalpite(int tentativas)
        {

            Console.WriteLine("Tentaivas restantes: " + (tentativas));
            Console.Write("Faça um palpite: ");
            return Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }

        static bool CompararPalpite(int numeroSecreto, int palpite)
        {
            if (palpite == numeroSecreto)
            {
                return true;
            }
            else if (palpite < numeroSecreto)
            {
                Console.WriteLine("O número " + palpite + " é menor!");
            }
            else
            {
                Console.WriteLine("O número " + palpite + " é maior!");
            }
            return false;
        }
    }
}