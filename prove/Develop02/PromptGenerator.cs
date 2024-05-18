using System;

class PromptGenerator{
    
    public static string GetRandomPrompt()
    {   
        List<string> prompts = new List<string>() { 
        "What are you most grateful for today?",
        "What was the highlight of your day?",
        "What was the most challenging part of your day, and how did you handle it?",
        "Did you learn anything new today? If so, what was it?",
        "What goal did you work towards today, and what progress did you make?",
        "How did you take care of yourself today (physically, mentally, emotionally)?",
        "What was your mood like throughout the day, and what influenced it?",
        "Did you have any meaningful conversations or interactions today? Describe them.",
        "What was your favorite moment of the day, and why?",
        "If you could change one thing about today, what would it be?",
        "What was the most productive part of your day?",
        "Did you procrastinate on anything today? If so, what was it, and why did you procrastinate?",
        "What was the most challenging emotion you felt today, and how did you cope with it?",
        "Did you have any revelations or insights today?",
        "What are you looking forward to tomorrow?",
        "How did you contribute positivity to someone else's day?",
        "What was the most enjoyable activity you did today?",
        "Did you step out of your comfort zone today? If so, how?",
        "What was the most significant decision you made today, and why was it important?",
        "If you could repeat one moment from today, what would it be?" };
        
        Random random = new Random();
        int randomIndex = random.Next(0, 20);
        return prompts[randomIndex];
    }
}