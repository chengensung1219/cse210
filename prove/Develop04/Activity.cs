abstract class Activity {

    public virtual void Loading(int seconds = 3, int speed = 200) {
        string[] spinner = { "|", "/", "-", "\\" };
        int runTime = seconds * 1000;
        Console.WriteLine("Get ready...");
        while (runTime > 0) {
            for (int i = 0; i < 3; i++) {
                Console.Write(spinner[i]);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                System.Threading.Thread.Sleep(speed);
                runTime -= speed;
                Console.Write(" ");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
        Console.Clear();
    }

    public abstract void Run();
    

    public abstract int DisplayDescription();

    public abstract void Countdown(string script, int seconds);

    public virtual void Sleep(int seconds = 3) {
        System.Threading.Thread.Sleep(seconds * 1000);
    }

}