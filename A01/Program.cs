
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;

Console.WriteLine("Hello, World!");

// Basic Data Types
int a = 18;
double b = 3.14;
char c = 'A';
string d = "Hello, World!";
bool e = true;

// if, else and if else statments  
if (a > 10) 
{
    Console.WriteLine("a is greater than 10");
}
else if (a < 10)
{
    Console.WriteLine("a is less than 10");
}
else
{
    Console.WriteLine("a is equal to 10");
}


// switch statement
int day = 4; // Change value bettween 1 and 7 to see diffrent days of the week
switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2: 
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    case 4:
        Console.WriteLine("Thursday");
        break;
    case 5:
        Console.WriteLine("Friday");
        break;
    case 6:
        Console.WriteLine("Saturday");
        break;
    case 7:
        Console.WriteLine("Sunday:");
        break;
    default:
        Console.WriteLine("Invalid day");
        break;
}

// Operators

// Addition
int x = 5;
int y = 3;
int z = x + y;
Console.WriteLine(z); // Result = 8

// Subtraction
int x = 10;
int y = 5;
int z = x - y;
Console.WriteLine(z); // Result = 5

// Multiplication
int x = 5;
int y = 5;
int z = x * y;
Console.WriteLine(z); // Result = 25

// Division
int x = 10;
int y = 2;
int z = x / y;
Console.WriteLine(z); // Result = 5

// Modulus
int x = 10;
int y = 3;
int z = x % y;
Console.WriteLine(z); // Result = 1


// Comparison Operators

// Equal to ==
int x = 5;
int y = 3;
Console.WriteLine(x == y); // Will return False because 5 is not equal to 3 

// Not equal to !=
int x = 5;
int y = 3;
Console.WriteLine(x != y); // Will return True because 5 is not equal to 3

// Greater than >
int x = 5;
int y = 3;
Console.WriteLine(x > y); // Will return True because 5 is greater then 3

// Less than <
int x = 5;
int y = 3;
Console.WriteLine(x < y); // Will return False because 5 is not less than 3

// Greater than or equal to >= 
int x = 5;
int y = 3;
Console.WriteLine(x >= y); // Will return True because 5 is greater 3

// Less than or equal to <=
int x = 5;
int y = 3;
Console.WriteLine(x <= y); // Will return False becasue 5 is less then 3


// Loops //

// While Loop
// The while loop loops through a block of code as long as a specified condition is True:

// Syntax 
// while (condition)
// {
     // code block 
// }

// Example 
int i = 0;
while (i < 5) // Will check if i is less then 5
{
    Console.WriteLine(i);     // Output the current value of 'i' to the console 
    i++;                      // Will incerment the value of 'i' by 1
}
// Result (0 1 2 3 4)



// Do/While Loop
// This is a variant of the while loop. This loop will execute the code block once checking if the condition is true, then will repeat the loop as long as the condition is true:

// Syntax 
/*
 do
 {
    //code block to be executed 
 }
 while (condition);
*/
// Example 
int i = 0; // Initialize a variable 'i' with the value 0


do // Start a do-while loop - this loop will always execute at least once
{
    Console.WriteLine(i);    // Output the current value of 'i' to the console
    i++;                     // Increment the value of 'i' by 1

   
} while (i < 5);  // Continue the loop while the condition 'i < 5' is true

// Result (0 1 2 3 4) 



// Classes Inheritance (Derived and Base Class)

class Vehicle // Parent class
{
    public string brand = "Mazda"; // Vehicle brand
    public void honk()             // Vehicle Method
    {
        Console.WriteLine("HONK get out the way!!!");
    }
}

class Car : Vehicle // Child class
{
    public string modleName = "Mazda 3";
}

class Program
{
    static void Main(string[] args)
    {
        // Create a myCar Object 
        Car myCar = new Car();

        // Call the honk() method (From the Vehicle class) on the myCar objecy
        myCar.honk();

        // Displays the values of the brand
        Console.WriteLine(myCar.brand + " "  + myCar.modleName);
    }
}

// Error handling 
// try, catch, finally, throw 
// Syntax

/** 
try
{
     //statemnt causing exception 
} catch( ExceptionName 1){
     // error handling code 
} catch (ExceptionName 2) {
     // error handling code 
} catch (ExceptionName 3) {
     // error handling code 
} finally { 
     // statements to be executed
}
*/

// Example 
// Program to try and catch divsion if there is a 0 involed
class DivideNums
{
    int result;

    // Initialize the result variable 
    DivideNums()
    {
        result = 0;
    }
    // Error checking
    public void division ( int num1, int num2)
        {  
        try                                                                 
        {
            result = num1 / num2;  // Attempting the division 
        } 
        catch (DivsionByZero e)
        {              
            Console.WriteLine("Exception caught: {0}", e);  // Handling divsion by zero error 
        } 
        finally 
        {                             
            Console.WriteLine("Result: {0}", result);  // Displaying the results even if there was an error 
        }
    }
    // Where the program execution starts 
    static void Main(string[] args)
    {
        DivideNums d = new DivideNums(); // Instance for DivedNums class
        d.division(10, 0);               // Calling the divsion method with 10 and 0 
        Console.ReadKey();               // Waitng for user input before closing the console 
    }
}