using UnityEngine;

public static class EquationGeneration
{

    
    //Old Equation method, kept it in
    


        //int x = 0;
         //string equation = "";
        

    /*
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
    
     */



    public static (string equation,int xValue) RandomEquation()
    {
        int pattern = Random.Range(0, 4);
        int a;
        int b;
        int x;

        switch (pattern)
        {
            case 0:
                a = Random.Range(1, 10);
                x = Random.Range(0, 21);
                b = x + a;
                return ($"X + {a} = {b}",x);
            case 1:
                a = Random.Range(0, 21);
                x = Random.Range(1, 10);
                b = a + x;
                return ($"{a} + X = {b}", x);
            
            case 2:
                a = Random.Range(1, 10);
                //make sure x is bigger then a!
                x= Random.Range(a , a + 21);
                b= x - a;
                return ($"X - {a} = {b}", x);
            case 3:
                a = Random.Range(0, 21);
                //try to make sure x isnt negative for simplicity atm
                //not 100% but it works...
                x = Random.Range(0, a + 1);
                b = a - x;
                return ($"{a} - X = {b}", x);

            default:
                
                return("Nothing works" , 0);

           
        }
        


    }
    
}
