using System.ComponentModel.Design;

namespace ConsoleApp56
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandCommonAttack = "1";
            const string CommandFireball = "2";
            const string CommandExplosion = "3";
            const string CommandRestoringHealAndMana = "4";

            Random random = new Random();

            int minPlayerHealth = 1750;
            int maxPlayerHealth = 2251;
            int playerHealth = random.Next(minPlayerHealth, maxPlayerHealth);

            int minBossHealth = 2000;
            int maxBossHealth = 2501;
            int bossHealth = random.Next(minBossHealth, maxBossHealth);

            int minPlayerMana = 1250;
            int maxPlayerMana = 1751;
            int playerMana = random.Next(minPlayerMana, maxPlayerMana);

            int usedRestoringHealAndMana = 2;
            int commonAttackManaCost = 50;
            int fireBallManaCost = 150;
            int explosionManaCost = 250;

            string healthPlayer = "Здоровье игрока";
            string healthBoss = "Здоровье босса";
            string manaPlayer = "Мана игрока";
            string commonAttack = "Обычная атака";
            string fireBall = "Огненный шар";
            string explosion = "Взрыв";
            string restoringHealAndMana = "Восстановление";

            bool usedFireBall = false;

            Console.WriteLine($"Бой с боссом!\nВаши характеристики:\n{healthPlayer} - {playerHealth}" +
                $"\n{manaPlayer} - {playerMana}\n\n{healthBoss} - {bossHealth}");

            int playerHealthFull = playerHealth;
            int playerManaFull = playerMana;

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine($"\nВыберете заклинание для атаки:\n{CommandCommonAttack} - {commonAttack}\n{CommandFireball}" +
                    $" - {fireBall}\n{CommandExplosion} - {explosion}\n{CommandRestoringHealAndMana} - " +
                    $"{restoringHealAndMana} (Восстанавливает игроку полностью здоровье и ману. Можно использовать 2 раза.)");

                int minBossAttack = 250;
                int maxBossAttack = 351;
                int bossAttack = random.Next(minBossAttack, maxBossAttack);

                int minPlayerCommonAttack = 50;
                int maxPlayerCommonAttack = 101;
                int playerCommonAttack = random.Next(minPlayerCommonAttack, maxPlayerCommonAttack);

                int minPlayerFireBall = 150;
                int maxPlayerFireBall = 251;
                int playerFireball = random.Next(minPlayerFireBall, maxPlayerFireBall);

                int minPlayerExplosion = 250;
                int maxPlayerExplosion = 351;
                int playerExplosion = random.Next(minPlayerExplosion, maxPlayerExplosion);

                Console.Write("\n");
                string userInputSpell = Console.ReadLine();

                switch (userInputSpell)
                {
                    case CommandCommonAttack:
                        if (playerMana >= commonAttackManaCost)
                        {
                            bossHealth -= playerCommonAttack;
                            playerHealth -= bossAttack;
                            playerMana -= commonAttackManaCost;

                            Console.Clear();
                            Console.WriteLine($"Вы нанесли {playerCommonAttack} урона. Босс нанес " +
                                $"{bossAttack} урона\nУ вас осталось {playerHealth} здоровья " +
                                $"и {playerMana} маны\nУ босса осталось {bossHealth} здоровья ");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно маны!");

                            playerHealth -= bossAttack;

                            Console.WriteLine($"Босс нанес {bossAttack} урона.\nУ вас осталось {playerHealth} здоровья");
                        }
                        break;

                    case CommandFireball:
                        if (playerMana >= fireBallManaCost)
                        {
                            bossHealth -= playerFireball;
                            playerHealth -= bossAttack;
                            playerMana -= fireBallManaCost;
                            usedFireBall = true;

                            Console.Clear();
                            Console.WriteLine($"Вы нанесли {playerFireball} урона. Босс нанес" +
                                $" {bossAttack} урона\nУ вас осталось {playerHealth} здоровья" +
                                $" и {playerMana} маны\nУ босса осталось {bossHealth} здоровья ");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно маны!");

                            playerHealth -= bossAttack;

                            Console.WriteLine($"Босс нанес {bossAttack} урона.\nУ вас осталось {playerHealth} здоровья");
                        }
                        break;

                    case CommandExplosion:
                        if (playerMana > explosionManaCost && usedFireBall == true)
                        {
                            bossHealth -= playerExplosion;
                            playerHealth -= bossAttack;
                            playerMana -= explosionManaCost;

                            Console.Clear();
                            Console.WriteLine($"Вы нанесли {playerExplosion} урона. Босс нанес" +
                                $" {bossAttack} урона\nУ вас осталось {playerHealth} здоровья" +
                                $" и {playerMana} маны\nУ босса осталось {bossHealth} здоровья ");

                        }
                        else if (usedFireBall == false)
                        {
                            Console.WriteLine("Сейчас это невозможно! ");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно маны!");

                            playerHealth -= bossAttack;

                            Console.WriteLine($"Босс нанес {bossAttack} урона.\nУ вас осталось {playerHealth} здоровья");
                        }
                        break;

                    case CommandRestoringHealAndMana:
                        if (usedRestoringHealAndMana > 0)
                        {
                            usedRestoringHealAndMana--;
                            playerHealth = playerHealthFull;
                            playerMana = playerManaFull;
                            playerHealth -= bossAttack;

                            Console.Clear();
                            Console.WriteLine($"Босс нанес {bossAttack} урона\nУ вас осталось {playerHealth} здоровья" +
                                $" и {playerMana} маны\nУ босса осталось {bossHealth} здоровья ");
                        }
                        else if (usedRestoringHealAndMana <= 0)
                        {
                            Console.WriteLine("У вас закончились заряды!");

                            playerHealth -= bossAttack;

                            Console.WriteLine($"Босс нанес {bossAttack} урона.\nУ вас осталось {playerHealth} здоровья");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно маны!");

                            playerHealth -= bossAttack;

                            Console.WriteLine($"Босс нанес {bossAttack} урона.\nУ вас осталось {playerHealth} здоровья");
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Неверная команда!");

                            playerHealth -= bossAttack;

                            Console.WriteLine($"Босс нанес {bossAttack} урона.\nУ вас осталось {playerHealth} здоровья");

                            break;
                        }
                }
            }

            if (playerHealth <= 0 && bossHealth > 0)
            {
                Console.WriteLine("\nИгрок погиб!");
            }
            else if (playerHealth > 0 && bossHealth <= 0)
            {
                Console.WriteLine("\nИгрок победил!");
            }
            else if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("\nНичья!");
            }
        }
    }
}

