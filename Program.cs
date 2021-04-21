using System;

namespace MonsterFightDatabase
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = GameManager.Instance)
                game.Run();
        }
    }
}
