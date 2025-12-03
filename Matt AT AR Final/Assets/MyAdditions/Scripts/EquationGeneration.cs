using UnityEngine;

public static class EquationGeneration
{
    public static (string equation , int xValue) GenerateRandomEquation()
    {
        int randomEquation = Random.Range(0, 4);
        int a = Random.Range(1,  10);
        int b = Random.Range(2, 20);
        int x = 0;
        string equation = "";
        


        switch (randomEquation)
        {
            //chooses between any of these algebra equations randomly 
            case 0:
                x = b - a;
                equation = $"X + {a} = {b}";
                break;

            case 1:
                x = b + a;
                 equation = $"X - {a} = {b}";
                break;

            case 2:
                x = b - a;
                equation = $"{a} + X = {b}";
                break;

            case 3:
                x = a - b;
                equation = $"{a} - X = {b}";
                break;
           
        }
        return (equation, x);

        //potentially need to add more steps or add multiplcation/division
    }
}
