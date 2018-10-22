## Naming Conventions
    
    useCamelCase

## Layout Conventions

1. Write one statement per line.
2. Write one declaration per line.
3. Tab (set as 4 spaces) indentation.
4. Add at least one blank line between definitions.
5. Parantheses in expression to make expressions apparent.

```
    if ((val1 > val2) && (val1 > val3))
    {
        // Take appropriate action.
    }
 ```

## Commenting Conventions

1. Place the comment on a separate line, not at the end of a line of code.
2. Begin comment text with an uppercase letter.
3. End comment text with a period.
4. Insert one space between the comment delimiter (//) and the comment text,<br> 
as shown in the following example.


```
   // The following declaration creates a query. It does not run
   // the query.
```

## Strings

String interpolation as presented below.

```
string displayName = $"{nameList[n].LastName}, {nameList[n].FirstName}";
```

## Local Variables

Use implicit type variables if the type is obvious when declared.


```
// When the type of a variable is clear from the context, use var 
// in the declaration.
var var1 = "This is clearly a string.";
var var2 = 27;
var var3 = Convert.ToInt32(Console.ReadLine());
```

If the type is not apparent, you must explicitly declare the variable's type.<br>
As presented below: <br>

```
// When the type of a variable is not clear from the context, use an
// explicit type.
int var4 = ExampleClass.ResultSoFar();
```

## Arrays

```
// Preferred syntax. Note that you cannot use var here instead of string[].
string[] vowels1 = { "a", "e", "i", "o", "u" };


// If you use explicit instantiation, you can use var.
var vowels2 = new string[] { "a", "e", "i", "o", "u" };

// If you specify an array size, you must initialize the elements one at a time.
var vowels3 = new string[5];
vowels3[0] = "a";
vowels3[1] = "e";
// And so on.
```


## Resources 

[Microsoft C-Sharp coding style](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
